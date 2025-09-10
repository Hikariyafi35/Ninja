Features
•	State-based Movement: Move the ninja using the A/D keys or the Left/Right Arrow keys.
•	Jumping: Press the Jump key (configured as Jump in Unity's Input Manager) to make the ninja jump.
•	Attacking: Use the Left Mouse Button (LMB) to shoot Kunai, configured as Fire1 in the Input Manager.
•	Attack Mode: Use the Right Mouse Button (RMB) to enter AttackState, allowing you to shoot Kunai in attack mode. This is mapped as Fire2 in the Input Manager.
•	Health System: The ninja's health decreases upon taking damage, and the game transitions to DieState when health reaches zero.
•	UI Controls: Includes buttons for Restart and Exit.
Controls
•	A/D or Left/Right Arrow Keys: Move the ninja left and right. These actions are mapped in Unity's Input Manager.
•	Jump: Use the Jump key (configured as Jump in Unity's Input Manager) to make the ninja jump.
•	Left Mouse Button (LMB): Shoot Kunai. This is mapped as Fire1 in the Input Manager.
•	Right Mouse Button (RMB): Start AttackState. When in AttackState, you can shoot Kunai. This is mapped as Fire2 in the Input Manager.
•	F: Decrease health (trigger HurtState).
How to Run
1.	Clone this repository or download the project.
2.	Open the project in Unity.
3.	Press Play in Unity to test the game.
________________________________________
In this version, I’ve kept the Input Manager references to ensure users know how to configure inputs. The game uses the Input Manager to map actions like movement, jump, attack, and hurt, using standard input names such as Jump, Fire1, and Fire2. Let me know if you need any more adjustments!
