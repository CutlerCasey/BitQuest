using UnityEngine;
using System.Collections;

public class BaseNPC: BaseCreature {
    private static BaseCharacterClass stealingInfo = new BaseCharacterClass();
    private uint money = 0, exp = 0;
    private byte statsPerLevel = stealingInfo.StatsPerLevel;
    public enum NpcClasses {
        NOT,
        WARRIOR,
        ROUGE,
        WMAGE,
        BMAGE,
        InstructorBMAGE,
        InstructorWARRIOR,
        InstructorROUGE,
        InstructorWMAGE,
        HEADMASTER, //headmaster
        KRYST //for the kryst duh
    };
    public int NpcID {
        get; set;
    }
    public NpcClasses NpcClass {
        get; set;
    }
    public byte NpcLevel {
        get; set;
    }
    public byte AttackPower {
        get;
        set;
    }
    public byte MagicPower {
        get;
        set;
    }
    public byte Speed {
        get;
        set;
    }
    public byte PhyDmgNeg {
        get;
        set;
    }
    public byte MagDmgNeg {
        get;
        set;
    }
    public ushort MaxHealthPoints {
        get;
        set;
    }
    public ushort CurrentHealthPoints {
        get;
        set;
    }
    public ushort MaxManaPoints {
        get;
        set;
    }
    public ushort CurrentManaPoints {
        get;
        set;
    }

    public BaseNPC() {
        this.NpcID = 0;
    }
    public BaseNPC(int npcId, string npcName, string npcDescription, string spriteModel,
        NpcClasses npcClass, byte npcLevel,
        byte str, byte intel, byte agi, byte sta, byte vit, byte spi,
        byte attPower, byte magPower, byte speed, byte phyDmgNeg, byte magDmgNeg,
        ushort maxHealthPoints, ushort maxManaPoints) {
        this.NpcID = npcId;
        this.CreatureName = npcName;
        this.CreatureDescription = npcDescription;
        this.SpriteModel = spriteModel;
        this.Strength = str;
        this.Agility = agi;
        this.Intelect = intel;
        this.Stamina = sta;
        this.Vitality = vit;
        this.Spirit = spi;
        this.NpcClass = npcClass;
        this.NpcLevel = npcLevel;
        this.AttackPower = attPower;
        this.MagicPower = magPower;
        this.Speed = speed;
        this.PhyDmgNeg = phyDmgNeg;
        this.MagDmgNeg = MagDmgNeg;
        this.MaxHealthPoints = maxHealthPoints;
        this.CurrentHealthPoints = maxHealthPoints;
        this.MaxManaPoints = maxManaPoints;
        this.CurrentManaPoints = maxManaPoints;        
    }
}
