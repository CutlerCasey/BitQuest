using UnityEngine;
using System.Collections;

public class BattleStateAddStatusEffects {
    public void CheckSkillForStatusEffects(BaseSkills usedSkill) {
        if(usedSkill.SkillStatusEffect == null || usedSkill.SkillStatusEffect.StatusEffectName == null) {
            Debug.Log("No Status Effect");
            BattleStateMachine.currentState = BattleStateMachine.BattleStates.calcDamage;
            return;
        }
        float rndTemp = Random.value;
        switch(usedSkill.SkillStatusEffect.StatusEffectName) {
            case ("Burn"): //damage type
                TryToApplyStatusEffectDmg(usedSkill, rndTemp);
                break;
            case ("Stun"): //stunning type
                
                break;
            case ("Defend"): //buffs type

                break;
            default:
                Debug.Log("Not a type of Status Effect Yet.");
                return;
        }
        BattleStateMachine.currentState = BattleStateMachine.BattleStates.calcDamage;
    }

    private void TryToApplyStatusEffectDmg(BaseSkills usedSkill, float rndTemp) {
        //look at percent chance
        //use percent chance
        if(rndTemp <= usedSkill.SkillStatusEffect.StatusEffectApplyPercent) {
            BattleStateMachine.stunEffect = usedSkill.SkillStatusEffect.StunEffect;
            BattleStateMachine.statusEffectDamage = usedSkill.SkillStatusEffect.StatusEffectDmg;
        }
        else {
            BattleStateMachine.stunEffect = false;
            BattleStateMachine.statusEffectDamage = 0;
        }
    }
}