using UnityEngine;
using System.Collections;

//warrior
public class NpcWarriorClass: BaseNPC {
    public NpcWarriorClass() {
        NpcClass = NpcClasses.WARRIOR;
        BaseWarriorClass stealingClass = new BaseWarriorClass();
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
//rouge
public class NpcRougeClass: BaseNPC {
    public NpcRougeClass() {
        NpcClass = NpcClasses.ROUGE;
        BaseRougeClass stealingClass = new BaseRougeClass();
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
//White Mage
public class NpcWMageClass: BaseNPC {
    public NpcWMageClass() {
        NpcClass = NpcClasses.WMAGE;
        BaseWmageClass stealingClass = new BaseWmageClass();
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
//Black Mage
public class NpcBMageClass: BaseNPC {
    public NpcBMageClass() {
        NpcClass = NpcClasses.BMAGE;
        BaseBMageClass stealingClass = new BaseBMageClass();
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