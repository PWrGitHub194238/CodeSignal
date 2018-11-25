![difficulty_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/difficulty_hard.png) **Hard** &emsp; ![type_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/type.png) **Codewriting** &emsp; ![points_icon](https://github.com/PWrGitHub194238/CodeSignal/blob/master/points.png) **4000**

This game is not tile-based, but for the sake of complexity, we will assume it is.

You're happy with your [water level scripts](https://app.codesignal.com/challenge/3W5Ez99ZvdyHzyMhv) for Donkey Kong Country (DKC). Now you want to challenge yourself by working on land. To start off, you select a basic hack to work with. There's one key difference working on land: you have to jump!

Your biggest problem is overcoming acceleration. Fortunately for you, you don't have to worry about that as in this hack the creator took out all acceleration. For this, you need to upgrade your map. Luckily, [DKCRE](http://www.dkc-atlas.com/forum/viewtopic.php?f=57&t=1532) lets you export various maps. A sample map looks like:

```
[
"######################################", 
 "                                      ", 
 "                                      ", 
 "                          ########    ", 
 "                          ########    ", 
 "               ####       ########    ", 
 "           #######################   E", 
 "S          ###########################", 
 "#####  ###############################", 
 "#####  ###############################"
]
```

**Legend**  
```'S'``` - Start location (equal to ```' '``` once you move)  
```'E'``` - End (the goal you're aiming for)  
```' '``` - Free space. You can move through these  
```'#'``` - Walls/Ground. You can't pass through these vertically or horizontally.

**Rules**

* Horizontally, you can move at most 3 tiles in one move / jump.
* Vertically, you can move at most 3 tiles in the upward direction.
* There's no acceleration, but there is still gravity! No matter what move you make, if ground is not immediately below you, you will fall until you hit the ground.
* You move vertically first then horizontally (then maybe fall vertically, depending on what's beneath you).
* You're allowed to jump out of the map from the top as long as you eventually land back in the map. You are not allowed to exit from the bottom (the bottom of the stage should be treated as solid ground).
* **It's guaranteed that the start (```'S'```) and end (```'E'```) will be on solid ground.**

Given ```stage``` in the form of an array of strings, return the least amount of moves to reach the end. Return a ```-1``` if it is not possible to reach the end.
