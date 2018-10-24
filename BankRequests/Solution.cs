using System;

namespace BankRequests
{
    public class Solution
    {
        private const char REQUEST_DELIMITER = ' ';
        private const int MAP_ACCOUNT_NUMBER_TO_IDX = -1;
        private const int MAP_ACCOUNT_IDX_TO_NUMBER = 1;


        public enum BankRequestEnum { TRANSFER, DEPOSIT, WITHDRAW };

        public static int[] BankRequests(int[] accounts, string[] requests)
        {
            BankRequestEnum requestType;
            string[] requestArgs;
            int numberOfRequests = requests.Length;

            int requestNumber = 0;
            try
            {
                while (requestNumber < numberOfRequests)
                {
                    (requestType, requestArgs) = ParseRequest(request: requests[requestNumber]);
                    switch (requestType)
                    {
                        case BankRequestEnum.TRANSFER:    // i j sum => sum from i'th account to j'th
                            ParseTransferRequest(validAccounts: accounts, requestDetails: requestArgs);
                            break;
                        case BankRequestEnum.DEPOSIT: // i sum => deposit sum to account i'th
                            ParseDepositRequest(validAccounts: accounts, requestDetails: requestArgs);
                            break;
                        case BankRequestEnum.WITHDRAW: // i sum => withdraw sum from account i'th
                            ParseWithdrawRequest(validAccounts: accounts, requestDetails: requestArgs);
                            break;
                    }
                    requestNumber += 1;
                }
            }
            catch (InvalidTransferException)
            {
                return ThrowRequestParsingError(requestNumber: requestNumber);
            }
            return accounts;
        }

        private static void ParseTransferRequest(int[] validAccounts, string[] requestDetails)
        {
            (int ithAccount, int jthAccount, int sum) = ParseTransferRequestArgs(requestDetails: requestDetails);

            if (AccountExists(validAccounts: validAccounts, accountToCheck: ithAccount)
                && AccountExists(validAccounts: validAccounts, accountToCheck: jthAccount)
                && AccountHasSufficientBalanceForOutgoingTransfer(validAccounts: validAccounts, accountToCheck: ithAccount, accountMin: sum))
            {
                TransferMoney(validAccounts: validAccounts, fromAccount: ithAccount, toAccount: jthAccount, toBeTransfered: sum);
            }
            else
            {
                throw new InvalidTransferException();
            }
        }

        private static (int ithAccount, int jthAccount, int sum) ParseTransferRequestArgs(string[] requestDetails)
        {
            return (int.Parse(requestDetails[0]), int.Parse(requestDetails[1]), int.Parse(requestDetails[2]));
        }

        private static void TransferMoney(int[] validAccounts, int fromAccount, int toAccount, int toBeTransfered)
        {
            validAccounts[fromAccount + MAP_ACCOUNT_NUMBER_TO_IDX] -= toBeTransfered;
            validAccounts[toAccount + MAP_ACCOUNT_NUMBER_TO_IDX] += toBeTransfered;
        }

        private static void ParseDepositRequest(int[] validAccounts, string[] requestDetails)
        {
            (int ithAccount, int sum) = ParseDepositRequestArgs(requestDetails: requestDetails);

            if (AccountExists(validAccounts: validAccounts, accountToCheck: ithAccount))
            {
                DepositMoney(validAccounts: validAccounts, onAccount: ithAccount, toBeDeposited: sum);
            }
            else
            {
                throw new InvalidTransferException();
            }
        }

        private static (int ithAccount, int sum) ParseDepositRequestArgs(string[] requestDetails)
        {
            return (int.Parse(requestDetails[0]), int.Parse(requestDetails[1]));
        }

        private static void DepositMoney(int[] validAccounts, int onAccount, int toBeDeposited)
        {
            validAccounts[onAccount + MAP_ACCOUNT_NUMBER_TO_IDX] += toBeDeposited;
        }

        private static void ParseWithdrawRequest(int[] validAccounts, string[] requestDetails)
        {
            (int ithAccount, int sum) = ParseWithdrawRequestArgs(requestDetails: requestDetails);

            if (AccountExists(validAccounts: validAccounts, accountToCheck: ithAccount)
                && AccountHasSufficientBalanceForOutgoingTransfer(validAccounts: validAccounts, accountToCheck: ithAccount, accountMin: sum))
            {
                WithdrawMoney(validAccounts: validAccounts, fromAccount: ithAccount, tobeWithdrawed: sum);
            }
            else
            {
                throw new InvalidTransferException();
            }
        }

        private static (int ithAccount, int sum) ParseWithdrawRequestArgs(string[] requestDetails)
        {
            return (int.Parse(requestDetails[0]), int.Parse(requestDetails[1]));
        }

        private static void WithdrawMoney(int[] validAccounts, int fromAccount, int tobeWithdrawed)
        {
            validAccounts[fromAccount + MAP_ACCOUNT_NUMBER_TO_IDX] -= tobeWithdrawed;
        }

        private static bool AccountHasSufficientBalanceForOutgoingTransfer(int[] validAccounts, int accountToCheck, int accountMin)
        {
            return validAccounts[accountToCheck + MAP_ACCOUNT_NUMBER_TO_IDX] >= accountMin;
        }

        private static bool AccountExists(int[] validAccounts, int accountToCheck)
        {
            return 0 < accountToCheck && accountToCheck < validAccounts.Length + MAP_ACCOUNT_IDX_TO_NUMBER;
        }

        // Splits a REQUEST_DELIMITER separated request string into two parts: 
        // type of request and it's variable length array of arguments.
        private static (BankRequestEnum requestType, string[] requestArgs) ParseRequest(string request)
        {
            return (Enum.Parse<BankRequestEnum>(request.Substring(0, request.IndexOf(REQUEST_DELIMITER)).ToUpper()),
                request.Substring(request.IndexOf(REQUEST_DELIMITER) + 1).Split(REQUEST_DELIMITER));
        }

        private static int[] ThrowRequestParsingError(int requestNumber)
        {
            return new int[] { -1 * (requestNumber + 1) };
        }

        [Serializable]
        private class InvalidTransferException : Exception
        {
        }
    }
}
