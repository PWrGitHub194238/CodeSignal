namespace BankRequests
{
    public class Solution
    {
        public static int[] bankRequests(int[] accounts, string[] requests)
        {
            string requestType;
            string[] requestArgs;
            int maxAccountNumber = accounts.Length + 1;
            int numberOfRequests = requests.Length;
            string request;

            int ithAccount;
            int jthAccount;
            int sum;
            bool ok;
            int deposit = 0;
            for (int i = 0; i < numberOfRequests; i++)
            {
                request = requests[i];
                requestType = request.Substring(0, request.IndexOf(' '));
                requestArgs = request.Substring(requestType.Length + 1).Split(' ');
                ok = false;
                switch (requestType)
                {
                    case "transfer":    // i j sum => sum from i'th account to j'th
                        ithAccount = int.Parse(requestArgs[0]);
                        jthAccount = int.Parse(requestArgs[1]);
                        sum = int.Parse(requestArgs[2]);

                        if (0 < ithAccount && ithAccount < maxAccountNumber)
                        {
                            if (0 < jthAccount && jthAccount < maxAccountNumber)
                            {
                                if (accounts[ithAccount - 1] >= sum)
                                {
                                    accounts[ithAccount - 1] -= sum;
                                    accounts[jthAccount - 1] += sum;
                                    ok = true;
                                }
                            }
                        }
                        if (!ok)
                        {
                            return new int[] { -1 * (i + 1) };
                        }
                        break;
                    case "deposit": // i sum => deposit sum to account i'th
                        ithAccount = int.Parse(requestArgs[0]);
                        sum = int.Parse(requestArgs[1]);

                        if (0 < ithAccount && ithAccount < maxAccountNumber)
                        {
                            accounts[ithAccount - 1] += sum;
                            ok = true;
                        }

                        if (!ok)
                        {
                            return new int[] { -1 * (i + 1) };
                        }
                        break;
                    case "withdraw": // i sum => withdraw sum from account i'th
                        ithAccount = int.Parse(requestArgs[0]);
                        sum = int.Parse(requestArgs[1]);

                        if (0 < ithAccount && ithAccount < maxAccountNumber)
                        {
                            if (sum <= accounts[ithAccount - 1])
                            {
                                deposit += sum;
                                accounts[ithAccount - 1] -= sum;
                                ok = true;
                            }
                        }
                        if (!ok)
                        {
                            return new int[] { -1 * (i + 1) };
                        }
                        break;
                }
            }
            return accounts;
        }
    }
}
