Feel The Attraction
ICS 168 Project 1: Multiplayer Co-op Game

Team Members:
Crystal Agerton
Isaac Men
Richard But
Kevin Chao


Set-up Instructions:
   -Click the "Feel The Attraction.exe" file
   -If that does not work
     -Open project in Unity
     -Open the "Title Screen" scene
     -For best experience, set game resolution to 9:16
   -Networked set-up
     -Click the "Play Networked" button
     -One player makes the server by entering a name under
     "CREATE A GAME" and pressing "CREATE"
     -The other player will join this game by accessing
     it via the "LIST SERVERS" button.

Gameplay Instructions
   -Dodge chickens by coordinating states and repelling
    and attracting each other
   -States
     -Neutral: moves back to middle, cannot attract or repel
     -Attract: magnets move towards each other, 
               requires opposite color on top
     -Repel: magnets move opposite each other, 
               requires same color on top
   -Local Version
     -Player 1 (left)
	- WASD keys
	- S: Neutral
	- A: Red on top
	- D: Blue on top
     -Player 2 (right)
	- Arrow keys
	- Down: Neutral
	- Left: Red on top
	- Right: Blue on top
   -Networked Version
     -Player 1 (left) & Player 2 (right)
	- Arrow Keys
	- Works like Player 1 in Local Version


Known Bugs:
   -Networked version may crash if game ends
   -Chickens may not be synchronized across networked version
   -Restart networked version if screen goes black