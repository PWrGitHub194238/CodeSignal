#!\bin\bash

function pasreBash() {
	while (( ${#} > 0 ))
	do
		case "${1}" in
			-p|--project)
				PROJECT_NAME="${2}"
				shift
			;; 
			-n|--name)
				CLASS_NAME="${2}"
				shift
			;; 
			-r|--return-type)
				RETURN_TYPE="${2}"
				shift
			;;
			-i|--input-params)
				INPUT_PARAMS="${2}"
				shift
			;;
			-test|--test-name)
				TEST_NAME="${2}"
				shift
			;;
			-td|--task-difficulty)
				TASK_DIFFICULTY="${2}"
				shift
			;;
			-tt|--task-type)
				TASK_TYPE="${2}"
				shift
			;;
			-tp|--task-points)
				TASK_POINTS="${2}"
				shift
			;;
			-td|--task-description)
				TASK_DESCRIPTION="${2}"
				shift
			;;
			
			-f|--framework)
				FRAMEWORK="${2}"
				shift
			;;
			*)
				printHelp
				exit
			;;
		esac
		shift # next argument
	done
}

# Public function
# Show prompt and force user to confirm or cancel.
#
# Parameters:
#	$1 - text message to show to user before asking for 'y' or 'n' value
#
function confirm() {
	read -e -p "$1 (y/n): "
	echo "$REPLY"
}

# Public function
#
# Print help for script
#
function printHelp() {
	echo -e "Generates template for any CodeSignal task of given Project name and Test name.\n\n"
	echo -e "-p|--project \t\t - \t project name,"
	echo -e "-r|--return-type \t - \t return type for mine method from CodeSignal's task,"
	echo -e "-i|--input-params \t - \t input parameters types and names from CodeSignal's task method signature,"
	echo -e "-test--test-name \t - \t test name to cover example and test cases from the task,"
	echo -e "-td|--task-difficulty \t - \t difficulty of given task (Easy|Medium|Hard),"
	echo -e "-tt|--task-type \t - \t type of given task (Codewriting),"
	echo -e "-tp--task-points \t - \t points for resolving given problem,"
	echo -e "-td|--task-description \t - \t description of given task,"
	echo -e "-f|--framework \t\t - \t framework."
}

# Set parameter default values based on script's input if specified.
#
function checkParams() {
	# If variable is not defined
	if ! [ -n "${CLASS_NAME+x}" ]
	then
		CLASS_NAME="Solution"
	fi
	
	if ! [ -n "${RETURN_TYPE+x}" ]
	then
		RETURN_TYPE="object"
	fi

	if ! [ -n "${INPUT_PARAMS+x}" ]
	then
		INPUT_PARAMS="object o"
	fi
	
	if ! [ -n "${TASK_DIFFICULTY+x}" ]
	then
		TASK_DIFFICULTY="Undefined"
	fi
	
	if ! [ -n "${TASK_TYPE+x}" ]
	then
		TASK_TYPE="Undefined"
	fi
	
	if ! [ -n "${TASK_POINTS+x}" ]
	then
		TASK_POINTS="Undefined"
	fi

	if ! [ -n "${TASK_DESCRIPTION+x}" ]
	then
		TASK_DESCRIPTION="TODO"
	fi
	
	if ! [ -n "${FRAMEWORK+x}" ]
	then
		FRAMEWORK="netcoreapp2.1"
	fi
}
			
# Checks if required parameters were set.
#
function checkReqParams() {
	[ -n "${PROJECT_NAME+x}" ] && [ -n "${TEST_NAME+x}" ]
}

####################################################################################################################

#\
#
# Parameters:
# ${1} - project's name,
# ${2} - return type for assigment's core method,
# ${3} - parameter types and names, delimetered by a coma.
#
function buildProject() {
	if ! [ $(git diff-index --quiet HEAD) ]; then
		echo "Git index is not empty."
		git status
		if [ $(confirm 'Do you want to hard reset to HEAD commit?') == 'y' ]; then
			git reset --hard HEAD
		fi
	fi
	
	git checkout master
	
	# Create project library with given framework.
	dotnet new classlib -f "${FRAMEWORK}" -n "${PROJECT_NAME}"
	cd "${PROJECT_NAME}/"
	
	# Removing unnecessary using statements.
	sed -i "s/using System;//" "Class1.cs"
	
	# Change class name
	sed -i "s/Class1/${CLASS_NAME}/" "Class1.cs"
	
	sed -i "s/    {/    {\n        public static ${RETURN_TYPE} ${PROJECT_NAME}(${INPUT_PARAMS}) {\n            return (${RETURN_TYPE}) new object();\n        }/" "Class1.cs"
	# Change root lib class file name
	mv "Class1.cs" "${CLASS_NAME}.cs"
	
	# Generate README.md markdown file
	touch "README.md"
	echo "![difficulty_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/difficulty.png) **${TASK_DIFFICULTY}** ![difficulty_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/type.png) **${TASK_TYPE}** ![difficulty_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/points.png) **${TASK_POINTS}**" > "README.md"
	
	echo "${TASK_DESCRIPTION}" >> "README.md"
	
	# Build classlib project
	dotnet build
	
	
	
	
	
	
	cd "../"
	# Add test xunit project
	dotnet new xunit -f "${FRAMEWORK}" -n "${PROJECT_NAME}.Tests"
	# Add refference to a project to be tested
	dotnet add "${PROJECT_NAME}.Tests/${PROJECT_NAME}.Tests.csproj" reference "${PROJECT_NAME}/${PROJECT_NAME}.csproj"
	cd "${PROJECT_NAME}.Tests/"
	
	# Make separate class with test data
	mkdir "TestData"
	cd "TestData"
	
	touch "${TEST_NAME}TestData.cs"
	echo "using System.Collections;
using System.Collections.Generic;

namespace ${PROJECT_NAME}.Tests.TestData
{
    class ${TEST_NAME}TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new ${RETURN_TYPE} { } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
" > "${TEST_NAME}TestData.cs"
	cd "../"
	
	# Generate unit test method
	sed -i "s/using System;/using ${PROJECT_NAME}.Tests.TestData;/" UnitTest1.cs
	sed -i "s/UnitTest1/${CLASS_NAME}Test/" UnitTest1.cs
	sed -i "s/\[Fact\]/[Theory]\n        [ClassData(typeof(${TEST_NAME}TestData))]/" UnitTest1.cs
	sed -i "s/Test1()/${TEST_NAME}(${INPUT_PARAMS}, ${RETURN_TYPE} expectedResult)/" UnitTest1.cs
	sed -i "s/        {/        {\n        \/\/ Arrange\n\n        \/\/ Act\n        ${RETURN_TYPE} result = ${CLASS_NAME}.${PROJECT_NAME}($(getParamNames));\n\n        \/\/ Assert\n        Assert.Equal(expectedResult, result);/" UnitTest1.cs

	mv "UnitTest1.cs" "${CLASS_NAME}Test.cs"
	dotnet build
	dotnet run
	
	cd "../"
	# Add both projects into solution.
	dotnet sln CodeSignal.sln add "${PROJECT_NAME}"
	dotnet sln CodeSignal.sln add "${PROJECT_NAME}.Tests"
}

function getParamNames() {
# Get parameters names without types
	names="${INPUT_PARAMS},"
	names="$(echo "${names}" | sed 's/\S* \(\S*\),\s*/\1,/g')"
	echo "${names::-1}"
}
 

####################################################################################################################

#set -e

# Parse user's input (script parameters)
pasreBash "$@"
# Parse given script's parameters by given logic i.e. set default values for parameters if needed.
checkParams

if checkReqParams
then
  buildProject
else
  printHelp
fi