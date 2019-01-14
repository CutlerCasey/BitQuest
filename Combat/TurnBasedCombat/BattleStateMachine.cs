using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class BattleStateMachine : MonoBehaviour {
    //the other files being pulled in
    private BattleStateStart stateStartScript = new BattleStateStart();
    private BattleCalculations battleCalcScript = new BattleCalculations();
    private BattleStateAddStatusEffects addStatusEffectsScript = new BattleStateAddStatusEffects();
    private BattleStateEnemyChoice enemyChoiceScript = new BattleStateEnemyChoice();
    private BattleStateNpcChoice npcChoiceScript = new BattleStateNpcChoice();
    private BattleStateWait battleStateWaitScript = new BattleStateWait();
    private BattleStateWinLose winLoseScript = new BattleStateWinLose();

    //data to be used
    public static ushort[] whosTurn = new ushort[8]; //who goes next
    //public static BaseCharacterClass[] players = new BaseCharacterClass[4];
    public static List<BaseCharacterClass> players = new List<BaseCharacterClass>();
    public static byte[] playerAttPow = new byte[4];
    public static byte[] playerMagPow = new byte[4];
    public static byte[] playerSpeed = new byte[4];
    public static byte[] playerPhyDef = new byte[4];
    public static byte[] playerMagDef = new byte[4];
    public static ushort[] MaxPlayerHP = new ushort[4];
    public static ushort[] CurrentPlayerHP = new ushort[4];
    public static ushort[] MaxPlayerMP = new ushort[4];
    public static ushort[] CurrentPlayerMP = new ushort[4];

    public static List<BaseNPC> npcs = new List<BaseNPC>();

    public static List<BaseMonsterClasses> monsters = new List<BaseMonsterClasses>();

    public static byte[] PowerPoints = new byte[8];

    public static BaseSkills usedSkill;
    public static int damageDone = 0;
    public static int statusEffectDamage;
    public static bool stunEffect;
    public static byte numPlayers = 1, numNpcs = 0, numEnemies = 1;
    public static byte typeOfBattle; //effects whosTurn at the start and setup of players, npcs, and enemies

    public static byte player = 1;
    public static byte npc = 3;
    public static byte monster = 3;
    public static byte playersNpcsHealth = 0;
    public static byte monstersHealth = 0;

    public static byte currentUser = 9;
    public static byte targetChosen = 9;

    public enum BattleStates { //might cut some states later, but not now
        START,
        playerChoice,
        playerAnimate,
        npcChoice,
        enemyChoice,
        calcDamage,
        addStatusEffects,
        WAIT,
        LOSE,
        WIN
    }
    public static BattleStates currentState;

    public void Restart() {
        whosTurn.Initialize();
        players.Clear();
        npcs.Clear();
        monsters.Clear();
        playerAttPow.Initialize();
        playerMagDef.Initialize();
        playerMagPow.Initialize();
        playerPhyDef.Initialize();
        playerSpeed.Initialize();
        MaxPlayerHP.Initialize();
        CurrentPlayerHP.Initialize();
        MaxPlayerMP.Initialize();
        CurrentPlayerMP.Initialize();
        PowerPoints.Initialize();
        usedSkill = default(BaseSkills);
        damageDone = 0;
        statusEffectDamage = 0;
        numPlayers = numEnemies = 1;
        numNpcs = 0;
        player = 1;
        npc = monster = 3;
        playersNpcsHealth = monstersHealth = 0;
        currentUser = targetChosen = 9;
    }

    // Use this for initialization
    void Start() {
        //should be start
        currentState = BattleStates.START;
        Restart();
        StartCoroutine(stateStartScript.PrepareTheBattle());
        StartCoroutine(WorkHorse());
    }

    IEnumerator WorkHorse() { //per frame
        float tempTime = 0;
        while(true) {
            //Debug.Log("CurrentState: " + currentState);
            switch(currentState) {
                case (BattleStates.START):
                    //setup battle function
                    //sends to wait
                    break;
                case (BattleStates.WIN):
                    tempTime = 4;
                    winLoseScript.WinLose(true);
                    break;
                case (BattleStates.LOSE):
                    tempTime = 1;
                    winLoseScript.WinLose(false);
                    break;
                case (BattleStates.WAIT):
                    tempTime = .02f;
                    //update who goes next
                    battleStateWaitScript.UpdateTurnLocation(); //sends to the correct enemy, player, or npc
                    break;
                case (BattleStates.playerChoice): //this is done in BattleGUI
                    tempTime = .1f;
                    break;
                case (BattleStates.playerAnimate):
                    tempTime = 3;
                    break;
                case (BattleStates.npcChoice):
                    npcChoiceScript.NpcChoice(npc);
                    tempTime = 2;
                    break;
                case (BattleStates.enemyChoice):
                    //number should be 0 through 3
                    enemyChoiceScript.EnemyChoice(monster);
                    tempTime = 2;
                    break;
                case (BattleStates.calcDamage):
                    battleCalcScript.CalculateTotalDamage(usedSkill); //sends to wait
                    tempTime = .1f;
                    break;
                case (BattleStates.addStatusEffects):
                    addStatusEffectsScript.CheckSkillForStatusEffects(usedSkill); //sends to calculate damage
                    tempTime = 2;
                    break;
            }
            yield return new WaitForSeconds(tempTime);
        }
    }
}
