using UnityEngine;
using System.Collections;

public class BattleStateNpcChoice {
    private AIs npcAIScript = new AIs();
    public void NpcChoice(byte monster) {
        //choose skill
        if(BattleInfomation.IsRandomBattle || !BattleInfomation.IsRandomBattle) {
            npcAIScript.ChooseSkillRnd();
            BattleStateMachine.targetChosen = (byte)Random.Range(4, BattleStateMachine.numEnemies + 4);
        }
        BattleGUI.targetView = true;
        Debug.Log("NPC Choice: " + BattleStateMachine.usedSkill.SkillName);
        //calculate damage

        //end turn
        BattleStateMachine.currentState = BattleStateMachine.BattleStates.addStatusEffects;
    }
}
