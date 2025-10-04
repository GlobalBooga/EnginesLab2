# EnginesLab2
 
Alex Anastasakis
100892202

Title: Shoot the things!
This is a simple 2D game where you shoot shapes that are trying to swarm you.
The game loop is simple: pick a projectile, shoot the things!

This project implements 2 factories..

### Factory Number 1: The "Enemy" Spawner

<img width="1090" height="336" alt="image" src="https://github.com/user-attachments/assets/d9bb6ff7-eaec-4a8f-94ee-1607cec7c7ea" />

This is a simple implementation that just randomly spawns random enemies at random places. There are two types of enemies: triangles and circles.
##### Triangle:
- spawns 2 circles when shot

##### Circle:
- jumps when hit and has 3 health points

Both of these enemy types are children of the Enemy class and override its OnHit() function.
 
An enemy spawner makes the an excellent example of a factory design pattern because the spawner shouldn't care about what its spawning - just that it's spawning a gameobject.


### Factory Number 2: The Projectile Spawner

<img width="941" height="350" alt="image" src="https://github.com/user-attachments/assets/7f9a01a8-cc92-41b4-adf5-b9832b477b47" />

This is another simple implementation that spawns projectiles to shoot them. There are two types of projectiles we can use: a dart, and lightning.
##### Dart:
- shoots a fast dart
- gets destroyed on hit

##### Lightning:
- uses a raycast to determine hits
- is a line trace component that renders a repeating pattern of lightning
- destroys itself after a short delay

Both of these projectiles types are children of the Projectile class and override its Launch() function.
This is a decent example of the factory pattern because we don't know what kind of projectile we might be shooting. 
However, while this makes for a good prototype, in a larger scale game with a lot of projectiles flying at once, I would probably go for an object pooling method.
