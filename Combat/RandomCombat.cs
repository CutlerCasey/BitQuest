using UnityEngine;
using System.Collections;

public class RandomCombat : ChangeToCombat {
    void OnTriggerStay(Collider col) {
        if(col.gameObject.tag == "Player") {
            if(tempTime > 5) {
                tempTime = 5;
            }
            else {
                tempTime += Time.deltaTime;
            }
            if(positionHold != agent.gameObject.transform.position) {
                holdSeconds += Time.deltaTime;
                if(holdSeconds >= timeTillBattle) {
                    Debug.Log("Time to enter battle: " + timeTillBattle + " Moving");
                    SetInformation();
                }
                positionHold = agent.gameObject.transform.position;
                tempTime = 0;
            }
            else if(holdSeconds + tempTime >= timeTillBattle) {
                Debug.Log("Time to enter battle: " + timeTillBattle + " !Moving");
                SetInformation();
            }
        }
    }

    private void SetInformation() {
        BattleInfomation.IsRandomBattle = true;
        BattleInfomation.Enemy00 = BattleInfomation.Enemy01 = BattleInfomation.Enemy10 = BattleInfomation.Enemy11 = 0;
        BattleInfomation.MinEnemy = BattleInfomation.MaxEnemy = 0;
        BattleInfomation.TypeOfBattle = BattleInfomation.AmmountOfEnemies = 5;
        BattleInfomation.MaxSettingHpMp = 0;
        SetBattleInformation();
        LevelManager load = new LevelManager();
        load.loadScene("Battle");
    }
}
