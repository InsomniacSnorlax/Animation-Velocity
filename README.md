# Animation-Velocity
Control animations via velocity of animated entity

This small project was inspired by a reddit post which can be found here
https://www.reddit.com/r/Unity3D/comments/tya6k1/make_your_npc_feel_move_alive_by_connecting_its/

The effects are more pronounced with in Mohd Ark's version as they included more animations for blending as well as speed.

To begin first we would need to set up 2 float variables within a new animator which will control how we interact with the animations. These 2 floats are Speed and Angle, in which Speed can be used to add more animations representing speed if need be. The Angle will control the animation played i.e an angle of 90 velocity will play a left walk animation. Also to achieve control of these two variables we will be splitting the walking animations to their own blend tree controlled by angle as seen in the picture below

![Animator Setup](https://user-images.githubusercontent.com/94978222/166681163-7c263213-e72b-45ec-9d62-71fdaa0e9f68.png)

The Idle remains outside the secondary blend tree as it does not need to be controlled by angle. Moving forward, the image below will give you a rough idea of the angle and animations needed to achieve the desired effect and can be altered if more or less animations are being used.

![Blend Tree Setup](https://user-images.githubusercontent.com/94978222/166681112-a55d72c8-de19-4e5e-9c40-3e9c0c9c0659.png)

Why use angle instead of horziontal and vertical? Well the rotation of the entity/character can be an issue as velocity ditacts direction however, it does not account for the rotation but using the image below, the idea of angles can be visualised easier.

![Desired Effect](https://user-images.githubusercontent.com/94978222/166681171-355c0503-a424-4f86-9c7c-8f1926222f69.png)

Now to the code, pretty simple enough we get the animator in awake and calculate both Speed and Angle to pass to the animator paramaters as Animator.SetFloat(). For Speed we take the velocity magnitude which is simple enough and the angle we take the entity transform forward as well as the desired movement direction with the agent.velocity, turning both into a float angle with eulerAngles. 

In the code I provided, we use the Nav Mesh Agent and a left mouse click to set the destination hence the velocity being calculated (I do believe I did it the other way around but too lazy to change since it aint broken so why bother fixing it).

![Update](https://user-images.githubusercontent.com/94978222/166681179-b98fa5dd-7693-497c-82f9-aa1106abe082.png)
