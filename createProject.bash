#!\bin\bash

function pasreBash() {
	while (( ${#} > 0 ))
	do
		case "${1}" in
			-p|--project)
				PROJECT_NAME="${2}"
				# Method names in CodeSignal begins with a small letter (camelCase), strangely enough.
				METHOD_NAME="${PROJECT_NAME,}"
				# And we want upper case (PascalCase) in our project name.
				PROJECT_NAME="${PROJECT_NAME^}"		
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
			-t|--test-name)
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
			-tdesc|--task-description)
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
	echo -e "Usage: bash createProject.bash -p|--project <arg> -test|--test-name <arg> 
		[-r|--return-type <arg>] [-i|--input-params <arg>] [-tt|--task-type <arg>] 
		[-tp|--task-points <arg>] [-tdesc|--task-description <arg>] [-f|--framework <arg>]"
	echo -e "\nGenerates template for any CodeSignal task of given Project name and Test name.\n"
	echo -e "-p|--project <arg> \t\t- \t project name,"
	echo -e "-t|--test-name <arg>\t \t- \t test name to cover example and test cases from the task,"
	echo -e "-r|--return-type <arg> \t\t- \t return type for mine method from CodeSignal's task (default 'object'),"
	echo -e "-i|--input-params <arg> \t- \t input parameters types and names from CodeSignal's task method signature (default 'object o')."
	echo -e "\nREADME.md related commands:"
	echo -e "-td|--task-difficulty <arg> \t- \t difficulty of given task (Easy|Medium|Hard) that will be put into README.md file for project ('Medium' by default),"
	echo -e "-tt|--task-type <arg> \t\t- \t type of given task ('Codewriting' by default),"
	echo -e "-tp|--task-points <arg> \t- \t CodeSignal points for resolving given problem ('0' by default),"
	echo -e "-tdesc|--task-description <arg> - \t description of given task ('TODO' by default)."
	echo -e "\nOther commands:"
	echo -e "-f|--framework <arg> \t\t- \t framework to be used in both of classlib and xunit projects ('netcoreapp2.1' by default)."
	echo -e "\nExample usage:"
	
	echo -e "\n\tbash createProject.bash -p 'isLucky' -t 'ShouldBeLucky'"
	echo -e "\tbash createProject.bash -p 'digitRootSort' -t 'ShouldSortCorrectly' -r 'int[]' -i 'int[] a'"
	echo -e "\tbash createProject.bash -p 'constructArray' -t 'ShouldContainItemsInGivenOrder' -r 'int[]' -i 'int size'  
		-td 'Medium' -tt 'Codewriting' -tp '1000' -tdesc 'Given an integer...'"
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
		TASK_DIFFICULTY="Medium"
	fi
	
	if ! [ -n "${TASK_TYPE+x}" ]
	then
		TASK_TYPE="Codewriting"
	fi
	
	if ! [ -n "${TASK_POINTS+x}" ]
	then
		TASK_POINTS="0"
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
	# If solution is a git repository
	if git rev-parse --git-dir > /dev/null 2>&1; then
		if ! [ $(git diff-index --quiet HEAD) ]; then
			echo "Git index is not empty."
			git status
			if [ $(confirm 'Do you want to hard reset to HEAD commit?') == 'y' ]; then
				git reset --hard HEAD
			fi
		fi
	
		git checkout master

		if ! [ $(git branch -r | grep -q "${PROJECT_NAME}") ]; then
			git checkout -b "${PROJECT_NAME}"
		else
			git checkout "${PROJECT_NAME}"
		fi
	fi
	
	# Create project library with given framework.
	dotnet new classlib -f "${FRAMEWORK}" -n "${PROJECT_NAME}"
	cd "${PROJECT_NAME}/"
	
	# Removing unnecessary using statements.
	sed -i "s/using System;//" "Class1.cs"
	
	# Change class name
	sed -i "s/Class1/${CLASS_NAME}/" "Class1.cs"
	
	sed -i "s/    {/    {\n        public static ${RETURN_TYPE} ${METHOD_NAME}(${INPUT_PARAMS}) {\n            return (${RETURN_TYPE}) new object();\n        }/" "Class1.cs"
	# Change root lib class file name
	mv "Class1.cs" "${CLASS_NAME}.cs"
	
	# Generate README.md markdown file
	touch "README.md"
	echo -n "![difficulty_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/difficulty_${TASK_DIFFICULTY,,}.png) **${TASK_DIFFICULTY}** &emsp; " >> "README.md"
	echo -n "![difficulty_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/type.png) **${TASK_TYPE}** &emsp; " >> "README.md"
	echo -e "![difficulty_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/points.png) **${TASK_POINTS}**\n" >> "README.md"
	
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
            yield return new object[] {  }; // ${INPUT_PARAMS}
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
	sed -i "s/        {/        {\n        \/\/ Arrange\n\n        \/\/ Act\n        ${RETURN_TYPE} result = ${CLASS_NAME}.${METHOD_NAME}($(getParamNames));\n\n        \/\/ Assert\n        Assert.Equal(expectedResult, result);/" UnitTest1.cs

	mv "UnitTest1.cs" "${CLASS_NAME}Test.cs"
	dotnet build
	dotnet run
	
	cd "../"
	# Add both projects into solution.
	dotnet sln CodeSignal.sln add "${PROJECT_NAME}"
	dotnet sln CodeSignal.sln add "${PROJECT_NAME}.Tests"

	if git rev-parse --git-dir > /dev/null 2>&1; then
		git add *
		git commit -m "${PROJECT_NAME} - generate from template"
	fi
}

function getParamNames() {
	# Get parameters names without types
	# eg. int a, int[] b, string c, object d => a,b,c,d
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