### Worked on this project with two others, but will only include parts I have done.
- The project was an RPG and even though it was done for school, it was by no means complete for the world at large after about six months of work.
- The Unity 5 engine was used with most of the code being done in C#.
- Google Sheets was used for the Database, due to lack of being able to get much more than that. The team wanted a real Database, but this helped in a way of being able to outsource some of the creation of items and characters. Found a Google Script to parse sheets into JSONs and a few Google Scripts were created to make sure the data in each sheet was within our required parameters.
------------
### I personally worked on the code of
- Underlying Data Structure
	- Stats
		- could be used in almost any game with slight modifications
		- Included, but not limited to Player, NPCs, Enemies, Items, etc...
		- The way the Player character looked was part of this
	- Save/Load ability
		- Players location in the game story and pysical location
	- JSON parser
		- Stats, Story Dialog and Other Dialog
- Battle System
	- Start of Battle
		- Location of Charaters and Enemies
		- Order of Initial Order to Attack
		- Any advantage or disadvantage to the player
	- Battle Unfolding
		- Order of attacks based on the following
			- Inital Order to Attack
			- Speed Modifier
		- Menu for Attacking (very basic)
		- Damage and Resistance
			- Physical based
			- Magical based
		- How the Battle looks to be taking place (very basic)
	- End of Battle
		- Rewards to player
			- Winning - Experience, Money, Items
			- Losing - Reload from last save
- Google Sheets (I sadly do not have access any more)
	- Creation/Modifications of almost all sheets used
	- Scripts to make sure the JSON Parse did not fail
------------
I most likely will not go back to this code and really modifiy it. My other intrests sadly do not leave me with enough time to make this better.<br>
I do think that it could be used by others as a basis to their projects.
