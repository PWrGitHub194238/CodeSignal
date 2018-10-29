![difficulty_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/difficulty_medium.png) **Medium** &emsp; ![type_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/type.png) **Codewriting** &emsp; ![points_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/points.png) **3000**

You are given a recursive notation of a binary tree: each node of a tree is represented as a set of three elements:

* value of the node;
* left subtree;
* right subtree.

So, a tree can be written as `(value left_subtree right_subtree)`. It is guaranteed that `1 ≤ value ≤ 10`<sup>`9`</sup>. If a node doesn't exist then it is represented as an empty set: `()`. For example, here is a representation of a tree in the given picture:

`(2 (7 (2 () ()) (6 (5 () ()) (11 () ()))) (5 () (9 (4 () ()) ())))`

![example_tree](https://github.com/PWrGitHub194238/CodeSignal/blob/master/TreeBottom/tree.png)

Your task is to obtain a list of nodes, that are the most distant from the tree root, in the order from left to right.

In the notation of a node its value and subtrees are separated by exactly one space character.