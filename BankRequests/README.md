![difficulty_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/difficulty_medium.png) **Medium** &emsp; ![type_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/type.png) **Codewriting** &emsp; ![points_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/points.png) **2000**

You've been asked to program a bot for a popular bank that will automate the management of incoming requests. There are three types of requests the bank can receive:

* `transfer i j sum`: request to transfer `sum` amount of money from the `i`<sup>`th`</sup> account to the `j`<sup>`th`</sup> one;
* `deposit i sum`: request to deposit `sum` amount of money in the `i`<sup>`th`</sup> account;
* `withdraw i sum`: request to withdraw `sum` amount of money from the `i`<sup>`th`</sup> account.

Your bot should also be able to process invalid requests. There are two types of invalid requests:

* invalid account number in the requests;
* deposit / withdrawal of a larger amount of money than is currently available.

For the given list of `accounts` and `requests`, return the state of accounts after all requests have been processed, or an array of a single element `[-<request_id>]` (please note the minus sign), where `<request_id>` is the 1-based index of the first invalid request.