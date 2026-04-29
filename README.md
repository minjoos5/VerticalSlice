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
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets

[Backroom asset](https://sketchfab.com/3d-models/backrooms-1da6a7f2e0294ba9a4123f61244811a8)


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

SFX
- [Attack SFX](https://pixabay.com/sound-effects/film-special-effects-attack-sound-3-384911/)
