[System.Serializable]
public class Burn : BaseStatusEffects {
    public Burn() {
        StatusEffectName = "Burn";
        StatucEffectDescription = "Burns the enemy for 10 damage for some number of turns";
        StatusEffectID = 1;
        StatusEffectApplyPercent = 50; //is 50%
        StatusEffectDmg = 10;
        StatusEffectStayAppliedPercent = 90; //is 90%
        StatusEffectMinTurns = 1;
        StatusEffectMaxTurns = 4;
    }
}
[System.Serializable]
public class Stun: BaseStatusEffects {
    public Stun() {
        StatusEffectName = "Stun";
        StatucEffectDescription = "Stuns the enemy for a some turns.";
        StatusEffectID = 2;
        StunEffect = true;
        StatusEffectApplyPercent = 100; //is 25%
        StatusEffectStayAppliedPercent = 25; //is 25%
        StatusEffectMinTurns = 1;
        StatusEffectMaxTurns = 2;
    }
}
[System.Serializable]
public class StrBuff: BaseStatusEffects {
    public StrBuff() {
        StatusEffectName = "Strength Buff";
        StatucEffectDescription = "Buffs Strength and everything derived from it.";
        StatusEffectID = 3;
        StatusEffectApplyPercent = 100; //is 100%
        StatusEffectStayAppliedPercent = 90; //is 90%
        StatusEffectMinTurns = 3;
        StatusEffectMaxTurns = 6;
        StatChange1 = StatChanges.STRENGTH;
        StatChangeMultiple1 = 200;  //str * 2
    }
}
[System.Serializable]
public class DefendOnesSelf: BaseStatusEffects {
    public DefendOnesSelf() {
        StatusEffectName = "Defend";
        StatucEffectDescription = "Buff Defense for one turn + 2 pp.";
        StatusEffectID = 4;
        StatusEffectApplyPercent = 100; //is 100%
        StatusEffectStayAppliedPercent = 100; //is 90%
        StatusEffectMinTurns = 1;
        StatusEffectMaxTurns = 1;
        StatChange1 = StatChanges.PHYDMNEG;
        StatChangeMultiple1 = 200;
        StatChange2 = StatChanges.MAGDMGNEG;
        StatChangeMultiple1 = 200;
    }
}