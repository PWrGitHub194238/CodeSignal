![difficulty_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/difficulty_medium.png) **Medium** &emsp; ![type_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/type.png) **Codewriting** &emsp; ![points_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/points.png) **2000**

[Jumping Jimmy](https://app.codesignal.com/challenge/6nrk2rLGZRkH9gDZ5) is back, and he's ready to tackle a new tower!

He has the same goal as before (keep jumping as high as possible until he gets to the top or can't jump any higher), but this tower is a little different from the last one - some of the floors can affect Jimmy's jump height!

More specifically, there are **power floors** (which increase his jump height by 1), and **poison floors** (which decrease his jump height by 1). The indices of these floors are represented by the power and poison arrays. **Each index is 0-based, and does not include the initial floor that Jimmy begins on.**

Given tower (an array representing the gaps between each pair of consecutive floors), as well as power, poison, and jumpHeight, your task is to find the height of the highest floor in the tower that Jimmy will be able to reach.

Notes:

* Both power and poison are sorted in ascending order, with no repeat elements.
* Elements of power and poison are mutually exclusive - there are no floors that have both attributes.
