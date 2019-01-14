using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeToCombat : MonoBehaviour {
    protected float holdSeconds, tempTime, timeTillBattle;
    protected Vector3 positionHold;

    public NavMeshAgent agent;
    public float minSecondsTillBattle = 5;
    public float maxSecondsTillBattle = 7;

    void OnTriggerEnter(Collider col) {
        Debug.Log("test entry");
        if(col.gameObject.tag == "Player") {
            holdSeconds = tempTime = 0;
            if(minSecondsTillBattle > maxSecondsTillBattle) {
                minSecondsTillBattle = maxSecondsTillBattle;
            }
            timeTillBattle = Random.Range(minSecondsTillBattle, maxSecondsTillBattle);
            positionHold = default(Vector3);
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.gameObject.tag == "Player") {
            Debug.Log("Time to in trigger area: " + holdSeconds);
            holdSeconds = tempTime = timeTillBattle = 0;
            positionHold = default(Vector3);
        }
    }

    protected void SetBattleInformation() {
        GameInformation.Position = this.agent.gameObject.transform.position;
        //GameInformation.Rotation = this.agent.gameObject.transform.rotation;
        BattleInfomation.Agent = this.agent;
        BattleInfomation.PreviousSceneString = SceneManager.GetActiveScene().name;
        BattleInfomation.Scriptable = false;
    }
}
