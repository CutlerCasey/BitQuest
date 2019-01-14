using UnityEngine;
using System.Collections;

public class BattleStateEnemyChoice {
    private AIs enemyAIScript = new AIs();
    public void EnemyChoice(byte monster) {
        //choose skill
        if(BattleInfomation.IsRandomBattle || !BattleInfomation.IsRandomBattle) {
            enemyAIScript.ChooseSkillRnd();
            BattleStateMachine.targetChosen = (byte)Random.Range(0, BattleStateMachine.numPlayers + BattleStateMachine.numNpcs);
        }
        BattleGUI.targetView = true;
        Debug.Log("Enemy Choice: " + BattleStateMachine.usedSkill.SkillName);
        //calculate damage

        //end turn
        BattleStateMachine.currentState = BattleStateMachine.BattleStates.addStatusEffects;
    }
}
