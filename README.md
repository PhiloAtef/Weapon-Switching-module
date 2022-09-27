# Weapon switching behaviour in unity
## _a documentation_

This is an attempt at writing a documentation to the mini-project I was assigned.

## Introduction

The project's idea was to create a weapon switching behaviour using given assets as part
of an assesment for a potential position. In this Readme, you will be provided with documentation
for such project.

## Used assets and Tech

- [mixamo.com](https://www.mixamo.com) - Free animation for the weapon switch
- [Unity store assets](https://assetstore.unity.com/packages/3d/characters/humanoids/fantasy/battle-wizard-poly-art-128097) - The assets provided at the start that include character/weapon meshes and materials
- Unity - self explanatory

## Installation

Simply download the file from the google drive and launch the solution. 
The assets should be found in **/interview task/Assets/scene with the required behaviour**
The main scene to play is inside the scene folder.
![location.png](https://i.postimg.cc/1415sVrV/location.png)

## Usage
```sh
press 'r' to initiate the animation switch
```

## The approach 

At first, My main issue was how to make it appear believable. I wanted it to at least look professional (_the weapon switching_) and so I used a free animation from the website maximo. 
After that, I had to rig the animation to the mesh. then I had to change the hierarchy so that the weapon meshes are children of the **ring finger** so that when the character moved the weapon would move as well. 

![hierarchy](https://i.postimg.cc/VkvrgpkJ/hierarchy.png)

And so, with all the parts set it came time to animate it. I made a very basic animator controller that will switch between `idle01` and `switch` with an ==isIdle== parameter to indicate if the animation is underway or not.
![animator](https://i.postimg.cc/WbrH9NXy/animator.png)
And made the code change the `isIdle` parameter to false when the ***r***  key is pressed

Now, to ACTUALLY switch the weapons, I had the script initialize with the three weapons
![weapons](https://i.postimg.cc/J7dQjf82/weapons.png)
Then, I created two Animation events. One that will fire off when the character has it's hand behind it's back 

![switchevent](https://i.postimg.cc/wT4TqkhJ/switchanimation.png)

```sh
This event fires off a function inside the script that sets the current equipped weapon to disabled and sets the next weapon on the list as enabled.
```

And one at the end of the last frame.

![roulleteWeapons](https://i.postimg.cc/SsVbZyd8/roullete.png)

```sh
This event fires off a function inside the script that sets what the current equipped weapon is and which weapon is due next.
```
## Known Issues and potential improvements
- importing the animation to the character mesh had some clipping issues and is fixable if the character mesh had a custom-made animation.
- there is some unremoved, commented out code left in the player anim controller. 
- game logic and animation logic are all inside one script file. code can be refactored.
- weapon cycling is made using rudimentary variable switching. possible improvement by implementing a linked list or a repeating queue. 
