using UnityEngine;
using System.Collections;

//[System.Serializable] //need to save
public class BasePlayer {
    public string PlayerName { get; set; } //is equivlant to the following
    /*public string PlayerName {
        get {
            return playerName;
        }
        set {
            playerName = value;
        }
    }*/
    public BaseCharacterClass PlayerClass {
        get; set;
    }
    public byte PlayerLevel {
        get; set;
    }
    //buy and sell
    public uint Money {
        get; set;
    }
    //exp in the level
    public uint CurrentExp {
        get; set;
    }
    //exp to next level
    public uint RequiredExp {
        get; set;
    }
    //phyiscal attack & max endurance/vigor
    public byte Strength {
        get; set;
    }
    //magical attack & max endurance/vigor
    public byte Spirit {
        get; set;
    }
    //dodge & how fast one gets to move
    public byte Speed {
        get; set;
    }
    //max HP
    public byte Stamina {
        get; set;
    }
    //% of physical resistance
    public byte PhyDefense {
        get; set;
    }
    //% of magical resistance
    public byte MagDefenese {
        get; set;
    }
}