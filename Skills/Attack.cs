using UnityEngine;
using System.Collections;

[System.Serializable]
public class Attack : BaseSkills {
    public Attack() {
        SkillName = "Attack";
        SkillDescription = "A normal attack.";
        SkillID = 1;
        PowerTypeOne = PowerTypes.STRENGTH;
        Crit = true;
        SkillTypeOne = 1;
    }
}
[System.Serializable]
public class Defend: BaseSkills {
    public Defend() {
        SkillName = "Defend";
        SkillDescription = "Guard of oneself.";
        SkillID = 2;
        PowerPointsCost = -1;
        SkillStatusEffect = new DefendOnesSelf();
    }
}
[System.Serializable]
public class GiantSlash: BaseSkills {
    public GiantSlash() {
        SkillName = "GiantSlash";
        SkillDescription = "Whatever.";
        SkillID = 3;
        PowerTypeOne = PowerTypes.STRENGTH;
        Crit = false;
        SkillTypeOne = 10;
        ManaCost = 10;
        PowerPointsCost = 3;
    }
}