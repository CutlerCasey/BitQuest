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
	- Save/Load process
		- Players location in the game story and pysical location
	- JSON parser
		- Stats, Story Dialog and Other Dialog
- Login Menu
	- This ultimatily was part of the load process or new game
		- Character Creation
			- There are four Predefined classes
			- You can change the stats to whatever
- Battle System
	- Start of Battle
		- Location of Charaters and Enemies
		- Order of Initial Order to Attack
		- Any advantage or disadvantage to the player
	- Battle Unfolding
		- Order of attacks based on the following
			- Inital Order to Attack
			- Agility Modifier
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
I most likely will not go back to this code and really modifiy it. My other intrests sadly do not leave me with enough time to make this better.<br><br>
I do think that the code could be used by others as help for their projects, but that they would need to look up tutorials on Unity. I know I would have to look at them again, if I were to go back to this project.

------------
I have included a .7z of the game
- If you choose to play it is a 2d sprit RPG
- Only the story for the character creation exist plus some other Dialog
	- There was almost a 50 page story that was written, but maybe the first 1/8 of a page was included
- You can get into battle, but it is meant to be won no matter how bad you set up your stats, if I remember correctly
	- To this there are four classes, but you can make your stats pretty much however you want
	- Agility and Strength are the best stats, but the eneries are week
------------
Upload 1/14/2019
