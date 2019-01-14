using UnityEngine;
using System.Collections;

public class BaseMonsterClasses: BaseCreature {
    private uint moneyOut = 10, expOut = 10;
    public enum MonsterClasses {
        NOT,
        WARRIOR,
        ROUGE,
        WMAGE,
        BMAGE
    }

    public int MonsterId {
        get; set;
    }
    public MonsterClasses MonsterClass {
        get; set;
    }
    public byte AttackPower {
        get; set; }
    public byte MagicPower {
        get;  set;
    }
    public byte Speed {
        get; set;
    }
    public byte PhyDmgNeg {
        get;  set;
    }
    public byte MagDmgNeg {
        get;  set;
    }
    public ushort MaxHealthPoints {
        get;  set;
    }
    public ushort MaxManaPoints {
        get;  set;
    }
    public ushort CurrentHealthPoints {
        get; set;
    }
    public ushort CurrentManaPoints {
        get; set;
    }
    public uint MoneyOut {
        get {
            return moneyOut;
        }  set {
            moneyOut = value;
        }
    }
    public uint ExpOut {
        get {
            return expOut;
        }
         set {
            expOut = value;
        }
    }
    public byte MonsterLevel {
        get; set;
    }


    public BaseMonsterClasses() {
        this.MonsterId = 0;
    }
    public BaseMonsterClasses(int monsterId, string monsterName, string monsterDescription, string spriteModel,
        MonsterClasses monsterClass, byte monsterLevel,
        byte str, byte intel, byte agi, byte sta, byte vit, byte spi,
        byte attPower, byte magPower, byte speed, byte phyDmgNeg, byte magDmgNeg,
        ushort maxHealthPoints, ushort maxManaPoints,
        uint moneyOut, uint expOut) {
        this.MonsterId = monsterId;
        this.CreatureName = monsterName;
        this.CreatureDescription = monsterDescription;
        this.SpriteModel = spriteModel;
        this.MonsterClass = monsterClass;
        this.MonsterLevel = monsterLevel;
        this.Strength = str;
        this.Intelect = intel;
        this.Agility = agi;
        this.Stamina = sta;
        this.Vitality = vit;
        this.Spirit = spi;
        this.AttackPower = attPower;
        this.MagicPower = magPower;
        this.Speed = speed;
        this.PhyDmgNeg = phyDmgNeg;
        this.MagDmgNeg = magDmgNeg;
        this.MaxHealthPoints = maxHealthPoints;
        this.CurrentHealthPoints = maxHealthPoints;
        this.MaxManaPoints = maxManaPoints;
        this.CurrentManaPoints = maxManaPoints;
        this.MoneyOut = moneyOut;
        this.ExpOut = expOut;
    }
}