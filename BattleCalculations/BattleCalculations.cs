using UnityEngine;
using System.Collections;

public class BattleCalculations {
    private int skillPower, totalUsedSkillDamage;
    private float totalSkillPowerDamage, modifier, statusEffectDamage;
    const float critMod = .25f, totalVariance = .02f;

    public void CalculateTotalDamage(BaseSkills usedSkill) {
        float num2 = 0;
        totalSkillPowerDamage = 0;
        Debug.Log("Used Skill: " + usedSkill.SkillName);
        //base dmg(x+y) + crit - armorNeg
        num2 = CaculateSkillDamage(usedSkill);
        CalculateStatusEffectDamage();
        calcTotal(usedSkill, num2);
        if(totalUsedSkillDamage == 0) {
            totalUsedSkillDamage = 1;
        }
        Debug.Log("Damage done: " + totalUsedSkillDamage);
        //deal damage

        DealDamage();
        //pauser just see what happened
        
        BattleStateMachine.currentState = BattleStateMachine.BattleStates.WAIT;
    }
    private void calcTotal(BaseSkills usedSkill, float num2) {
        float num1 = 0;
        if(num2 >= 0) {
            Debug.Log("test preArmor");
            num1 = (num2 + Crit(usedSkill.Crit) + statusEffectDamage - Armor(usedSkill));
            if(num1 < 1) {
                totalUsedSkillDamage = 1;
            }
            else {
                totalUsedSkillDamage = (int)num1;
            }
        }
        else if(num2 < 0) {
            num1 = (num2 + Crit(usedSkill.Crit) + statusEffectDamage);
            if(num1 > -1) {
                totalUsedSkillDamage = -1;
            }
            else {
                totalUsedSkillDamage = (int)num1;
            }
            totalUsedSkillDamage += (int)(totalUsedSkillDamage * Random.Range(-totalVariance, totalVariance));
        }
    }
    //base damage
    private float CaculateSkillDamage(BaseSkills usedSkill) {
        //Debug.Log(usedSkill.SkillTypeOne + " " + usedSkill.SkillTypeTwo);
        if(usedSkill.PowerTypeTwo == BaseSkills.PowerTypes.NONE) {
            //typeOne
            calcTypeOne(usedSkill);
        }
        else {
            //typeOne and typeTwo
            calcTypeOne(usedSkill);
            calcTypeTwo(usedSkill);
        }
        return totalSkillPowerDamage;
    }
    private void calcTypeOne(BaseSkills usedSkill) {
        calcType(usedSkill.PowerTypeOne, usedSkill.SkillTypeOne);
        totalSkillPowerDamage = usedSkill.SkillTypeOne * modifier + totalSkillPowerDamage;
        Debug.Log("totalSkillPowerDmgOne1: " + totalSkillPowerDamage);
    }
    private void calcTypeTwo(BaseSkills usedSkill) {
        calcType(usedSkill.PowerTypeTwo, usedSkill.SkillTypeTwo);
        totalSkillPowerDamage = usedSkill.SkillTypeTwo * modifier + totalSkillPowerDamage;
        Debug.Log("totalSkillPowerDmgTwo: " + totalSkillPowerDamage);
    }
    //still need to work on
    private void calcType(BaseSkills.PowerTypes powerType, int skillType) {
        CalcDerivedOther getModiferOther = new CalcDerivedOther();
        CalcDerivedHP getModifierHP = new CalcDerivedHP();
        bool test = false;
        byte tempHolder = 0;
        //float statModifer = .1f;
        if(powerType == BaseSkills.PowerTypes.NONE) {
            Debug.Log("Error based on powerType is " + powerType);
            return;
        }
        else if(powerType == BaseSkills.PowerTypes.AGILITY) {
            test = true;
            if(BattleStateMachine.currentUser < BattleStateMachine.players.Count) {
                tempHolder = BattleStateMachine.players[BattleStateMachine.currentUser].Agility;
            }
            else if(BattleStateMachine.currentUser < BattleStateMachine.npcs.Count + BattleStateMachine.players.Count) {
                tempHolder = BattleStateMachine.npcs[BattleStateMachine.currentUser - BattleStateMachine.players.Count].Agility;
            }
            else {
                tempHolder = BattleStateMachine.monsters[BattleStateMachine.currentUser - 4].Agility;
            }
            modifier = getModiferOther.CalculateDerivedStatByte(tempHolder, 0, StatCalculations.DerivedStatTypes.Speed);
        }
        else if(powerType == BaseSkills.PowerTypes.INTELECT) {
            test = true;
            if(BattleStateMachine.currentUser < BattleStateMachine.players.Count) {
                tempHolder = BattleStateMachine.players[BattleStateMachine.currentUser].Intelect;
            }
            else if(BattleStateMachine.currentUser < BattleStateMachine.npcs.Count + BattleStateMachine.players.Count) {
                tempHolder = BattleStateMachine.npcs[BattleStateMachine.currentUser - BattleStateMachine.players.Count].Intelect;
            }
            else {
                tempHolder = BattleStateMachine.monsters[BattleStateMachine.currentUser - 4].Intelect;
            }
            modifier = getModiferOther.CalculateDerivedStatByte(tempHolder, 0, StatCalculations.DerivedStatTypes.MagicPower);
        }
        else if(powerType == BaseSkills.PowerTypes.SPIRIT) {
            test = true;
            if(BattleStateMachine.currentUser < BattleStateMachine.players.Count) {
                tempHolder = BattleStateMachine.players[BattleStateMachine.currentUser].Spirit;
            }
            else if(BattleStateMachine.currentUser < BattleStateMachine.npcs.Count + BattleStateMachine.players.Count) {
                tempHolder = BattleStateMachine.npcs[BattleStateMachine.currentUser - BattleStateMachine.players.Count].Spirit;
            }
            else {
                tempHolder = BattleStateMachine.monsters[BattleStateMachine.currentUser - 4].Spirit;
            }
            modifier = getModiferOther.CalculateDerivedStatByte(tempHolder, 0, StatCalculations.DerivedStatTypes.MagDmgNeg);
        }
        else if(powerType == BaseSkills.PowerTypes.STAMINA) {
            test = true;
            if(BattleStateMachine.currentUser < BattleStateMachine.players.Count) {
                tempHolder = BattleStateMachine.players[BattleStateMachine.currentUser].Stamina;
            }
            else if(BattleStateMachine.currentUser < BattleStateMachine.npcs.Count + BattleStateMachine.players.Count) {
                tempHolder = BattleStateMachine.npcs[BattleStateMachine.currentUser - BattleStateMachine.players.Count].Stamina;
            }
            else {
                tempHolder = BattleStateMachine.monsters[BattleStateMachine.currentUser - 4].Stamina;
            }
            modifier = getModifierHP.CalculateDerivedStatUshort(tempHolder, 0, StatCalculations.DerivedStatTypes.HealthPoints);
        }
        else if(powerType == BaseSkills.PowerTypes.VITALITY) {
            test = true;
            if(BattleStateMachine.currentUser < BattleStateMachine.players.Count) {
                tempHolder = BattleStateMachine.players[BattleStateMachine.currentUser].Vitality;
            }
            else if(BattleStateMachine.currentUser < BattleStateMachine.npcs.Count + BattleStateMachine.players.Count) {
                tempHolder = BattleStateMachine.npcs[BattleStateMachine.currentUser - BattleStateMachine.players.Count].Vitality;
            }
            else {
                tempHolder = BattleStateMachine.monsters[BattleStateMachine.currentUser - 4].Vitality;
            }
            modifier = getModiferOther.CalculateDerivedStatByte(tempHolder, 0, StatCalculations.DerivedStatTypes.PhyDmgNeg);
        }
        else if(powerType == BaseSkills.PowerTypes.STRENGTH) {
            test = true;
            if(BattleStateMachine.currentUser < BattleStateMachine.players.Count) {
                tempHolder = BattleStateMachine.players[BattleStateMachine.currentUser].Strength;
            }
            else if(BattleStateMachine.currentUser < BattleStateMachine.npcs.Count + BattleStateMachine.players.Count) {
                tempHolder = BattleStateMachine.npcs[BattleStateMachine.currentUser - BattleStateMachine.players.Count].Strength;
            }
            else {
                tempHolder = BattleStateMachine.monsters[BattleStateMachine.currentUser - 4].Strength;
            }
            modifier = getModiferOther.CalculateDerivedStatByte(tempHolder, 0, StatCalculations.DerivedStatTypes.AttackPower);
        }
        if(test) {
            return;
        }
        else if(powerType == BaseSkills.PowerTypes.POWERPOINTS) { //not ready yet
            modifier = skillType * GameInformation.Strength * GameInformation.Intelect;
        }
        else if(powerType == BaseSkills.PowerTypes.MANA) {
            modifier = skillType * GameInformation.Intelect;
        }
    }
    //Crit to add or subtract
    private float Crit(bool crit) {
        float rnd = Random.value, critChance = .3f, critChanceFup = .05f;
        if((1 - rnd) < critChance) {
            return totalSkillPowerDamage * critMod;
        }
        else if((1 - rnd) > (1 - critChanceFup)) {
            return -(totalSkillPowerDamage * critMod);
        }
        else {
            return .0f;
        }
    }

    //need to work on
    private float Armor(BaseSkills usedSkill) {
        float tempHolder = 0.0f;
        Debug.Log("target: " + BattleStateMachine.targetChosen + " damage pre armor: " + totalUsedSkillDamage + " PhysMagiNot: " + usedSkill.PhysicalMagigicalNot);
        if(totalUsedSkillDamage > 0) {
            if(usedSkill.PhysicalMagigicalNot == BaseSkills.PhysMagiNot.PHYSICAL) {
                if(BattleStateMachine.targetChosen < BattleStateMachine.players.Count) {
                    tempHolder = BattleStateMachine.playerPhyDef[BattleStateMachine.targetChosen];
                }
                else if(BattleStateMachine.targetChosen < BattleStateMachine.npcs.Count + BattleStateMachine.players.Count) {
                    tempHolder = BattleStateMachine.npcs[BattleStateMachine.targetChosen - BattleStateMachine.players.Count].PhyDmgNeg;
                }
                else {
                    tempHolder = BattleStateMachine.monsters[BattleStateMachine.targetChosen - 4].PhyDmgNeg;
                }
            }
            else if(usedSkill.PhysicalMagigicalNot == BaseSkills.PhysMagiNot.MAGICAL) {
                if(BattleStateMachine.targetChosen < BattleStateMachine.players.Count) {
                    tempHolder = BattleStateMachine.playerMagDef[BattleStateMachine.targetChosen];
                }
                else if(BattleStateMachine.targetChosen < BattleStateMachine.npcs.Count + BattleStateMachine.players.Count) {
                    tempHolder = BattleStateMachine.npcs[BattleStateMachine.targetChosen - BattleStateMachine.players.Count].MagDmgNeg;
                }
                else {
                    tempHolder = BattleStateMachine.monsters[BattleStateMachine.targetChosen - 4].MagDmgNeg;
                }
            }
        }
        return tempHolder;
    }
    //need to work on
    private void DealDamage() {
        ushort tempCurrent, tempMax;
        if(BattleStateMachine.targetChosen < BattleStateMachine.players.Count) {
            tempCurrent = BattleStateMachine.CurrentPlayerHP[BattleStateMachine.targetChosen];
            tempMax = BattleStateMachine.MaxPlayerHP[BattleStateMachine.targetChosen];
            BattleStateMachine.CurrentPlayerHP[BattleStateMachine.targetChosen] = DealDamage(tempCurrent, tempMax);
        }
        else if(BattleStateMachine.targetChosen < BattleStateMachine.npcs.Count + BattleStateMachine.players.Count) {
            tempCurrent = BattleStateMachine.npcs[BattleStateMachine.targetChosen - BattleStateMachine.players.Count].CurrentHealthPoints;
            tempMax = BattleStateMachine.npcs[BattleStateMachine.targetChosen - BattleStateMachine.players.Count].MaxHealthPoints;
            BattleStateMachine.npcs[BattleStateMachine.targetChosen - BattleStateMachine.players.Count].CurrentHealthPoints = DealDamage(tempCurrent, tempMax);
        }
        else {
            tempCurrent = BattleStateMachine.monsters[BattleStateMachine.targetChosen - 4].CurrentHealthPoints;
            tempMax = BattleStateMachine.monsters[BattleStateMachine.targetChosen - 4].MaxHealthPoints;
            BattleStateMachine.monsters[BattleStateMachine.targetChosen - 4].CurrentHealthPoints = DealDamage(tempCurrent, tempMax);
        }
    }
    //work on
    private ushort DealDamage(ushort temp1, ushort temp2) {
        if(totalUsedSkillDamage > 0) {
            if((temp1 - totalUsedSkillDamage) <= 0) {
                BattleStateMachine.damageDone = temp1;
                return 0;
            }
        }
        else {
            if((temp1 - totalUsedSkillDamage) >= temp2) {
                BattleStateMachine.damageDone = temp1 - temp2;
                return temp2;
            }
        }
        BattleStateMachine.damageDone = totalUsedSkillDamage;
        return (ushort)(temp1 - totalUsedSkillDamage);
    }
    //need to work on
    private void Pauser() {
        
    }

    private void CalculateStatusEffectDamage() {
        statusEffectDamage = Mathf.Pow(BattleStateMachine.statusEffectDamage, (1 + GameInformation.PlayerLevel / 20));
    }
}