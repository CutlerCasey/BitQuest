using UnityEngine;
using System.Collections;

//could do this all in seperate scripts, but easier to find it this way
//all of fhis can be changed later based on what we feel, besides the BaseCharacterClass
//example we do not like Warrior we can just change the name and other things later
//for the player, but we will want more for npcs/monsters

//Base
public class BaseClass : BaseCharacterClass
{
    public BaseClass()
    {
        CreatureName = "Base";
        CreatureDescription = "Nothing special here.";
        CharacterClassEnum = CharacterClasses.BASE;
        RecStr = 3;
        RecAgi = 2;
        RecSta = 3;
        RecInt = 3;
        RecVit = 4;
        RecSpi = 2;
        SpriteModel = "Base Male";
    }
}
//warrior
public class BaseWarriorClass : BaseCharacterClass {
    public BaseWarriorClass() {
        CreatureName = "Warrior";
        CreatureDescription = "Defense or raging damage is their styles.";
        CharacterClassEnum = CharacterClasses.WARRIOR;
        RecStr = 9;
        RecAgi = 2;
        RecSta = 8;
        RecInt = 3;
        RecVit = 9;
        RecSpi = 2;
        SpriteModel = "Base Male";
    }
}
//rouge
public class BaseRougeClass: BaseCharacterClass {
    public BaseRougeClass() {
        CreatureName = "Rouge";
        CreatureDescription = "Stealing, killing, and hiding is their game.";
        CharacterClassEnum = CharacterClasses.ROUGE;
        RecStr = 7;
        RecAgi = 5;
        RecSta = 6;
        RecInt = 4;
        RecVit = 5;
        RecSpi = 6;
        SpriteModel = "Base Male";
    }
}
//White Mage
public class BaseWmageClass: BaseCharacterClass {
    public BaseWmageClass() {
        CreatureName = "White Mage";
        CreatureDescription = "Changing the course of battle for their team.";
        CharacterClassEnum = CharacterClasses.WMAGE;
        RecStr = 5;
        RecAgi = 1;
        RecSta = 6;
        RecInt = 7;
        RecVit = 4;
        RecSpi = 10;
        SpriteModel = "Base Female";
    }
}
//Black Mage
public class BaseBMageClass: BaseCharacterClass {
    public BaseBMageClass() {
        CreatureName = "Black Mage";
        CreatureDescription = "Altering the course of battle for the oppenents.";
        CharacterClassEnum = CharacterClasses.BMAGE;
        RecStr = 3;
        RecAgi = 2;
        RecSta = 4;
        RecInt = 9;
        RecVit = 6;
        RecSpi = 9;
        SpriteModel = "Base Female";
    }
}