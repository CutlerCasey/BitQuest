using UnityEngine;
using System.Collections;

public class ScriptedCombat : ChangeToCombat {
    public byte typeOfBattle0to4 = 2;
    public byte maxSettingHpMp0to4 = 0;
    public ushort enemy00 = 1, enemy01, enemy10, enemy11;
    public byte battleNum = 1;
    public Vector3 nextLocation = default(Vector3);
    public string nextSceneString;

    void OnTriggerStay(Collider col) {
        if(battleNum > 0 && !GameInformation.battleNum[battleNum]) {
            if(col.gameObject.tag == "Player") {
                if(tempTime > 5) {
                    tempTime = 5;
                }
                else {
                    tempTime += Time.deltaTime;
                }
                if(positionHold != agent.gameObject.transform.position) {
                    holdSeconds += Time.deltaTime;
                    holdSeconds = timeTillBattle; //it is an instant battle, might think of changing this
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
    }
    private void SetInformation() {
        BattleInfomation.IsRandomBattle = false;
        BattleInfomation.Enemy00 = enemy00; BattleInfomation.Enemy01 = enemy01;
        BattleInfomation.Enemy10 = enemy10; BattleInfomation.Enemy11 = enemy11;
        BattleInfomation.MinEnemy = BattleInfomation.MaxEnemy = 0;
        BattleInfomation.TypeOfBattle = typeOfBattle0to4;
        byte tempNum = 0;
        if(enemy00 > 0) {
            tempNum++;
        }
        if(enemy01 > 0) {
            tempNum++;
        }
        if(enemy10 > 0) {
            tempNum++;
        }
        if(enemy11 > 0) {
            tempNum++;
        }
        BattleInfomation.AmmountOfEnemies = tempNum;
        BattleInfomation.MaxSettingHpMp = maxSettingHpMp0to4;
        SetBattleInformation();
        if(!string.IsNullOrEmpty(nextSceneString)) {
            BattleInfomation.PreviousSceneString = nextSceneString;
        }
        //Debug.Log("x: " + GameInformation.Position.x + " next: " + nextLocation.x);
        if(nextLocation.y != 0) {
            GameInformation.Position = nextLocation;
        }
        GameInformation.battleNum[battleNum] = true;
        LevelManager load = new LevelManager();
        load.loadScene("Battle");
    }

    public void ScriptableCombat(NavMeshAgent agent, Vector3 nextLocation, string nextSceneString,
        byte typeOfBattle0to4, byte maxSettingHpMp0to4,
        ushort enemy00, ushort enemy01, ushort enemy10, ushort enemy11) {
        battleNum = 0;
        holdSeconds = tempTime = timeTillBattle = minSecondsTillBattle = maxSecondsTillBattle = 0;
        positionHold = default(Vector3);
        this.agent = agent; this.nextLocation = nextLocation;
        this.nextSceneString = nextSceneString;
        this.typeOfBattle0to4 = typeOfBattle0to4; this.maxSettingHpMp0to4 = maxSettingHpMp0to4;
        this.enemy00 = enemy00; this.enemy01 = enemy01; this.enemy10 = enemy10; this.enemy11 = enemy11;
        SetInformation();
        BattleInfomation.Scriptable = true;
    }
}
