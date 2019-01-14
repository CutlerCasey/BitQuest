using UnityEngine;
using System.Collections;

public class BattleStateWinLose {  
    public void WinLose(bool winLose) {
        BattleStateMachine stateMachine = new BattleStateMachine();
        BattleStateMachine.numPlayers = BattleStateMachine.numEnemies = BattleStateMachine.player = 0;
        BattleStateMachine.npc = BattleStateMachine.monster = 0;
        BattleStateMachine.currentUser = BattleStateMachine.targetChosen = 0;
        /*if(BattleInfomation.scriptable) {
            GoToLastScene();
        }*/
        //else
        if(winLose) {
            //update GameInformation
            UpdateGameInformation(winLose);
            //go to the last scene
            GoToLastScene();
        }
        else {
            //load last save
            LoadLastSave();
        }
    }

    private void UpdateGameInformation(bool winLose) {
        uint expToGive = 0, moneyToGive = 0;
        byte playerNpcLevels = 0, enemyLevels = 0;
        //winLoss if win should be true, wL up to us, levelBased do we want it level based, anyExp else exp increase 0 for boss
        //11 is experience given before calc, 73 enemy avg level, 37 players avg level
        //Experience.BattleExp(11, winLoss, 73, 37, wL, levelBased, anyExp);
        for(byte i = 0; i < 8; i++) {
            if(i < BattleStateMachine.players.Count) {
                playerNpcLevels += GameInformation.PlayerLevel;
            }
            else if(i < 4 && i < (BattleStateMachine.players.Count + BattleStateMachine.npcs.Count)) {
                playerNpcLevels += BattleStateMachine.npcs[i - BattleStateMachine.players.Count].NpcLevel;
            }
            else if(i > 3 && (i - 4) < BattleStateMachine.monsters.Count) {
                enemyLevels += BattleStateMachine.monsters[i - 4].MonsterLevel;
                expToGive += BattleStateMachine.monsters[i - 4].ExpOut;
                moneyToGive += BattleStateMachine.monsters[i - 4].MoneyOut;
            }
        }
        Debug.Log("exp1: " + GameInformation.PlayerCurrentExp);
        Experience.BattleExp(expToGive, winLose, enemyLevels, playerNpcLevels, true, true, true);
        Debug.Log("exp2: " + GameInformation.PlayerCurrentExp);
        Debug.Log("money1: " + GameInformation.Money);
        for(byte i = 0; i < BattleStateMachine.players.Count; i++) {
            if(moneyToGive / BattleStateMachine.players.Count > 9999999) {
                GameInformation.Money += 9999999;
            }
            else {
                GameInformation.Money += (uint)(moneyToGive / BattleStateMachine.players.Count);
            }
        }
        Debug.Log("money2: " + GameInformation.Money);
    }

    //need to add fader
    private void GoToLastScene() {
        LevelManager load = new LevelManager();
        load.loadScene(BattleInfomation.PreviousSceneString);
    }

    //need to work on
    private void LoadLastSave() {
        LoadInformation.LoadStatsInformation();
    }
}
