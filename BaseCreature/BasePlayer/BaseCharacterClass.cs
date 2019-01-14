using UnityEngine;
using System.Collections;

//[System.Serializable] //need to save, but later
public class BaseCharacterClass : BaseCreature {
    public enum CharacterClasses {
        BASE,
        WARRIOR,
        ROUGE,
        WMAGE,
        BMAGE,
        NONE
    }
    
    private CharacterClasses characterClassEnum = new CharacterClasses();
    const byte statsPerLevel = 5;
    const byte initialStatPoints = 24;
    const byte middleByte = 255 / 2 - 1;
    private byte evilGood = middleByte, lawChaos = middleByte, neutralPshyco = middleByte;

    //something about this
    public CharacterClasses CharacterClassEnum {
        get {
            return characterClassEnum;
        }
        set {
            characterClassEnum = value;
        }
    }

    public byte RecStr {
        get; protected set;
    }
    public byte RecInt {
        get; protected set;
    }
    public byte RecAgi {
        get; protected set;
    }
    public byte RecSta {
        get; protected set;
    }
    public byte RecVit {
        get; protected set;
    }
    public byte RecSpi {
        get; protected set;
    }
    //for the personality system
    public byte EvilGood {
        get {
            return evilGood;
        }
        set {
            evilGood = value;
        }
    }
    public byte LawChaos {
        get {
            return lawChaos;
        }
        set {
            lawChaos = value;
        }
    }
    public byte NeutralPshyco {
        get {
            return neutralPshyco;
        }
        set {
            neutralPshyco = value;
        }
    }
    //gets you to the defaults
    public byte InitialStatPoints {
        get {
            return initialStatPoints;
        }
    }
    //get add on level
    public byte StatsPerLevel {
        get {
            return statsPerLevel;
        }
    }
    //holder for stat points
    public byte StatPoints {
        get; set;
    }
    //holder for skill points
    public byte SkillPoint {
        get; set;
    }
}
