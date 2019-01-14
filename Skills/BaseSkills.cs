using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BaseSkills {
    public enum PhysMagiNot {
        NOT,
        PHYSICAL,
        MAGICAL,
    }
    public enum PowerTypes {
        NONE,
        STRENGTH,
        INTELECT,
        AGILITY,
        STAMINA,
        VITALITY,
        SPIRIT,
        MANA,
        POWERPOINTS,
        HEALTH
    }
    public BaseSkills() {
        SkillID = 0;
    }

    public BaseSkills(int skillID, string skillName, string skillDescription, PhysMagiNot physMagiNot,
        PowerTypes powerTypeOne, int skillTypeOne, PowerTypes powerTypeTwo, int skillTypeTwo,
        bool crit, int manaCost, int powerPointCost, int healthCost, int statusEffect) {
        this.SkillName = skillName;
        this.SkillDescription = skillDescription;
        this.SkillID = skillID;
        this.PhysicalMagigicalNot = physMagiNot;
        this.PowerTypeOne = powerTypeOne;
        this.SkillTypeOne = skillTypeOne;
        this.PowerTypeTwo = powerTypeTwo;
        this.SkillTypeTwo = skillTypeTwo;
        this.Crit = crit;
        this.ManaCost = manaCost;
        this.PowerPointsCost = powerPointCost;
        this.HealthCost = healthCost;
        this.HealthCost = healthCost;
    }

    public string SkillName {
        get;
        protected set;
    }
    public string SkillDescription {
        get; protected set;
    }
    public int SkillID {
        get; protected set;
    }

    public PhysMagiNot PhysicalMagigicalNot {
        get;
        protected set;
    }

    //for damage
    public PowerTypes PowerTypeOne {
        get; protected set;
    }
    public int SkillTypeOne {
        get; protected set;
    }

    public PowerTypes PowerTypeTwo {
        get;
        protected set;
    }
    public int SkillTypeTwo {
        get;
        protected set;
    }
    public bool Crit {
        get;
        protected set;
    }
    //energy data
    public int ManaCost {
        get;
        protected set;
    }
    public int PowerPointsCost {
        get;
        protected set;
    }
    public int HealthCost {
        get;
        protected set;
    }

    //single status effect
    private BaseStatusEffects skillStatusEffect = new BaseStatusEffects();
    public BaseStatusEffects SkillStatusEffect {
        get {
            return skillStatusEffect;
        }
        protected set {
            skillStatusEffect = value;
        }
    }

    /*//multi status effects
    private List<BaseStatusEffects> skillsStatusEffects = new List<BaseStatusEffects>(5);
    public List<BaseStatusEffects> SkillStatusEffects {
        get {
            return skillsStatusEffects;
        }
        protected set {
            skillsStatusEffects = value;
        }
    }*/
}
