using UnityEngine;
using System.Collections;

//warrior
public class MonsterWarriorClass: BaseMonsterClasses {
    public MonsterWarriorClass() {
        MonsterClass = MonsterClasses.WARRIOR;
        BaseWarriorClass stealingClass = new BaseWarriorClass();
        CreatureName = stealingClass.CreatureName;
        CreatureDescription = stealingClass.CreatureDescription;
        Strength = stealingClass.RecStr;
        Agility = stealingClass.RecAgi;
        Stamina = stealingClass.RecSta;
        Intelect = stealingClass.RecInt;
        Vitality = stealingClass.RecVit;
        Spirit = stealingClass.RecSpi;
        SpriteModel = "Base Female";
    }
}
//rouge
public class MonsterRougeClass: BaseMonsterClasses {
    public MonsterRougeClass() {
        MonsterClass = MonsterClasses.ROUGE;
        BaseRougeClass stealingClass = new BaseRougeClass();
        CreatureName = stealingClass.CreatureName;
        CreatureDescription = stealingClass.CreatureDescription;
        Strength = stealingClass.RecStr;
        Agility = stealingClass.RecAgi;
        Stamina = stealingClass.RecSta;
        Intelect = stealingClass.RecInt;
        Vitality = stealingClass.RecVit;
        Spirit = stealingClass.RecSpi;
        SpriteModel = "Base Female";
    }
}
//White Mage
public class MonsterWMageClass: BaseMonsterClasses {
    public MonsterWMageClass() {
        MonsterClass = MonsterClasses.WMAGE;
        BaseWmageClass stealingClass = new BaseWmageClass();
        CreatureName = stealingClass.CreatureName;
        CreatureDescription = stealingClass.CreatureDescription;
        Strength = stealingClass.RecStr;
        Agility = stealingClass.RecAgi;
        Stamina = stealingClass.RecSta;
        Intelect = stealingClass.RecInt;
        Vitality = stealingClass.RecVit;
        Spirit = stealingClass.RecSpi;
        SpriteModel = "Base Male";
    }
}
//Black Mage
public class MonsterBMageClass: BaseMonsterClasses {
    public MonsterBMageClass() {
        MonsterClass = MonsterClasses.BMAGE;
        BaseBMageClass stealingClass = new BaseBMageClass();
        CreatureName = stealingClass.CreatureName;
        CreatureDescription = stealingClass.CreatureDescription;
        Strength = stealingClass.RecStr;
        Agility = stealingClass.RecAgi;
        Stamina = stealingClass.RecSta;
        Intelect = stealingClass.RecInt;
        Vitality = stealingClass.RecVit;
        Spirit = stealingClass.RecSpi;
        SpriteModel = "Base Male";
    }
}