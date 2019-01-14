using UnityEngine;
using System.Collections;


public class BattleInfomation: MonoBehaviour {
    //const float locX = 45.367f, locY = 0.74f, locZ = -19.92f;
    private static BattleInfomation battleInformation;
    
    //public bool noneNormStart;
    void Awake() {
        //Debug.Log("test0 agent in game");
        if(battleInformation == null) {
            //Debug.Log("test1 agent in game");
            DontDestroyOnLoad(gameObject);
            battleInformation = this;
        }
        else if(battleInformation != this) {
            SceneWorker sceneWorkerScript = new SceneWorker();
            sceneWorkerScript.Manager();
            Destroy(gameObject);
        }
        else {
            Debug.Log("test7 agent in game");
        }
    }

    void Start() {
        
    }

    //battle information, just data to hold for the battle scenes
    private static NavMeshAgent agent;
    public static NavMeshAgent Agent {
        get {
            return agent;
        }
        set {
            agent = value;
        }
    }

    //random battle
    private static bool isRandomBattle = true; //everything will be random sort of
    public static bool IsRandomBattle {
        get {
            return isRandomBattle;
        }
        set {
            isRandomBattle = value;
        }
    }
    //scriptable
    private static bool scriptable = false; //everything will be random sort of
    public static bool Scriptable {
        get {
            return scriptable;
        }
        set {
            scriptable = value;
        }
    }
    private static byte typeOfBattle = 2;
    public static byte TypeOfBattle {
        get {
            return typeOfBattle;
        }
        set {
            typeOfBattle = value;
        }
    }
    private static byte ammountOfEnemies = 1;
    public static byte AmmountOfEnemies {
        get {
            return ammountOfEnemies;
        }
        set {
            if(value < 1)
                ammountOfEnemies = 1;
            else
                ammountOfEnemies = value;
        }
    }
    private static byte maxSettingHpMp = 0;
    public static byte MaxSettingHpMp {
        get {
            return maxSettingHpMp;
        }
        set {
            maxSettingHpMp = value;
        }
    }
    //scene to return to after a battle, should be even another battle
    private static string previousSceneString = "";
    public static string PreviousSceneString {
        get {
            return previousSceneString;
        }
        set {
            previousSceneString = value;
        }
    }

    private static ushort minEnemy, maxEnemy;
    public static ushort MinEnemy {
        get {
            return minEnemy;
        }
        set {
            minEnemy = value;
        }
    }
    public static ushort MaxEnemy {
        get {
            return maxEnemy;
        }
        set {
            maxEnemy = value;
        }
    }

    private static ushort enemy00, enemy01, enemy10, enemy11;
    public static ushort Enemy00 {
        get {
            return enemy00;
        }
        set {
            enemy00 = value;
        }
    }
    public static ushort Enemy01 {
        get {
            return enemy01;
        }
        set {
            enemy01 = value;
        }
    }
    public static ushort Enemy10 {
        get {
            return enemy10;
        }
        set {
            enemy10 = value;
        }
    }
    public static ushort Enemy11 {
        get {
            return enemy11;
        }
        set {
            enemy11 = value;
        }
    }
}
