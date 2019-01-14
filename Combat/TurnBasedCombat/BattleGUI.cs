using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

class BattleGUI : MonoBehaviour {
    private bool setUp = false, firstTime = true;
    public static bool targetView = false;
    private int tempDamage1, tempDamage2;

    //public GraphicRaycaster battleCanvas;

    public Image topData, position, endBattle;
    //Data info
    public Image userData, targetData;
    public Image playerChoice;
    public Button attack, defend, skills, items, escape, untarget;
    public Image skillItem;
    public Button use;
    public Toggle[] toggle = new Toggle[20];
    public Text[] label = new Text[20];
    public Image EscapePanel;

    public Text userName, userClass, userLevel, userCurrHealth, userMaxHealth, userCurrMana, userMaxMana, userCurrPowerPoints;
    public Image userHealthImage, userManaImage, userPowerPointsImage;
    public Text targetName, targetClass, targetLevel, targetCurrHealth, targetMaxHealth, targetCurrMana, targetMaxMana, targetCurrPowerPoints;
    public Image targetHealthImage, targetManaImage, targetPowerPointsImage;
    public NavMeshAgent playerAgent00, playerAgent01, playerAgent10, playerAgent11;
    public NavMeshAgent monsterAgent00, monsterAgent01, monsterAgent10, monsterAgent11;
    public Image damageWindow;
    public Text user1, user2, damage1, damage2, target1, target2;
    //position info
    public Transform player00, player01, player10, player11;
    public Transform enemy00, enemy01, enemy10, enemy11;
    //public Image spellOrAttack00, spellOrAttack01, spellOrAttack10, spellOrAttack11;
    //endBattle info

    private Sprite_Movement SPM;

    private enum Direction {
        IDLE,
        UP,
        DOWN,
        LEFT,
        RIGHT //more for later
    }
    private float width, height;

	// Use this for initialization
	void Start () {
        targetView = false;
    }
	
	// Update is called once per frame
	void Update () {
        switch(BattleStateMachine.currentState) {
            case (BattleStateMachine.BattleStates.START):
                damageWindow.gameObject.SetActive(false);
                targetView = false;
                endBattle.gameObject.SetActive(false);
                Targetable(false);
                CurrentUser(false);
                Target(targetView);
                break;
            case (BattleStateMachine.BattleStates.WIN):
                endBattle.gameObject.SetActive(false);
                targetView = false;
                endBattle.gameObject.SetActive(false);
                Targetable(false);
                CurrentUser(false);
                Target(targetView);

                break;
            case (BattleStateMachine.BattleStates.LOSE):
                endBattle.gameObject.SetActive(false);
                targetView = false;
                endBattle.gameObject.SetActive(false);
                Targetable(false);
                CurrentUser(false);
                Target(targetView);
                LoadInformation.LoadStatsInformation();
                LevelManager load = new LevelManager();
                load.loadScene(GameInformation.SceneAt);
                break;
            case (BattleStateMachine.BattleStates.WAIT):
                if(firstTime) {
                    damageWindow.gameObject.SetActive(false);
                }
                if(!setUp) {
                    SetUp();
                }
                targetView = false;
                CurrentUser(false);
                Targetable(false);
                Target(targetView);
                break;
            case (BattleStateMachine.BattleStates.enemyChoice):
            case (BattleStateMachine.BattleStates.npcChoice):
                changeData = true;
                CurrentUser(true);
                break;
            case (BattleStateMachine.BattleStates.playerChoice):
                changeData = true;
                Targetable(true);
                CurrentUser(true);
                Target(targetView);
                break;
            case (BattleStateMachine.BattleStates.addStatusEffects):
            case (BattleStateMachine.BattleStates.calcDamage):
                CurrentUser(true);
                Target(targetView);
                damageWindow.gameObject.SetActive(true);
                firstTime = false;
                ChangeData();
                break;
            default:
                CurrentUser(true);
                Target(false);
                Targetable(targetView);
                break;
        }
    }

    //meant for testing
    /*void OnGUI() {
        width = Screen.width; height = Screen.height;
        TestState();
        //we need buttons for players moves
        if(BattleStateMachine.currentState == BattleStateMachine.BattleStates.playerChoice) {
            if(targetView) {
                //DisplayPlayersChoice();
            }
        }
        //need to show enemy info
        //need to show player info
    }
    private void TestState() {
        if(GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 200, 35), BattleStateMachine.currentState.ToString())) {
            if(BattleStateMachine.currentState == BattleStateMachine.BattleStates.START) {
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.WAIT;
            }
            else if(BattleStateMachine.currentState == BattleStateMachine.BattleStates.WAIT) {
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.playerChoice;
            }
            else if(BattleStateMachine.currentState == BattleStateMachine.BattleStates.npcChoice) {
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.WAIT;
            }
            else if(BattleStateMachine.currentState == BattleStateMachine.BattleStates.calcDamage) {
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.playerChoice;
            }
            else if(BattleStateMachine.currentState == BattleStateMachine.BattleStates.addStatusEffects) {
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.calcDamage;
            }
            else if(BattleStateMachine.currentState == BattleStateMachine.BattleStates.enemyChoice) {
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.LOSE;
            }
        }
    }
    private void DisplayPlayersChoice() {
        for(int i = 0; i < GameInformation.PlayerSkills.Count; i++) {
            if(GUI.Button(new Rect(width *.8f, height*.01f+(i+1)*40, 150, 35), GameInformation.PlayerSkills[i].SkillName)) {
                //calculate the players damage to the enemy
                BattleStateMachine.usedSkill = GameInformation.PlayerSkills[i];
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.addStatusEffects;
            }
        }
    }*/

    private bool changeData = true;
    private void ChangeData() {
        if(changeData) {
            user2.text = user1.text;
            user1.text = userName.text;
            target2.text = target1.text;
            target1.text = targetName.text;
            tempDamage2 = tempDamage1;
            damage2.text = tempDamage2.ToString();
            tempDamage1 = BattleStateMachine.damageDone;
            damage1.text = tempDamage1.ToString();
            changeData = false;
        }
    }

    private void CurrentUser(bool setter) {
        if(BattleStateMachine.currentUser < BattleStateMachine.numPlayers && BattleStateMachine.currentUser < 4) {
            CurrentPlayer();
            userData.color = Color.cyan;
        }
        else if(BattleStateMachine.currentUser < (BattleStateMachine.numNpcs + BattleStateMachine.numPlayers) && BattleStateMachine.currentUser < 4) {
            CurrentNpc();
            userData.color = Color.yellow;
        }
        else if(BattleStateMachine.currentUser - 4 < BattleStateMachine.numEnemies && BattleStateMachine.currentUser > 3) {
            CurrentEnemy();
            userData.color = Color.magenta;
        }
        else {
            CurrentDefault();
            userData.color = Color.gray;
        }
        userData.gameObject.SetActive(setter);
    }
    private void CurrentPlayer() {
        byte i = BattleStateMachine.currentUser;
        //if player
        userName.text = GameInformation.PlayerName;
        userClass.text = BattleStateMachine.players[i].CharacterClassEnum.ToString();
        userLevel.text = GameInformation.PlayerLevel.ToString();
        userCurrHealth.text = BattleStateMachine.CurrentPlayerHP[i].ToString();
        userMaxHealth.text = BattleStateMachine.MaxPlayerHP[i].ToString();
        userHealthImage.fillAmount = (float)BattleStateMachine.CurrentPlayerHP[i] / (BattleStateMachine.MaxPlayerHP[i]);
        userCurrMana.text = BattleStateMachine.CurrentPlayerMP[i].ToString();
        userMaxMana.text = BattleStateMachine.MaxPlayerMP[i].ToString();
        userManaImage.fillAmount = (float)BattleStateMachine.CurrentPlayerMP[i] / (BattleStateMachine.MaxPlayerMP[i]);
        userCurrPowerPoints.text = BattleStateMachine.PowerPoints[BattleStateMachine.currentUser].ToString();
        userPowerPointsImage.fillAmount = (float)BattleStateMachine.PowerPoints[BattleStateMachine.currentUser] / 10;
    }
    private void CurrentNpc() {
        byte i = (byte)(BattleStateMachine.currentUser - BattleStateMachine.numPlayers);
        userName.text = BattleStateMachine.npcs[i].CreatureName;
        userClass.text = BattleStateMachine.npcs[i].NpcClass.ToString();
        userLevel.text = BattleStateMachine.npcs[i].NpcLevel.ToString();
        userCurrHealth.text = BattleStateMachine.npcs[i].CurrentHealthPoints.ToString();
        userMaxHealth.text = BattleStateMachine.npcs[i].MaxHealthPoints.ToString();
        userHealthImage.fillAmount = (float)BattleStateMachine.npcs[i].CurrentHealthPoints / (BattleStateMachine.npcs[i].MaxHealthPoints);
        userCurrMana.text = BattleStateMachine.npcs[i].CurrentManaPoints.ToString();
        userMaxMana.text = BattleStateMachine.npcs[i].MaxManaPoints.ToString();
        userManaImage.fillAmount = (float)BattleStateMachine.npcs[i].CurrentManaPoints / (BattleStateMachine.npcs[i].MaxManaPoints);
        userCurrPowerPoints.text = BattleStateMachine.PowerPoints[BattleStateMachine.currentUser].ToString();
        userPowerPointsImage.fillAmount = (float)BattleStateMachine.PowerPoints[BattleStateMachine.currentUser] / 10;
    }
    private void CurrentEnemy() {
        byte i = (byte)(BattleStateMachine.currentUser - 4);
        userName.text = BattleStateMachine.monsters[i].CreatureName;
        targetClass.text = BattleStateMachine.monsters[i].MonsterClass.ToString();
        targetLevel.text = BattleStateMachine.monsters[i].MonsterLevel.ToString();
        targetCurrHealth.text = BattleStateMachine.monsters[i].CurrentHealthPoints.ToString();
        targetMaxHealth.text = BattleStateMachine.monsters[i].MaxHealthPoints.ToString();
        targetHealthImage.fillAmount = (float)BattleStateMachine.monsters[i].CurrentHealthPoints / (BattleStateMachine.monsters[i].MaxHealthPoints);
        targetCurrMana.text = BattleStateMachine.monsters[i].CurrentManaPoints.ToString();
        targetMaxMana.text = BattleStateMachine.monsters[i].MaxManaPoints.ToString();
        targetManaImage.fillAmount = (float)BattleStateMachine.monsters[i].CurrentManaPoints / (BattleStateMachine.monsters[i].MaxManaPoints);
        targetCurrPowerPoints.text = BattleStateMachine.PowerPoints[BattleStateMachine.currentUser].ToString();
        targetPowerPointsImage.fillAmount = (float)BattleStateMachine.PowerPoints[BattleStateMachine.currentUser] / 10;
    }
    private void CurrentDefault() {
        userName.text = "Waiting";
        userClass.text = "for target";
        userLevel.text = "0";
        userCurrHealth.text = "90";
        userMaxHealth.text = "100";
        userHealthImage.fillAmount = 90f / 100;
        userCurrMana.text = "70";
        userMaxMana.text = "100";
        userManaImage.fillAmount = 70f / 100;
        userCurrPowerPoints.text = "1";
        userPowerPointsImage.fillAmount = 1f / 10;
    }

    private void Target(bool setter) {
        //Debug.Log("targetChosen: " + BattleStateMachine.targetChosen + " players# " + BattleStateMachine.numPlayers);
        if(BattleStateMachine.targetChosen < BattleStateMachine.numPlayers && BattleStateMachine.targetChosen < 4) {
            TargetPlayer();
            targetData.color = Color.cyan;
        }
        else if(BattleStateMachine.targetChosen < (BattleStateMachine.numNpcs + BattleStateMachine.numPlayers) && BattleStateMachine.targetChosen < 4) {
            TargetNpc();
            targetData.color = Color.yellow;
        }
        else if(BattleStateMachine.targetChosen - 4 < BattleStateMachine.numEnemies && BattleStateMachine.targetChosen > 3) {
            TargetEnemy();
            targetData.color = Color.magenta;
        }
        else {
            TargetDefault();
            targetData.color = Color.gray;
        }
        targetData.gameObject.SetActive(setter);
    }
    private void TargetPlayer() {
        byte i = BattleStateMachine.targetChosen;
        //Debug.Log(BattleStateMachine.players[i].CreatureName);
        targetName.text = GameInformation.PlayerName;
        targetClass.text = BattleStateMachine.players[i].CharacterClassEnum.ToString();
        targetLevel.text = GameInformation.PlayerLevel.ToString();
        targetCurrHealth.text = BattleStateMachine.CurrentPlayerHP[i].ToString();
        targetMaxHealth.text = BattleStateMachine.MaxPlayerHP[i].ToString();
        targetHealthImage.fillAmount = (float)BattleStateMachine.CurrentPlayerHP[i] / (BattleStateMachine.MaxPlayerHP[i]);
        targetCurrMana.text = BattleStateMachine.CurrentPlayerMP[i].ToString();
        targetMaxMana.text = BattleStateMachine.MaxPlayerMP[i].ToString();
        targetManaImage.fillAmount = (float)BattleStateMachine.CurrentPlayerMP[i] / (BattleStateMachine.MaxPlayerMP[i]);
        targetCurrPowerPoints.text = BattleStateMachine.PowerPoints[BattleStateMachine.targetChosen].ToString();
        targetPowerPointsImage.fillAmount = (float)BattleStateMachine.PowerPoints[BattleStateMachine.targetChosen] / 10;
    }
    private void TargetNpc() {
        byte i = (byte)(BattleStateMachine.targetChosen - BattleStateMachine.numPlayers);
        targetName.text = BattleStateMachine.npcs[i].CreatureName;
        targetClass.text = BattleStateMachine.npcs[i].NpcClass.ToString();
        targetLevel.text = BattleStateMachine.npcs[i].NpcLevel.ToString();
        targetCurrHealth.text = BattleStateMachine.npcs[i].CurrentHealthPoints.ToString();
        targetMaxHealth.text = BattleStateMachine.npcs[i].MaxHealthPoints.ToString();
        targetHealthImage.fillAmount = (float)BattleStateMachine.npcs[i].CurrentHealthPoints / (BattleStateMachine.npcs[i].MaxHealthPoints);
        targetCurrMana.text = BattleStateMachine.npcs[i].CurrentManaPoints.ToString();
        targetMaxMana.text = BattleStateMachine.npcs[i].MaxManaPoints.ToString();
        targetManaImage.fillAmount = (float)BattleStateMachine.npcs[i].CurrentManaPoints / (BattleStateMachine.npcs[i].MaxManaPoints);
        targetCurrPowerPoints.text = BattleStateMachine.PowerPoints[BattleStateMachine.targetChosen].ToString();
        targetPowerPointsImage.fillAmount = targetPowerPointsImage.fillAmount = (float)BattleStateMachine.PowerPoints[BattleStateMachine.targetChosen] / 10;
    }
    private void TargetEnemy() {
        byte i = (byte)(BattleStateMachine.targetChosen - 4);
        targetName.text = BattleStateMachine.monsters[i].CreatureName;
        targetClass.text = BattleStateMachine.monsters[i].MonsterClass.ToString();
        targetLevel.text = BattleStateMachine.monsters[i].MonsterLevel.ToString();
        targetCurrHealth.text = BattleStateMachine.monsters[i].CurrentHealthPoints.ToString();
        targetMaxHealth.text = BattleStateMachine.monsters[i].MaxHealthPoints.ToString();
        targetHealthImage.fillAmount = (float)BattleStateMachine.monsters[i].CurrentHealthPoints / (BattleStateMachine.monsters[i].MaxHealthPoints);
        targetCurrMana.text = BattleStateMachine.monsters[i].CurrentManaPoints.ToString();
        targetMaxMana.text = BattleStateMachine.monsters[i].MaxManaPoints.ToString();
        targetManaImage.fillAmount = (float)BattleStateMachine.monsters[i].CurrentManaPoints / (BattleStateMachine.monsters[i].MaxManaPoints);
        targetCurrPowerPoints.text = BattleStateMachine.PowerPoints[BattleStateMachine.targetChosen].ToString();
        targetPowerPointsImage.fillAmount = targetPowerPointsImage.fillAmount = (float)BattleStateMachine.PowerPoints[BattleStateMachine.targetChosen] / 10;
    }
    private void TargetDefault() {
        targetName.text = "Waiting";
        targetClass.text = "for target";
        targetLevel.text = "0";
        targetCurrHealth.text = "90";
        targetMaxHealth.text = "100";
        targetHealthImage.fillAmount = 90f / 100;
        targetCurrMana.text = "70";
        targetMaxMana.text = "100";
        targetManaImage.fillAmount = 70f / 100;
        targetCurrPowerPoints.text = "1";
        targetPowerPointsImage.fillAmount = 1f / 10;
    }

    private void Targetable(bool setter) {
        //battleCanvas.enabled = !setter;
        if(setter) {
            if(Input.GetMouseButtonDown(0)) {
                if(!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if(Physics.Raycast(ray, out hit)) {
                        if(hit.collider.gameObject.tag == "Player") {
                            //Debug.Log(hit.collider.gameObject.name);
                            switch(hit.collider.gameObject.name) {
                                case ("AgentPlayer00"):
                                    Target(0);
                                    break;
                                case ("AgentPlayer01"):
                                    Target(1);
                                    break;
                                case ("AgentPlayer10"):
                                    Target(2);
                                    break;
                                case ("AgentPlayer11"):
                                    Target(3);
                                    break;
                                case ("AgentMonster00"):
                                    Target(4);
                                    break;
                                case ("AgentMonster01"):
                                    Target(5);
                                    break;
                                case ("AgentMonster10"):
                                    Target(6);
                                    break;
                                case ("AgentMonster11"):
                                    Target(7);
                                    break;
                                default:
                                    Target(9);
                                    break;
                            }
                        }
                    }
                }
            }
        }
        else {
            targetData.gameObject.SetActive(setter);
        }
    }
    public void Target(int num) {
        targetView = true;
        if(num < 0 || num > 7) {
            return;
        }
        BattleStateMachine.targetChosen = (byte)num;
        //Debug.Log("num:" + num);
        if(BattleStateMachine.currentUser < 4) {
            if(BattleStateMachine.currentUser < BattleStateMachine.players.Count) {
                Debug.Log("PlayerChoice");
                //turn playerCoice on and buttons on
                playerChoice.gameObject.SetActive(true);
                attack.gameObject.SetActive(true);
                defend.gameObject.SetActive(true);
                skills.gameObject.SetActive(true);
                items.gameObject.SetActive(true);
                if(!BattleInfomation.Scriptable) {
                    escape.gameObject.SetActive(true);
                }
                untarget.gameObject.SetActive(true);
                skillItem.gameObject.SetActive(false);
                use.gameObject.SetActive(false);
                toggle.Initialize();
            }
        }
    }
    //need to work on this
    private BaseSkills[] skillToUse = new BaseSkills[20];
    public void ButtonWork(int num) {
        switch(num) {
            case (0): //attack
                targetView = true;
                playerChoice.gameObject.SetActive(false);
                BattleStateMachine.usedSkill = GameInformation.PlayerSkills[0];
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.addStatusEffects;
                break;
            case (1): //defend
                targetView = true;
                playerChoice.gameObject.SetActive(false);
                BattleStateMachine.usedSkill = GameInformation.PlayerSkills[1];
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.addStatusEffects;
                break;
            case (2): //skills
                attack.gameObject.SetActive(false);
                defend.gameObject.SetActive(false);
                skills.gameObject.SetActive(false);
                items.gameObject.SetActive(false);
                if(!BattleInfomation.Scriptable) {
                    escape.gameObject.SetActive(false);
                }
                untarget.gameObject.SetActive(false);
                skillItem.gameObject.SetActive(true);
                //Debug.Log("before loop: " + GameInformation.PlayerSkills.Count);
                for(int i = 0; i < toggle.Length; i++) {
                    //Debug.Log("i: " + i + " i+2: " + (i + 2));
                    if(GameInformation.PlayerSkills.Count <= (i + 2)) {
                        break;
                    }
                    else if(GameInformation.PlayerSkills[i + 2].SkillID > 0) {
                        toggle[i].gameObject.SetActive(true);
                        skillToUse[i] = GameInformation.PlayerSkills[i + 2];
                        label[i].text = skillToUse[i].SkillName;
                    }
                }
                break;
            case (3): //items
                attack.gameObject.SetActive(false);
                defend.gameObject.SetActive(false);
                skills.gameObject.SetActive(false);
                items.gameObject.SetActive(false);
                if(!BattleInfomation.Scriptable) {
                    escape.gameObject.SetActive(false);
                }
                untarget.gameObject.SetActive(false);
                skillItem.gameObject.SetActive(true);
                for(int i = 0; i < toggle.Length; i++) {
                    int j = 0;
                    //Debug.Log("i: " + i + " i+2: " + (i + 2));
                    if(GameInformation.items.Length <= j) {
                        break;
                    }
                    else if(GameInformation.items[j] > 0) {
                        BaseInvoItems useItem = new BaseInvoItems();
                        useItem = RPGItemDatabase.FetchItemByID(GameInformation.items[j]);
                        if(useItem.InventoryBattle) {
                            j++;
                            //need to make a skill data base
                            skillToUse[j] = skillToUse[j];
                            toggle[j].gameObject.SetActive(true);
                        }
                        else {

                        }
                        
                        skillToUse[i] = GameInformation.PlayerSkills[i + 2];
                        label[i].text = skillToUse[i].SkillName;
                    }
                }
                break;
            case (4): //escape
                attack.gameObject.SetActive(false);
                defend.gameObject.SetActive(false);
                skills.gameObject.SetActive(false);
                items.gameObject.SetActive(false);
                if(!BattleInfomation.Scriptable) {
                    escape.gameObject.SetActive(false);
                }
                untarget.gameObject.SetActive(false);
                EscapePanel.gameObject.SetActive(true);
                break;
            case (5): //untarget
                targetView = false;
                playerChoice.gameObject.SetActive(false);
                break;
            case (6): //use
                targetView = true;
                skillItem.gameObject.SetActive(false);
                toggle.Initialize();
                use.gameObject.SetActive(false);
                BattleStateMachine.currentState = BattleStateMachine.BattleStates.addStatusEffects;
                break;
            case (7): //back
                attack.gameObject.SetActive(true);
                defend.gameObject.SetActive(true);
                skills.gameObject.SetActive(true);
                items.gameObject.SetActive(true);
                if(!BattleInfomation.Scriptable) {
                    escape.gameObject.SetActive(true);
                }
                untarget.gameObject.SetActive(true);
                skillItem.gameObject.SetActive(false);
                break;
            case (8): //Escape yes

                break;
            case (9): //Escape no
                attack.gameObject.SetActive(true);
                defend.gameObject.SetActive(true);
                skills.gameObject.SetActive(true);
                items.gameObject.SetActive(true);
                if(!BattleInfomation.Scriptable) {
                    escape.gameObject.SetActive(true);
                }
                untarget.gameObject.SetActive(true);
                EscapePanel.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
    public void Toggles(int num) {
        if(toggle[num].isOn) {
            for(int i = 0; i < toggle.Length; i++) {
                if(num == i) {
                    BattleStateMachine.usedSkill = skillToUse[num];
                    use.gameObject.SetActive(true);
                }
                else if(toggle[i].isOn) {
                    toggle[i].isOn = false;
                }
            }
        }
        else {
            use.gameObject.SetActive(false);
        }
    }

    private void SetUp() {
        setUp = true;
        byte i;
        for(i = 0; i < BattleStateMachine.players.Count; i++) {
            switch(i) {
                case (0):
                    player00.gameObject.SetActive(true);
                    playerAgent00.gameObject.SetActive(true);
                    break;
                case (1):
                    player01.gameObject.SetActive(true);
                    playerAgent01.gameObject.SetActive(true);
                    break;
                case (2):
                    player10.gameObject.SetActive(true);
                    playerAgent10.gameObject.SetActive(true);
                    break;
                case (3):
                    player11.gameObject.SetActive(true);
                    playerAgent11.gameObject.SetActive(true);
                    break;
            }
        }
        for(byte j = i; j < BattleStateMachine.npcs.Count + BattleStateMachine.players.Count; j++) {
            switch(j) {
                case (1):
                    player01.gameObject.SetActive(true);
                    playerAgent01.gameObject.SetActive(true);
                    break;
                case (2):
                    player10.gameObject.SetActive(true);
                    playerAgent10.gameObject.SetActive(true);
                    break;
                case (3):
                    player11.gameObject.SetActive(true);
                    playerAgent11.gameObject.SetActive(true);
                    break;
            }
        }
        for(i = 0; i < BattleStateMachine.monsters.Count; i++) {
            switch(i) {
                case (0):
                    enemy00.gameObject.SetActive(true);
                    monsterAgent00.gameObject.SetActive(true);
                    break;
                case (1):
                    enemy01.gameObject.SetActive(true);
                    monsterAgent01.gameObject.SetActive(true);
                    break;
                case (2):
                    enemy10.gameObject.SetActive(true);
                    monsterAgent10.gameObject.SetActive(true);
                    break;
                case (3):
                    enemy11.gameObject.SetActive(true);
                    monsterAgent11.gameObject.SetActive(true);
                    break;
            }
        }
        StartCoroutine(LocationSetUP());
        StartCoroutine(InitialDirection());
    }
    //to show
    private IEnumerator LocationSetUP() {
        //num = 4;
        yield return new WaitForSeconds(.01f);
        switch(BattleStateMachine.typeOfBattle) {
            case (0):
                //give buff to enemy
                //enemy surronds player
                /*InnerOuter(player00, enemy00, 0);
                InnerOuter(player01, enemy01, 1);
                InnerOuter(player10, enemy10, 2);
                InnerOuter(player11, enemy11, 3);*/
                InnerOuter(playerAgent00, monsterAgent00, 0);
                InnerOuter(playerAgent01, monsterAgent01, 1);
                InnerOuter(playerAgent10, monsterAgent10, 2);
                InnerOuter(playerAgent11, monsterAgent11, 3);
                break;
            case (1):
                //give buff to enemy
                //player and enemy swap
                /*Swap(player00, enemy00);
                Swap(player01, enemy01);
                Swap(player10, enemy10);
                Swap(player11, enemy11);*/
                Swap(playerAgent00, monsterAgent00);
                Swap(playerAgent01, monsterAgent01);
                Swap(playerAgent10, monsterAgent10);
                Swap(playerAgent11, monsterAgent11);
                break;
            case (3):
                //give buff to player
                //do not need to move them
                break;
            case (4):
                //give buff to player
                //player surronds enemy
                /*InnerOuter(enemy00, player00, 0);
                InnerOuter(enemy01, player01, 1);
                InnerOuter(enemy10, player10, 2);
                InnerOuter(enemy11, player11, 3);*/
                InnerOuter(monsterAgent00, playerAgent00, 0);
                InnerOuter(monsterAgent01, playerAgent01, 1);
                InnerOuter(monsterAgent10, playerAgent10, 2);
                InnerOuter(monsterAgent11, playerAgent11, 3);
                break;
            default:
                //no buffs
                //no movement
                //will be 2, but for now it is testing
                break;
        }
    }
    /*private void Swap(Button button1, Button button2) {
        Vector3 tempPostion;
        tempPostion = button1.transform.position;
        button1.transform.position = button2.transform.position;
        button2.transform.position = tempPostion;
    }*/
    private void Swap(NavMeshAgent agent1, NavMeshAgent agent2) {
        Vector3 tempPostion;
        tempPostion = agent1.transform.position;
        agent1.Warp(agent2.transform.position);
        agent2.Warp(tempPostion);
    }
    /*private void InnerOuter(Button button1, Button button2, byte num) {
        Vector3 tempPostion;
        if(num % 2 == 0) {
            tempPostion = button2.transform.position;
        }
        else {
            tempPostion = button1.transform.position;
        }
        button1.transform.position = (button1.transform.position + button2.transform.position) / 2;
        button2.transform.position = tempPostion;
    }*/
    private void InnerOuter(NavMeshAgent agent1, NavMeshAgent agent2, byte num) {
        Vector3 tempPostion;
        if(num % 2 == 0) {
            tempPostion = agent2.transform.position;
        }
        else {
            tempPostion = agent1.transform.position;
        }
        agent1.Warp((agent1.transform.position + agent2.transform.position) / 2);
        agent2.Warp(tempPostion);
    }

    //direction stuff
    private IEnumerator InitialDirection() {
        //might need to add time to this if the players, npcs, enemies are facing down
        const float timeToWait = .1f;
        yield return new WaitForSeconds(timeToWait);
        //Debug.Log("Monster X: " + monsterAgent00.transform.position.x);
        //Debug.Log("Player X: " + playerAgent00.transform.position.x);

        //acutally uses sprite_movement which is a better way to do this
        InitialDirectionProper();

        //old method which does work, but understand if you would want to go away from this.
        //InitialDirectionOld();
    }

    private void InitialDirectionProper() {
        const float left = 7f, right = 9f;
        if(monsterAgent00.transform.position.x < left) {
            testDirection(4, Direction.RIGHT);
            if(monsterAgent10.isActiveAndEnabled)
                testDirection(6, Direction.RIGHT);
        }
        else if(monsterAgent00.transform.position.x > right) {
            testDirection(4, Direction.LEFT);
            if(monsterAgent10.isActiveAndEnabled)
                testDirection(6, Direction.LEFT);
        }
        else if(monsterAgent00.transform.position.x >= left) {
            testDirection(4, Direction.RIGHT);
            if(monsterAgent10.isActiveAndEnabled)
                testDirection(6, Direction.RIGHT);
        }

        if(monsterAgent01.isActiveAndEnabled) {
            if(monsterAgent01.transform.position.x < left) {
                testDirection(5, Direction.RIGHT);
                if(monsterAgent11.isActiveAndEnabled)
                    testDirection(7, Direction.RIGHT);
            }
            else if(monsterAgent01.transform.position.x > right) {
                testDirection(5, Direction.LEFT);
                if(monsterAgent11.isActiveAndEnabled)
                    testDirection(7, Direction.LEFT);
            }
            else if(monsterAgent01.transform.position.x >= left) {
                testDirection(5, Direction.LEFT);
                if(monsterAgent11.isActiveAndEnabled)
                    testDirection(7, Direction.LEFT);
            }
        }

        if(playerAgent00.transform.position.x < left) {
            testDirection(0, Direction.RIGHT);
            if(playerAgent10.isActiveAndEnabled)
                testDirection(2, Direction.RIGHT);
        }
        else if(playerAgent00.transform.position.x > right) {
            testDirection(0, Direction.LEFT);
            if(playerAgent10.isActiveAndEnabled)
                testDirection(2, Direction.LEFT);
        }
        else if(playerAgent00.transform.position.x >= left) {
            testDirection(0, Direction.LEFT);
            if(playerAgent10.isActiveAndEnabled)
                testDirection(2, Direction.LEFT);
        }

        if(playerAgent01.isActiveAndEnabled) {
            if(playerAgent01.transform.position.x < left) {
                testDirection(1, Direction.RIGHT);
                if(playerAgent11.isActiveAndEnabled)
                    testDirection(3, Direction.RIGHT);
            }
            else if(playerAgent01.transform.position.x > right) {
                testDirection(1, Direction.LEFT);
                if(playerAgent11.isActiveAndEnabled)
                    testDirection(3, Direction.LEFT);
            }
            else if(playerAgent01.transform.position.x >= left) {
                testDirection(1, Direction.RIGHT);
                if(playerAgent11.isActiveAndEnabled)
                    testDirection(3, Direction.RIGHT);
            }
        }
    }

    private void InitialDirectionOld() {
        const float left = 7f, right = 9f;
        if(monsterAgent00.transform.position.x < left) {
            testDirection(enemy00.GetComponent<Animator>(), Direction.RIGHT);
            if(monsterAgent10.isActiveAndEnabled)
                testDirection(enemy10.GetComponent<Animator>(), Direction.RIGHT);
        }
        else if(monsterAgent00.transform.position.x > right) {
            testDirection(enemy00.GetComponent<Animator>(), Direction.LEFT);
            if(monsterAgent10.isActiveAndEnabled)
                testDirection(enemy10.GetComponent<Animator>(), Direction.LEFT);
        }
        else if(monsterAgent00.transform.position.x >= left) {
            testDirection(enemy00.GetComponent<Animator>(), Direction.RIGHT);
            if(monsterAgent10.isActiveAndEnabled)
                testDirection(enemy10.GetComponent<Animator>(), Direction.RIGHT);
        }

        if(monsterAgent01.isActiveAndEnabled) {
            if(monsterAgent01.transform.position.x < left) {
                testDirection(enemy01.GetComponent<Animator>(), Direction.RIGHT);
                if(monsterAgent11.isActiveAndEnabled)
                    testDirection(enemy11.GetComponent<Animator>(), Direction.RIGHT);
            }
            else if(monsterAgent01.transform.position.x > right) {
                testDirection(enemy01.GetComponent<Animator>(), Direction.LEFT);
                if(monsterAgent11.isActiveAndEnabled)
                    testDirection(enemy11.GetComponent<Animator>(), Direction.LEFT);
            }
            else if(monsterAgent01.transform.position.x >= left) {
                testDirection(enemy01.GetComponent<Animator>(), Direction.LEFT);
                if(monsterAgent11.isActiveAndEnabled)
                    testDirection(enemy11.GetComponent<Animator>(), Direction.LEFT);
            }
        }

        if(playerAgent00.transform.position.x < left) {
            testDirection(player00.GetComponent<Animator>(), Direction.RIGHT);
            if(playerAgent10.isActiveAndEnabled)
                testDirection(player10.GetComponent<Animator>(), Direction.RIGHT);
        }
        else if(playerAgent00.transform.position.x > right) {
            testDirection(player00.GetComponent<Animator>(), Direction.LEFT);
            if(playerAgent10.isActiveAndEnabled)
                testDirection(player10.GetComponent<Animator>(), Direction.LEFT);
        }
        else if(playerAgent00.transform.position.x >= left) {
            testDirection(player00.GetComponent<Animator>(), Direction.LEFT);
            if(playerAgent10.isActiveAndEnabled)
                testDirection(player10.GetComponent<Animator>(), Direction.LEFT);
        }

        if(playerAgent01.isActiveAndEnabled) {
            if(playerAgent01.transform.position.x < left) {
                testDirection(player01.GetComponent<Animator>(), Direction.RIGHT);
                if(playerAgent11.isActiveAndEnabled)
                    testDirection(player11.GetComponent<Animator>(), Direction.RIGHT);
            }
            else if(playerAgent01.transform.position.x > right) {
                testDirection(player01.GetComponent<Animator>(), Direction.LEFT);
                if(playerAgent11.isActiveAndEnabled)
                    testDirection(player11.GetComponent<Animator>(), Direction.LEFT);
            }
            else if(playerAgent01.transform.position.x >= left) {
                testDirection(player01.GetComponent<Animator>(), Direction.RIGHT);
                if(playerAgent11.isActiveAndEnabled)
                    testDirection(player11.GetComponent<Animator>(), Direction.RIGHT);
            }
        }
    }

    //proper way to do it
    private void testDirection(byte testByte, Direction tester) {
        Debug.Log(testByte + " start");
        switch(testByte) {
            case (0):
                SPM = player00.GetComponent<Sprite_Movement>();
                break;
            case (1):
                SPM = player01.GetComponent<Sprite_Movement>();
                break;
            case (2):
                SPM = player10.GetComponent<Sprite_Movement>();
                break;
            case (3):
                SPM = player11.GetComponent<Sprite_Movement>();
                break;
            case (4):
                SPM = enemy00.GetComponent<Sprite_Movement>();
                break;
            case (5):
                SPM = enemy01.GetComponent<Sprite_Movement>();
                break;
            case (6):
                SPM = enemy10.GetComponent<Sprite_Movement>();
                break;
            case (7):
                SPM = enemy11.GetComponent<Sprite_Movement>();
                break;
            default:
                SPM = null;
                break;
        }
        Debug.Log(testByte + " middle");
        
        switch(tester) {
            case (Direction.RIGHT):
                SPM.SetAction(2,0);
                break;
            case (Direction.LEFT):
                SPM.SetAction(4, 0);
                break;
            case (Direction.UP):
                SPM.SetAction(1, 0);
                break;
            case (Direction.DOWN):
                SPM.SetAction(3, 0);
                break;
            default:
                break;
        }
        Debug.Log(testByte + " end");
    }

    //works, but is not the proper way to do it.
    private void testDirection(Animator animator, Direction tester) {
        switch(tester) {
            case (Direction.RIGHT):
                animator.SetFloat("x", 1f);
                animator.SetFloat("y", 0f);
                animator.SetBool("isWalking", true);
                break;
            case (Direction.LEFT):
                animator.SetFloat("x", -1f);
                animator.SetFloat("y", 0f);
                animator.SetBool("isWalking", true);
                break;
            case (Direction.UP):
                animator.SetFloat("x", 0f);
                animator.SetFloat("y", 1f);
                animator.SetBool("isWalking", false);
                break;
            case (Direction.DOWN):
                animator.SetFloat("x", 0f);
                animator.SetFloat("y", -1f);
                animator.SetBool("isWalking", false);
                break;
            default:
                animator.SetBool("isWalking", false);
                break;
        }
    }
}
