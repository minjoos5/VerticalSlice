# GDIM33 Vertical Slice
## Milestone 1 Devlog
### Complicating Factors
- One random tape to escape
- Player’s stamina

These factors will be implemented for the next milestone or assignment. They were excluded because of their complicating features. If the player picks any of the three cassette tapes, the cassette player will display the map. Press E to interact with the tape and Q to close the map window. There’s no stamina limit now, so players will be able to run freely. Press the space bar to run.


### Answer 1:
Visual script graph: Message


This scripting graph is connected to the message game object, which is the first item the player encounters. It lets the player know what they have to do first. The main functions of the message are:
- The player can pick up the message by clicking on it.
- If the player clicks it, the UI will show up.
- If the player presses Q after picking up, the game object and the UI are disabled. (won’t be shown the game again.)


In the graph, the Start node sets the game object active (true) to show the game object in the game first. The GetMouseDown node checks whether the isClicked variable is true or false. If the isClicked variable is false, the node runs SetActive(true) of the message UI. The OnKeyboardInput node (Press Q) checks whether the isClicked variable is true or false again. If the variable is false, the code won’t run. If the variable is true, it sets the UI and the game object to active (false), disabling two game objects. 

### Answer 2:

<img width="1000" height="1366" alt="188BB1AD-55B5-4AAD-A12C-D1ECFFCF89D9" src="https://github.com/user-attachments/assets/d6a74e7a-d005-48af-94c7-e930f036eb07" />



For my updated breakdown, I added the state machine graph with a brief explanation. My state machine currently has three different states: walking, chasing, and attacking. The state is decided based on the distance between the player and the NPC. As the distance between both of them gets closer, the state changes into walking → chasing → attacking. Each state has one method for playing the NPC's animation and the logic for the transition. In each state, the if statement and the “calculatedistance” method are calculated on update. Based on the calculation, the if statement decides the current state of the NPC and fires the event, changing the NPC’s animation smoothly.


This animation is related to the player’s death/active status. The UI shows a game-over screen when the player is attacked by the NPC. The UI screen will show up when the player’s collider collides with the NPC’s collider, whose current state is “attack.” Since the calculation is based on the distance between them, the game-over screen will show up, though the attack animation is not played. (This happens when the player collides with the NPC so fast.) The state machine is directly related to the gameover UI.

## Milestone 2 Devlog
### Answer 1:
Breakdown: implementation of random cassette tapes


! I implemented this feature before (prefab), but because it caused too many errors in the game, so I’m replacing it. !

1. Randomly spawn cassette tapes
  - Create three different cassettes with different names (1 true tape & 2 fake tapes)
  - Allocate each game object in the list of item scripts
  - The code will shuffle the list of locations (empty game objects that are located randomly around the map). The code was written for Milestone 1.
  - The items are located at one of the random spawn points in the map. For each tape, the Update method checks the current boolean value and updates it based on player interaction.
  - Put two different types of scripting graphs in each tape to ensure the UI game object's Boolean value.
2. Define the Boolean variable to trigger the interaction between the cassette tape and the correct cassette tape.
  - Boolean variable declared in the graph → checks the cassette status.
  - If the player picks up the correct cassette, the graph of the correct cassette will set the boolean value true.
  - Based on the Boolean value, the cassette player will play two different images.
    - The image of the map (correct tape)
    - The image of the glitch (fake tape)

   
### Answer 2:
The breakdown helped me a lot while I was working on Milestone 2, as I was able to create self-instructions and check my process against them. Although I prepared a diagram breakdown for Milestone 1, I couldn’t make clear connections between various game objects and their scripts. Thus, I had to reorganize most of the code and remove unnecessary scripts (graphs). The new breakdown was much easier to review and make revisions based on my current progress. If I’m doing this again, I want to improve the documentation and add a whiteboard to visualize the game objects and scripts, so I can check how the code is connected and how it works in the game. I think it would be better to add documentation for the shared variables or locator settings to help identify which variable is used at a specific point in the script.
### Answer 3:
<img width="1517" height="719" alt="screenshot milestone 2" src="https://github.com/user-attachments/assets/2b0c4d9a-79d6-423b-b7e0-02a3099332e9" />

The NPC.cs script includes a raycast for sight detection, a distance calculation method, and two boolean variables to control the NPC’s movement. These methods and variables are used in the scripting graph to trigger transitions between the NPC’s animations. On update, the NPC detects the player. If the player is detected by the NPC’s raycast, it will calculate the distance. Based on the distance between the player and the NPC, the proper animation will be triggered and show the transition between two different animations.
### Answer 4:
The Unity system I want checked is the NPC's Navmesh: the navigation AI of the NPC to roam around the map and find automatically. The Navmesh settings can be found in Window > AI > Navigation (obsolete)


## Milestone 3 Devlog
### Answer 1
#### **This shader can be found when the game starts. This shader displays with the dialogue panel.**
<img width="2878" height="1636" alt="Shader Graph" src="https://github.com/user-attachments/assets/bad786fc-77f1-48a9-99a7-fb1e5cbbdb47" />


- Lerp Time node:


    - The time graph looks like (sin+1)/2. This is because of the same reason as the week 8 in-class activity. When I just use the sine graph, the screen turns white, not leaving it black. Thus, I used the same equation to prevent the screen from becoming white due to a negative value.
 

- Lerp A node:


    - The Lerp node gets an A value from the URP sample buffer node, which in turn gets the full-screen color buffer.
 

- Lerp B node:


    - I put the white circle with black background texture on the sample texture 2D node. To ensure the shader effect displays on the screen, even as the 3D model changes in the background, I connected the screen position node to the UV value. I subtracted the white value from the image since I wanted the effect to show only the black glitches on the screen, like eye blinking. The random range node gets the min range value and the max range value with the seed (UV) node. It randomly selects a number between 0 and 10 based on the UV node. It multiplies the time node, which means it doesn’t repeat between -1 and 1 like sine and cosine nodes. It progresses infinitely. The fraction node keeps the glitch effects, maintaining its glitchy status, preventing getting too large a value from the multiply node. The dither node gets the fraction value and draws the pixelated texture on the screen position. It multiplies with the black background with a transparent circle in the middle, forming the glitchy effect with a transparent circle in the middle of the screen.
 

- The Lerp node combines the values from A and B together and prints the calculated value following the sine graph assigned to the T value. It connects to the base color fragment node and applies a blinking, glitchy effect to the screen.



### Answer 2
During my playtest, I got feedback on the game UI and the player’s collider. The playtesters wanted to see the maps multiple times or have better legends on the map. In addition, the player capsule’s thick collider made the player stuck between the walls when they were trying to avoid the NPC’s attack. Thus, I changed the map’s X icon to a key shape for better understanding and enabled the map to open multiple times by pressing the tab key. I also adjusted the collider’s size to prevent a wall-stuck situation. The booleans were modified to prevent escaping without using items.
### Answer 3
I added one more backroom for the gameplay loop. Also, I replaced the key with a crowbar. In this new map, the player needs to find the crowbar in the map and smash the door (E to interact) with it to escape from the final backroom. The NPC chases you more rapidly, too. One more dialogue will appear in the second stage to explain the simple direction alongside the message. The map won't be provided at the second level to increase difficulty compared to the first level.

## Final Devlog
### Answer 1
### Answer 2
### Answer 3
#### 3-1
#### 3-2
#### 3-3
## Open-source assets

[Backroom asset](https://sketchfab.com/3d-models/backrooms-1da6a7f2e0294ba9a4123f61244811a8)


[Backroom asset 2](https://sketchfab.com/3d-models/backrooms-another-level-429f3c9ea8024f5e9bb78f6649c7bd26)


[NPC Model](https://www.mixamo.com/#/?page=1&query=run&type=Motion%2CMotionPack)
- [Walk](https://www.mixamo.com/#/?page=1&query=walk&type=Motion%2CMotionPack)
- [Chase](https://www.mixamo.com/#/?page=1&query=fast+run&type=Motion%2CMotionPack)
- [Attack](https://www.mixamo.com/#/?page=1&query=stabbing&type=Motion%2CMotionPack)

Game items:
- [Cassette tape](https://sketchfab.com/3d-models/video-casette-c2069ccf3f4247b28c843e480da3118e)
- [Tape Player](https://sketchfab.com/3d-models/cassette-player-57f556902cf940699103696f1d95a19b)
- [Door](https://sketchfab.com/3d-models/door-wooden-old-9mb-77815b3a55504037aa4641eb9650e9de)
- [Key](https://sketchfab.com/3d-models/door-key-6c692bbf57364804a68d4a6477e788fa#download)
- [Knife](https://sketchfab.com/3d-models/utility-knife-b56f12426f9d42b6bbbd35726ddd69a3)
- [Crowbar](https://sketchfab.com/3d-models/crowbar-7601c4180b434ecab417122151e16f0a)
- [Glitch Image](https://pixabay.com/illustrations/glitch-noise-pixel-display-defect-2717634/)

SFX
- [Attack SFX](https://pixabay.com/sound-effects/film-special-effects-attack-sound-3-384911/)
- [Enemy Detected SFX](https://pixabay.com/sound-effects/film-special-effects-enemy-detected-103347/)
