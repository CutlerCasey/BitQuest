using UnityEngine;
using System.Collections;

public class BattleStateWait {
    private CalcDerivedOther speedUpdater = new CalcDerivedOther();
    private bool[] whosTurn = new bool[8];

    public void UpdateTurnLocation() {
        if(Initialing()) {//setting all to false
            return;
        }
        UpdateTurnBasedOnSpeed(); //exactly as is said, if one is greater than 255, subtracts 255
        SendToTheRightState();
    }
    private bool Initialing() {
        //Debug.Log("Health test, PlayNpcs: " + BattleStateMachine.playersNpcsHealth + " mons: " + BattleStateMachine.monstersHealth);
        if(BattleStateMachine.numEnemies == BattleStateMachine.monstersHealth) {
            Debug.Log("Won");
            BattleStateMachine.currentState = BattleStateMachine.BattleStates.WIN;
            return true;
        }
        else if(BattleStateMachine.playersNpcsHealth == BattleStateMachine.numNpcs + BattleStateMachine.numPlayers) {
            Debug.Log("Lost");
            BattleStateMachine.currentState = BattleStateMachine.BattleStates.LOSE;
            return true;
        }
        else {
            BattleStateMachine.playersNpcsHealth = BattleStateMachine.monstersHealth = 0;
        }
        for(byte i = 0; i < BattleStateMachine.whosTurn.Length; i++) {
            whosTurn[i] = false;
        }
        BattleStateMachine.player = 0;
        BattleStateMachine.monster = 5;
        BattleStateMachine.npc = 5;
        return false;
    }
    //need to work on this
    private void UpdateTurnBasedOnSpeed() {
        for(byte i = 0; i < BattleStateMachine.whosTurn.Length; i++) {
            //Debug.Log("Health test, PlayNpcs: " + BattleStateMachine.playersNpcsHealth + " mons: " + BattleStateMachine.monstersHealth + " i: " + i);
            if(i < BattleStateMachine.players.Count) {
                if(BattleStateMachine.CurrentPlayerHP[i] < 1) {
                    BattleStateMachine.playersNpcsHealth++;
                    BattleStateMachine.whosTurn[i] = 0;
                    continue;
                }
            }
            else if(i > 0 && i < (BattleStateMachine.players.Count + BattleStateMachine.npcs.Count)) {
                if(BattleStateMachine.npcs[i - BattleStateMachine.players.Count].CurrentHealthPoints < 1) {
                    BattleStateMachine.playersNpcsHealth++;
                    BattleStateMachine.whosTurn[i] = 0;
                    continue;
                }
            }
            else if(i > 3 && (i - 4) < BattleStateMachine.monsters.Count) {
                if(BattleStateMachine.monsters[i - 4].CurrentHealthPoints < 1) {
                    BattleStateMachine.monstersHealth++;
                    BattleStateMachine.whosTurn[i] = 0;
                    continue;
                }
            }
            else {
                BattleStateMachine.whosTurn[i] = 0;
                continue;
            }

            if(EndOrAdd(i)) {
                break;
            }
        }
    }
    private bool EndOrAdd(byte i) {
        if(BattleStateMachine.whosTurn[i] > 255) {
            Debug.Log("i: " + i + "'s turn");
            BattleStateMachine.whosTurn[i] -= 255;
            BattleStateMachine.currentUser = i;
            if(BattleStateMachine.PowerPoints[i] <= 9) {
                BattleStateMachine.PowerPoints[i] += 1;
            }
            return whosTurn[i] = true;
        }
        else {
            //Debug.Log("WhosTurn: " + BattleStateMachine.whosTurn[i] + " for i: " + i);
            if(i < BattleStateMachine.players.Count) {
                BattleStateMachine.whosTurn[i] += BattleStateMachine.playerSpeed[i];
            }
            else if(i < 4 && i > 0) {
                //Debug.Log("testing i: " + i + " i-count: " + (i - BattleStateMachine.players.Count));
                BattleStateMachine.whosTurn[i] += BattleStateMachine.npcs[i - BattleStateMachine.players.Count].Speed;
            }
            else if(i > 3) {
                BattleStateMachine.whosTurn[i] += BattleStateMachine.monsters[i - 4].Speed;
            }
            return false;
        }
    }
    
    private void SendToTheRightState() {
        for(byte i = 0; i < BattleStateMachine.whosTurn.Length; i++) {
            if(whosTurn[i]) {
                WhichState(i);
            }
        }
    }
    private void WhichState(byte i) {
        switch(i) {
            case 0: //always the main player
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.playerChoice;
                break;
            case 1: //test if player or npc
                TestPlayerNpc(i);
                break;
            case 2: //test if player or npc
                TestPlayerNpc(i);
                break;
            case 3: //test if player or npc
                TestPlayerNpc(i);
                break;
            case 4: //monster 1
                BattleStateMachine.monster = 0;
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.enemyChoice;
                break;
            case 5: //monster 2
                BattleStateMachine.monster = 1;
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.enemyChoice;
                break;
            case 6: //monster 3
                BattleStateMachine.monster = 2;
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.enemyChoice;
                break;
            case 7: //monster 4
                BattleStateMachine.monster = 3;
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.enemyChoice;
                break;
            default:
                break;
        }
    }
    private void TestPlayerNpc(byte i){
        if(i < BattleStateMachine.players.Count) {
            BattleStateMachine.currentState = BattleStateMachine.BattleStates.playerChoice;
        }
        else {
            BattleStateMachine.currentState = BattleStateMachine.BattleStates.npcChoice;
        }
    }
}