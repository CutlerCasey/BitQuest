using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseCreature {
    private string creatureName = "Need a Name";
    private string creatureDescription = "Need a Description";
    private string spriteModel;
    //I want people to totaly mess up
    private byte strength = 1, agility = 1, stamina = 1, intellect = 1, vitality = 1, spirit = 1;

    public string CreatureName {
        get {
            return creatureName;
        }
        set {
            creatureName = value;
        }
    }
    public string CreatureDescription {
        get {
            return creatureDescription;
        }
        set {
            creatureDescription = value;
        }
    }
    public string SpriteModel {
        get {
            return spriteModel;
        }
        set {
            spriteModel = value;
        }
    }
    public List<BaseSkills> creaturesSkills = new List<BaseSkills>(5) {
        new Attack(),
        new Defend()
    };
    //phyiscal attack
    public byte Strength {
        get {
            return strength;
        }
        set {
            strength = value;
        }
    }
    //magical attack & max mana
    public byte Intelect {
        get {
            return intellect;
        }
        set {
            intellect = value;
        }
    }
    //speed
    public byte Agility {
        get {
            return agility;
        }
        set {
            agility = value;
        }
    }
    //max HP
    public byte Stamina {
        get {
            return stamina;
        }
        set {
            stamina = value;
        }
    }
    //physical resistance
    public byte Vitality {
        get {
            return vitality;
        }
        set {
            vitality = value;
        }
    }
    //magical resistance & max mp
    public byte Spirit {
        get {
            return spirit;
        }
        set {
            spirit = value;
        }
    }

    public BaseCreature() {

    }
}
