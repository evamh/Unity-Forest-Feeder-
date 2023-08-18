# Forest Feeder

As you wander around this 3D forest, you may come across rabbits. Some are hopping from place to place, some are resting, others are chatting amongst themselves. There's one thing they all have in common - they're hungry!

Thankfully, you've come prepared with loads of carrots to feed these little critters. The aim of the game is to wander through the forest, taking in the sights and sounds, and feed the rabbits that you meet. Simply pressing a carrot allows the player to feed digital carrots in the 3D forest. 

This is a first-person perspective, un-timed game created in Unity. It uses an Adafruit Capacitive Touch sensor (MPR121) to link the physical world with the digital one via a carrot. 

<img src="https://git.arts.ac.uk/storage/user/650/files/3df609f2-7dd8-4440-b7f1-6befe5bee182" width="80%"> <img src="https://git.arts.ac.uk/storage/user/650/files/f6986756-c03f-4878-a309-4091b11c7fd3" width="80%"> <img src="https://git.arts.ac.uk/storage/user/650/files/23601cd3-f155-4b28-b853-6bca3579520d" width="80%"> <img src="https://git.arts.ac.uk/storage/user/650/files/0619dde6-6ef2-4963-af6b-9e5329dcdf5d" width="80%">


## Carrot controls

The carrot controller was built using an Adafruit Capacitive Touch sensor (MPR121) connected to an Arduino. A SerialCommunication script was created in Unity to open and listen to messages received from the serial port.

When Unity receives a signal from the port, it instantiates a prefab of the carrot object using the camera forward vector. 

<img src="https://git.arts.ac.uk/storage/user/650/files/3c52e58e-7ac7-4f9f-b182-9ce07f66c0ed" width="40%"> <img src="https://git.arts.ac.uk/storage/user/650/files/47c779ab-d5b6-4546-80e2-10062086cb59" width="40%">


Below is a quick video demonstrating how it works:

https://git.arts.ac.uk/storage/user/650/files/09cdcce2-143f-4c73-bbd8-5cb496736e4f




## Assets

### Blender

The carrot and benches were created using Blender, and exported into Unity as prefabs.

<img src="https://git.arts.ac.uk/storage/user/650/files/9b7247c1-4e8a-4de8-9107-4813c9379168" width="40%"> <img src="https://git.arts.ac.uk/storage/user/650/files/ca0fe105-6e3e-4b4a-aca5-8e8881c257c3" width="40%"> 

All other 3D assets were downloaded from the Unity Asset Store (links below). 


## Code

### Rabbit
These are the scripts attached to the rabbit prefab:
1. **RabbitAnimation** 

Controls the animation of the rabbit. There are two animators in the game, RabbitIdle and RabbitController. RabbitIdle keeps the rabbit in an idle state, whereas RabbitController allows the rabbit to switch between idle and running. This script is for the rabbits who are using the RabbitController. A coroutine toggles the animation state between Idle and Running every 5-10 seconds.
  
2. **RabbitMovement**

This is to allow the rabbits to rotate with the terrain by using the terrain normals.

3. **RabbitManager**

This script manages the carrot eating behaviour for each rabbit such as setting the target carrot and eating the carrot. 

### Game 

The Observer pattern is used to manage dropping the carrots and feeding the rabbits via UnityEvents. 

1. **CarrotRabbitPairManager**

This script creates a new UnityEvent called fedRabbit which is invoked when a rabbit successfully eats a carrot. The main method of this script is FindNearestRabbit(), which takes a newly created carrot instance and uses a Physics.OverlapSphere object to find the nearest collisions. If there is a rabbit in this collisions array that has not yet eaten, it takes the carrot as its target carrot and is fed. The fedRabbit event is invoked which updates the score and plays a sound effect. 

2. **CarrotFeeder** 

This script instantiates new carrots via the DropCarrot() method, which is called either by clicking the mouse or when the serial port receives a message (i.e. using the carrot connected to the capacitive touch sensor). This script also defines a new UnityEvent carrotDropped which is invoked when carrots are dropped, including playing a sound effect and checking whether there are any rabbits in the area.

The current player position and camera's forward vector are used to position the newly created carrot.

3. **FPC**

This is a simple first person controller which uses the 'W, A, S, D' or arrow keys to move, 'space' to jump and the mouse to look left/right. The movement speed, jump speed and mouse sensitivity are configurable. 

4. **ScoreManager**

This script subscribes to the CarrotRabbitPairManager's fedRabbit event and updates the score if the player has fed a new rabbit. It also keeps track of the total number of rabbits in the scene and the total number of rabbits fed, updating the TextMesh object with the score each time. If the player has fed all the rabbits, it also displays this to the screen. 

### Player Controls
1. **SerialCommunication**

This script establishes a simple serial communication between the serial port and Unity. If it receives the character 'a' (which is sent via the Arduino when the sensor is touched), it calls the DropCarrot() function defined in the CarrotFeeder script.

2. **ClickBehaviour**

This script simply checks for mouse clicks and calls the DropCarrot() function when that happens. 

### Audio
1. **AudioCarrotDrop**

This script subscribes its PlayAudio() function to the carrotDropped event to play a sound effect whenever a carrot is dropped to the ground.

2. **AudioPoint**

This script subscribes its PlayAudio() function to the fedRabbit event to play a sound effect whenever a rabbit has been fed.

5. LakeSounds

This script plays a water sound as the player gets closer to a lake. It calculates the distance between the player and the lake, gradually increasing the volume of the water as the player gets closer to it. It does this by using the InverseLerp function. 

This script is attached to the LakeNoise gameObject which is saved as a prefab in order to easily attach it to the three lake objects. 


## Terrain and environment design

This game initially started off as a fun project to test out Unity's terrain building features. I began by creating the terrian, adjusting the height map to give it hills, and painting on textures (such as the grass texture and the roads). Next I added details such as trees, grass and flowers. 

<img src="https://git.arts.ac.uk/storage/user/650/files/45abde90-bda0-438d-8c22-6d018efbd973" width="45%">

<img src="https://git.arts.ac.uk/storage/user/650/files/91bbcc92-7d33-401c-afce-2d1f67857415" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/4a722257-8db6-419e-aaa2-649fe4845905" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/7debf805-c000-4535-85d1-359fa295e0c3" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/b3b05407-713e-4b64-963a-7d7d8543861a" width="45%"> 

As I was creating the landscape, I was inspired to create mountains as well. On one edge of the landscape, I increased the height substantially to create mountain peaks. I painted snow at the top, and a rocky texture on the sides.

<img src="https://git.arts.ac.uk/storage/user/650/files/a426b4fa-0f40-46bf-b51d-494a686cc314" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/b9b6966f-2316-443d-ab65-97fc985e1878" width="45%"> 


I also added lakes to the scene by carving out the terrain and placing a plane with a transparent, pale blue material on it. To make the scene more immersive, audio of a stream plays as the player advances towards the lakes. 

<img src="https://git.arts.ac.uk/storage/user/650/files/67cfad96-9755-4b35-95e8-07c7009c78bd" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/5e43ac33-c1cd-4f04-9baa-01d5afde34ff" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/0b2012f6-b381-49ca-be09-b83003ce6388" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/c978d3a7-2401-4b43-9af3-4ba80caeaa00" width="45%"> 

Finally, I added in extra details using assets created in Blender and downloaded from the Unity Asset Store. I placed these around the forest to create areas for the player to stumble upon while exploring.

<img src="https://git.arts.ac.uk/storage/user/650/files/9f0a5717-e7aa-4f59-a0ea-ee0a52d168f2" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/338fa4b6-8499-4390-9ef0-8e153000decd" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/f1d9838f-fba0-4882-b7e3-f539795a01f8" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/c68b6b30-221c-45c0-a7af-bfbbb28aeb08" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/1517592f-768e-4c1e-90ad-0012dc17e57a" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/f7b7557b-664b-42e4-835e-133dfe803e2c" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/231f871d-a26a-4132-9cd0-298fa74e239b" width="45%"> <img src="https://git.arts.ac.uk/storage/user/650/files/6eba97fa-d92c-4641-947f-08e2f8bc16d1" width="45%"> 

## Video 

https://git.arts.ac.uk/storage/user/650/files/5a54ed1b-ebe0-4847-b2b5-7307138b58e4


## Unity Asset Store links


**Prefabs + Animations:**

1. Rabbit (https://assetstore.unity.com/packages/3d/characters/animals/white-rabbit-138709) 

2. Rope Bridge (https://assetstore.unity.com/packages/3d/environments/rope-bridge-3d-222563)
<br></br>

**Environment:**

1. Terrain layers (textures): https://assetstore.unity.com/packages/3d/environments/landscapes/terrain-sample-asset-pack-145808

2. Conifers: https://assetstore.unity.com/packages/3d/vegetation/trees/conifers-botd-142076 

3. Outdoor Ground textures: https://assetstore.unity.com/packages/2d/textures-materials/floors/outdoor-ground-textures-12555 

4. Grass/flowers: https://assetstore.unity.com/packages/2d/textures-materials/nature/grass-flowers-pack-free-138810 

5. Rocky Hills Environment: https://assetstore.unity.com/packages/3d/environments/landscapes/rocky-hills-environment-light-pack-89939 
<br></br>

**Audio:**

1. Ambience_Stream_Calm_Loop_Stereo (https://assetstore.unity.com/packages/audio/ambient/nature/nature-essentials-208227#content) 

2. Ambient Nature Outside (https://assetstore.unity.com/packages/audio/sound-fx/nature-sounds-pack-free-202076#content) 

3. Footstep Grass 02 (https://assetstore.unity.com/packages/audio/sound-fx/nature-sounds-pack-free-202076#content) 

4. Special Pop 2 (https://assetstore.unity.com/packages/audio/sound-fx/free-casual-pack-sfx-197054#content) 


