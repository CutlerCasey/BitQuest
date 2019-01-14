using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class SceneWorker : BattleInfomation {

    public void Manager() {
        //Debug.Log("test3 agent in game");
        //string battle = "Battle", loginMenu = "loginMenu", currentScene = SceneManager.GetActiveScene().name;
        //Debug.Log("do we?");
        int currScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("CurrScene: " + currScene);
        if(currScene == 0) {
            GameInformation.Reset();
        }
        else if(currScene != 2) {
            Debug.Log("test4 agent in game");
            NavMeshAgent agentWorking = GameObject.Find("Agent").GetComponent<NavMeshAgent>();
            //Vector3 tempVect;
            /*if(currScene == 1) {
                GameObject createAPlayer = new GameObject();
                try {
                    createAPlayer = GameObject.Find("CharacterCreate");
                }
                catch(Exception e) {
                    Debug.Log("CreateAPlayer: " + e);
                }
                Debug.Log("Quest: " + GameInformation.quest[1]);
                if(GameInformation.quest[1] < 1) {
                    Vector3 tempVect = agentWorking.gameObject.transform.position;
                    tempVect.x = 53.4651f;
                    tempVect.z = -22f;
                    Debug.Log("test5 agent in game");
                    createAPlayer.gameObject.SetActive(true);
                    //GameInformation.Position = agentWorking.gameObject.transform.position;
                    GameInformation.Position = tempVect;
                }
                else {
                    Debug.Log("test6 agent in game");
                    createAPlayer.gameObject.SetActive(false);
                }
            }*/
            if(GameInformation.quest[1] < 1) {
                Vector3 tempVect = agentWorking.gameObject.transform.position;
                tempVect.x = 53.4651f;
                tempVect.z = -22f;
                GameInformation.Position = tempVect;
            }
            Debug.Log("Warp1 x: " + GameInformation.Position.x + " z: " + GameInformation.Position.z);
            agentWorking.Warp(GameInformation.Position);
        }
    }
}
