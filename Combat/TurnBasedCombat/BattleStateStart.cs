using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class BattleStateStart {
    //random stats
    private StatCalculations statCalculations = new StatCalculations();
    private CalcDerivedOther statDerivedOther = new CalcDerivedOther();
    private CalcDerivedHP statDerivedHP = new CalcDerivedHP();
    private CalcDerivedMP statDerivedMP = new CalcDerivedMP();
    //used for enemy level
    const byte variance = 2;
    //random
    //enemies
    private string[] enemyNames = new string[4] { "Deadly", "Fierce", "Subtle", "Powerful"};
    private BaseMonsterClasses[] monsterClassTypes = new BaseMonsterClasses[] {
        new MonsterWarriorClass(),
        new MonsterBMageClass(),
        new MonsterWMageClass(),
        new MonsterRougeClass()
    };
    //npcs
    private BaseNPC newNpc = new BaseNPC();
    private string[] ncpNames = new string[] { "Bold", "Confident", "Knowledgeable", "Scared" };
    private BaseNPC[] npcClass = new BaseNPC[] {
        new NpcWarriorClass(),
        new NpcBMageClass(),
        new NpcRougeClass(),
        new NpcWMageClass()
    };

    //only thing to call from the machine
    public IEnumerator PrepareTheBattle() {
        //Resources.UnloadUnusedAssets();
        numOfNpcs();
        //number of enemies
        numOfEnemies();
        //create players
        DeterminePlayerVitals();
        //create enemy
        enemyCreation();
        //create npc, if needed
        npcCreation();
        //type of battle
        typeOfBattle();
        //based on the previous start time of every thing in battle
        startTurnLocation();
        //slow down
        ScreenFader use = new ScreenFader();
        yield return new WaitForSeconds(use.fadeTime);
        //wait
        BattleStateMachine.currentState = BattleStateMachine.BattleStates.WAIT;
    }

    //1 to 4 or ammount we said, unless > 4
    private void numOfNpcs() {
        if(BattleInfomation.IsRandomBattle) {
            BattleStateMachine.numNpcs = (byte)Random.Range(0, 4);
            if((BattleStateMachine.numNpcs + BattleStateMachine.numPlayers) > 4) {
                BattleStateMachine.numNpcs = (byte)(4 - BattleStateMachine.numPlayers);
            }
        }
        else {
        }
    }
    //1 to 4 or ammount we said, unless > 4
    private void numOfEnemies() {
        Debug.Log("NumOfEnemies: " + BattleInfomation.AmmountOfEnemies + " isRand: " + BattleInfomation.IsRandomBattle);
        if(BattleInfomation.IsRandomBattle || BattleInfomation.AmmountOfEnemies > 4) {
            int tempNum = BattleStateMachine.numPlayers + BattleStateMachine.numNpcs;
            BattleStateMachine.numEnemies = (byte)Random.Range(tempNum - 1, tempNum + 2);
            if(BattleStateMachine.numEnemies < 1)
                BattleStateMachine.numEnemies = 1;
            else if(BattleStateMachine.numEnemies > 4)
                BattleStateMachine.numEnemies = 4;
        }
        else {
            BattleStateMachine.numEnemies = BattleInfomation.AmmountOfEnemies;
        }
    }

    //calls for Preparing the battle
    private void enemyCreation() {
        if(BattleInfomation.IsRandomBattle || BattleInfomation.AmmountOfEnemies > 4) {
            CreateRandomNewEnemy();
        }
        else {
            CollectEnemyData();
        }
    }
    private void npcCreation() {
        if(BattleInfomation.IsRandomBattle || BattleInfomation.AmmountOfEnemies > 4) {
            CreateRandomNewNpc();
        }
    }
    //need to work on, basic sturcture is there
    private void typeOfBattle() {
        byte enemies = BattleStateMachine.numEnemies, players = BattleStateMachine.numPlayers, npcs = BattleStateMachine.numNpcs;
        float tempRnd = Random.value;
        if(BattleInfomation.IsRandomBattle || BattleInfomation.TypeOfBattle > 4) {
            //if enemies > players + npcs
            if(enemies > (players + npcs)) {
                //good for enemy bad for player
                if(tempRnd > .7f) { //30%
                    BattleStateMachine.typeOfBattle = 2; //normal
                }
                else if(tempRnd > .35f) { //35%
                    BattleStateMachine.typeOfBattle = 1; //back attack
                }
                else if(tempRnd > .05f) { //30%
                    BattleStateMachine.typeOfBattle = 0; //surronded
                }
                else {
                    typeOfBattle();
                    return;
                }
            }
            //else if enemies < players + npcs
            else if(enemies < (players + npcs)) {
                //good for player bad for enemy
                if(tempRnd > .70f) { //30%
                    BattleStateMachine.typeOfBattle = 2; //normal
                }
                else if(tempRnd > .35f) { //35%
                    BattleStateMachine.typeOfBattle = 3; //premtive
                }
                else if(tempRnd > .05f) { //30%
                    BattleStateMachine.typeOfBattle = 4; //pincer
                }
                else {
                    typeOfBattle();
                    return;
                }
            }
            //else if enemies == players + npcs
            else if(enemies == (players + npcs)) {
                //totaly random
                if(tempRnd > .6f) { //40%
                    BattleStateMachine.typeOfBattle = 2; //normal
                }
                else if(tempRnd > .3f) { //30%
                    BattleStateMachine.typeOfBattle = 1; //back attack
                }
                else if(tempRnd > .0f) { //30%
                    BattleStateMachine.typeOfBattle = 3; //premtive
                }
                else {
                    typeOfBattle();
                    return;
                }
            }
        }
        else {
            BattleStateMachine.typeOfBattle = BattleInfomation.TypeOfBattle; //2 is normal
        }
        Debug.Log("typeOfBattle:" + BattleStateMachine.typeOfBattle);
    }
    //need to work on, 1 v 1 is there, but not good enough
    private void startTurnLocation() {
        BattleStateMachine.PowerPoints.Initialize();
        if(BattleStateMachine.typeOfBattle == 2) {
            //location equals 0 for all
            for(byte i = 0; i < BattleStateMachine.whosTurn.Length; i++) {
                BattleStateMachine.whosTurn[i] = 0;
            }
        }
        else if(BattleStateMachine.typeOfBattle == 1) {
            //location equals 0 for party & 255/2 for enemies
            for(byte i = 0; i < BattleStateMachine.whosTurn.Length; i++) {
                BattleStateMachine.whosTurn[i] = 0;
                if(i > 3) {
                    BattleStateMachine.whosTurn[i] = 250/2;
                }
            }
        }
        else if(BattleStateMachine.typeOfBattle == 0) {
            //location equals 0 for party & 255 for enemies
            for(byte i = 0; i < BattleStateMachine.whosTurn.Length; i++) {
                BattleStateMachine.whosTurn[i] = 0;
                if(i > 3) {
                    BattleStateMachine.PowerPoints[i] = 2;
                    BattleStateMachine.whosTurn[i] = 250;
                }
            }
        }
        else if(BattleStateMachine.typeOfBattle == 3) {
            //location equals 255/2 for party & 0 for enemies
            for(byte i = 0; i < BattleStateMachine.whosTurn.Length; i++) {
                BattleStateMachine.whosTurn[i] = 0;
                if(i < 4) {
                    BattleStateMachine.whosTurn[i] = 250 / 2;
                }
            }
        }
        else if(BattleStateMachine.typeOfBattle == 4) {
            //location equals 255 for party & 0 for enemies
            for(byte i = 0; i < BattleStateMachine.whosTurn.Length; i++) {
                BattleStateMachine.whosTurn[i] = 0;
                if(i < 4) {
                    BattleStateMachine.PowerPoints[i] = 2;
                    BattleStateMachine.whosTurn[i] = 250;
                }
            }
        }
    }

    //random creation
    private void CreateRandomNewNpc() {
        byte lowLevel = (byte)(GameInformation.PlayerLevel - variance < 1 ? 1 : GameInformation.PlayerLevel - variance);
        byte highLevel = (byte)(GameInformation.PlayerLevel + variance);
        RndBaseStats rndBaseStats = new RndBaseStats();

        for(byte i = 0; i < BattleStateMachine.numNpcs; i++) {
            //enemy information
            BattleStateMachine.npcs.Add(new BaseNPC());
            BattleStateMachine.npcs[i].NpcClass = npcClass[Random.Range(0, monsterClassTypes.Length)].NpcClass; //randomly chooses class out the the array
            BattleStateMachine.npcs[i].SpriteModel = npcClass[i].SpriteModel;
            BattleStateMachine.npcs[i].CreatureName = enemyNames[Random.Range(0, enemyNames.Length)] + " " + BattleStateMachine.monsters[i].MonsterClass.ToString() + " Npc";
            BattleStateMachine.npcs[i].NpcLevel = (byte)Random.Range(lowLevel, highLevel + 1);
            Debug.Log("name: " + BattleStateMachine.npcs[i].CreatureName + " lvl: " + BattleStateMachine.npcs[i].NpcLevel);
            //none derived to something random
            ushort newEnemyTotal = (ushort)((ushort)(BattleStateMachine.npcs[i].Strength + BattleStateMachine.npcs[i].Strength) + (ushort)(BattleStateMachine.npcs[i].Stamina + BattleStateMachine.npcs[i].Intelect) + (ushort)(BattleStateMachine.npcs[i].Vitality + BattleStateMachine.npcs[i].Spirit));
            BattleStateMachine.npcs[i].Strength = rndBaseStats.CalculateRndStat(newEnemyTotal, BattleStateMachine.npcs[i].Strength, BattleStateMachine.npcs[i].NpcLevel, true);
            BattleStateMachine.npcs[i].Agility = rndBaseStats.CalculateRndStat(newEnemyTotal, BattleStateMachine.npcs[i].Agility, BattleStateMachine.npcs[i].NpcLevel, true);
            BattleStateMachine.npcs[i].Stamina = rndBaseStats.CalculateRndStat(newEnemyTotal, BattleStateMachine.npcs[i].Stamina, BattleStateMachine.npcs[i].NpcLevel, true);
            BattleStateMachine.npcs[i].Intelect = rndBaseStats.CalculateRndStat(newEnemyTotal, BattleStateMachine.npcs[i].Intelect, BattleStateMachine.npcs[i].NpcLevel, true);
            BattleStateMachine.npcs[i].Vitality = rndBaseStats.CalculateRndStat(newEnemyTotal, BattleStateMachine.npcs[i].Vitality, BattleStateMachine.npcs[i].NpcLevel, true);
            BattleStateMachine.npcs[i].Spirit = rndBaseStats.CalculateRndStat(newEnemyTotal, BattleStateMachine.npcs[i].Spirit, BattleStateMachine.npcs[i].NpcLevel, true);
            //Debug.Log("str: " + BattleStateMachine.npcs[i].Strength + " vit: " + BattleStateMachine.npcs[i].Vitality);
            //derived stats
            BattleStateMachine.npcs[i].AttackPower = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.npcs[i].Strength, BattleStateMachine.npcs[i].NpcLevel, 2, StatCalculations.DerivedStatTypes.AttackPower);
            BattleStateMachine.npcs[i].MagicPower = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.npcs[i].Intelect, BattleStateMachine.npcs[i].NpcLevel, 2, StatCalculations.DerivedStatTypes.MagicPower);
            BattleStateMachine.npcs[i].Speed = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.npcs[i].Agility, BattleStateMachine.npcs[i].NpcLevel, 2, StatCalculations.DerivedStatTypes.Speed);
            BattleStateMachine.npcs[i].PhyDmgNeg = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.npcs[i].Vitality, BattleStateMachine.npcs[i].NpcLevel, 2, StatCalculations.DerivedStatTypes.PhyDmgNeg);
            BattleStateMachine.npcs[i].MagDmgNeg = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.npcs[i].Spirit, BattleStateMachine.npcs[i].NpcLevel, 2, StatCalculations.DerivedStatTypes.MagDmgNeg);
            BattleStateMachine.npcs[i].MaxHealthPoints = statDerivedHP.CalculateRndDerivedStatUshort(BattleStateMachine.npcs[i].Stamina, BattleStateMachine.npcs[i].NpcLevel, 2, StatCalculations.DerivedStatTypes.HealthPoints);
            BattleStateMachine.npcs[i].CurrentHealthPoints = BattleStateMachine.npcs[i].MaxHealthPoints;
            BattleStateMachine.npcs[i].MaxManaPoints = statDerivedMP.CalculateRndDerivedStatUshort(BattleStateMachine.npcs[i].Intelect, BattleStateMachine.npcs[i].Spirit, BattleStateMachine.npcs[i].NpcLevel, 2);
            BattleStateMachine.npcs[i].CurrentManaPoints = BattleStateMachine.npcs[i].MaxManaPoints;
            Debug.Log("Speed: " + BattleStateMachine.npcs[i].Speed + " PhyDmgNeg: " + BattleStateMachine.monsters[i].PhyDmgNeg + " HP: " + BattleStateMachine.monsters[i].MaxHealthPoints + " MP: " + BattleStateMachine.monsters[i].MaxManaPoints);
        }
    }
    private void CreateRandomNewEnemy() {
        byte lowLevel = (byte)(GameInformation.PlayerLevel - variance < 1 ? 1 : GameInformation.PlayerLevel - variance);
        byte highLevel = (byte)(GameInformation.PlayerLevel + variance);
        RndBaseStats rndBaseStats = new RndBaseStats();

        for(byte i = 0; i < BattleStateMachine.numEnemies; i++) {
            //enemy information
            BattleStateMachine.monsters.Add(new BaseMonsterClasses());
            BattleStateMachine.monsters[i].MonsterClass = monsterClassTypes[Random.Range(0, monsterClassTypes.Length)].MonsterClass; //randomly chooses class out the the array
            BattleStateMachine.monsters[i].SpriteModel = monsterClassTypes[i].SpriteModel;
            BattleStateMachine.monsters[i].CreatureName = enemyNames[Random.Range(0, enemyNames.Length)] + " " + BattleStateMachine.monsters[i].MonsterClass.ToString() + " Enemy";
            BattleStateMachine.monsters[i].MonsterLevel = (byte)Random.Range(lowLevel, highLevel + 1);
            Debug.Log("name: " + BattleStateMachine.monsters[i].CreatureName + " lvl: " + BattleStateMachine.monsters[i].MonsterLevel);
            //none derived to something random
            ushort newEnemyTotal = (ushort)((ushort)(BattleStateMachine.monsters[i].Strength + BattleStateMachine.monsters[i].Strength) + (ushort)(BattleStateMachine.monsters[i].Stamina + BattleStateMachine.monsters[i].Intelect) + (ushort)(BattleStateMachine.monsters[i].Vitality + BattleStateMachine.monsters[i].Spirit));
            BattleStateMachine.monsters[i].Strength = rndBaseStats.CalculateRndStat(newEnemyTotal, BattleStateMachine.monsters[i].Strength, BattleStateMachine.monsters[i].MonsterLevel, true);
            BattleStateMachine.monsters[i].Agility = rndBaseStats.CalculateRndStat(newEnemyTotal, BattleStateMachine.monsters[i].Agility, BattleStateMachine.monsters[i].MonsterLevel, true);
            BattleStateMachine.monsters[i].Stamina = rndBaseStats.CalculateRndStat(newEnemyTotal, BattleStateMachine.monsters[i].Stamina, BattleStateMachine.monsters[i].MonsterLevel, true);
            BattleStateMachine.monsters[i].Intelect = rndBaseStats.CalculateRndStat(newEnemyTotal, BattleStateMachine.monsters[i].Intelect, BattleStateMachine.monsters[i].MonsterLevel, true);
            BattleStateMachine.monsters[i].Vitality = rndBaseStats.CalculateRndStat(newEnemyTotal, BattleStateMachine.monsters[i].Vitality, BattleStateMachine.monsters[i].MonsterLevel, true);
            BattleStateMachine.monsters[i].Spirit = rndBaseStats.CalculateRndStat(newEnemyTotal, BattleStateMachine.monsters[i].Spirit, BattleStateMachine.monsters[i].MonsterLevel, true);
            //Debug.Log("str: " + BattleStateMachine.monsters[i].Strength + " vit: " + BattleStateMachine.monsters[i].Vitality);
            //derived stats
            BattleStateMachine.monsters[i].AttackPower = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.monsters[i].Strength, BattleStateMachine.monsters[i].MonsterLevel, 2, StatCalculations.DerivedStatTypes.AttackPower);
            BattleStateMachine.monsters[i].MagicPower = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.monsters[i].Intelect, BattleStateMachine.monsters[i].MonsterLevel, 2, StatCalculations.DerivedStatTypes.MagicPower);
            BattleStateMachine.monsters[i].Speed = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.monsters[i].Agility, BattleStateMachine.monsters[i].MonsterLevel, 2, StatCalculations.DerivedStatTypes.Speed);
            BattleStateMachine.monsters[i].PhyDmgNeg = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.monsters[i].Vitality, BattleStateMachine.monsters[i].MonsterLevel, 2, StatCalculations.DerivedStatTypes.PhyDmgNeg);
            BattleStateMachine.monsters[i].MagDmgNeg = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.monsters[i].Spirit, BattleStateMachine.monsters[i].MonsterLevel, 2, StatCalculations.DerivedStatTypes.MagDmgNeg);
            BattleStateMachine.monsters[i].MaxHealthPoints = statDerivedHP.CalculateRndDerivedStatUshort(BattleStateMachine.monsters[i].Stamina, BattleStateMachine.monsters[i].MonsterLevel, 2, StatCalculations.DerivedStatTypes.HealthPoints);
            BattleStateMachine.monsters[i].CurrentHealthPoints = BattleStateMachine.monsters[i].MaxHealthPoints;
            BattleStateMachine.monsters[i].MaxManaPoints = statDerivedMP.CalculateRndDerivedStatUshort(BattleStateMachine.monsters[i].Intelect, BattleStateMachine.monsters[i].Spirit, BattleStateMachine.monsters[i].MonsterLevel, 2);
            BattleStateMachine.monsters[i].CurrentManaPoints = BattleStateMachine.monsters[i].MaxManaPoints;
            BattleStateMachine.monsters[i].MoneyOut = (uint)((BattleStateMachine.monsters[i].MaxHealthPoints + BattleStateMachine.monsters[i].MaxManaPoints) * (Random.value + .01f));
            BattleStateMachine.monsters[i].ExpOut = (uint)((BattleStateMachine.monsters[i].AttackPower + BattleStateMachine.monsters[i].Speed) * (Random.value + .01f));
            Debug.Log("Speed: " + BattleStateMachine.monsters[i].Speed + " PhyDmgNeg: " + BattleStateMachine.monsters[i].PhyDmgNeg + " HP: " + BattleStateMachine.monsters[i].MaxHealthPoints + " MP: " + BattleStateMachine.monsters[i].MaxManaPoints);
        }
    }

    //known creation, still needs work
    private void CollectEnemyData() {
        if(BattleInfomation.AmmountOfEnemies == 1) {
            if(BattleInfomation.Enemy00 == 1) {
                byte i = 0;
                BattleStateMachine.monsters.Add(new BaseMonsterClasses());
                BattleStateMachine.monsters[i].MonsterClass = monsterClassTypes[i].MonsterClass; //warrior
                BattleStateMachine.monsters[i].SpriteModel = "NPCBMage_m";
                BattleStateMachine.monsters[i].CreatureName = "An Evil Bandit";
                BattleStateMachine.monsters[i].MonsterLevel = 1;
                Debug.Log("name: " + BattleStateMachine.monsters[i].CreatureName + " lvl: " + BattleStateMachine.monsters[i].MonsterLevel);
                //none derived to something random
                BattleStateMachine.monsters[i].Strength = 1;
                BattleStateMachine.monsters[i].Agility = 2;
                BattleStateMachine.monsters[i].Stamina = 2;
                BattleStateMachine.monsters[i].Intelect = 2;
                BattleStateMachine.monsters[i].Vitality = 2;
                BattleStateMachine.monsters[i].Spirit = 2;
                //derived stats
                BattleStateMachine.monsters[i].AttackPower = 1;
                BattleStateMachine.monsters[i].MagicPower = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.monsters[i].Intelect, BattleStateMachine.monsters[i].MonsterLevel, 2, StatCalculations.DerivedStatTypes.MagicPower);
                BattleStateMachine.monsters[i].Speed = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.monsters[i].Agility, BattleStateMachine.monsters[i].MonsterLevel, 2, StatCalculations.DerivedStatTypes.Speed);
                BattleStateMachine.monsters[i].PhyDmgNeg = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.monsters[i].Vitality, BattleStateMachine.monsters[i].MonsterLevel, 2, StatCalculations.DerivedStatTypes.PhyDmgNeg);
                BattleStateMachine.monsters[i].MagDmgNeg = statDerivedOther.CalculateRndDerivedStatByte(BattleStateMachine.monsters[i].Spirit, BattleStateMachine.monsters[i].MonsterLevel, 2, StatCalculations.DerivedStatTypes.MagDmgNeg);
                BattleStateMachine.monsters[i].MaxHealthPoints = 2;
                BattleStateMachine.monsters[i].CurrentHealthPoints = BattleStateMachine.monsters[i].MaxHealthPoints;
                BattleStateMachine.monsters[i].MaxManaPoints = statDerivedMP.CalculateRndDerivedStatUshort(BattleStateMachine.monsters[i].Intelect, BattleStateMachine.monsters[i].Spirit, BattleStateMachine.monsters[i].MonsterLevel, 2);
                BattleStateMachine.monsters[i].CurrentManaPoints = BattleStateMachine.monsters[i].MaxManaPoints;
                BattleStateMachine.monsters[i].MoneyOut = (uint)((BattleStateMachine.monsters[i].MaxHealthPoints + BattleStateMachine.monsters[i].MaxManaPoints) * (Random.value + .01f)) + 10;
                BattleStateMachine.monsters[i].ExpOut = (uint)((BattleStateMachine.monsters[i].AttackPower + BattleStateMachine.monsters[i].Speed) * (Random.value + .01f)) + 10;
            }
        }
        else {
            CreateRandomNewEnemy();
        }
    }

    private void DeterminePlayerVitals() {
        Debug.Log("Have to remove TestPlayer!");
        //TestPlayer(); //comment out when the game exist
        for(byte i = 0; i < BattleStateMachine.numPlayers; i++) {
            BattleStateMachine.players.Add(new BaseCharacterClass());
            Debug.Log("Before creatureName: " + GameInformation.PlayerName);
            BattleStateMachine.players[i].CreatureName = GameInformation.PlayerName;
            Debug.Log("after creatureName: " + BattleStateMachine.players[i].CreatureName);
            BattleStateMachine.players[i].CharacterClassEnum = GameInformation.PlayerClass;
            BattleStateMachine.players[i].Agility = GameInformation.Agility;
            BattleStateMachine.players[i].Strength = GameInformation.Strength;
            BattleStateMachine.players[i].Stamina = GameInformation.Stamina;
            BattleStateMachine.players[i].Spirit = GameInformation.Spirit;
            BattleStateMachine.players[i].Vitality = GameInformation.Vitality;
            BattleStateMachine.players[i].Intelect = GameInformation.Intelect;
            BattleStateMachine.playerAttPow[i] = statDerivedOther.CalculateDerivedStatByte(BattleStateMachine.players[i].Strength, 0, StatCalculations.DerivedStatTypes.AttackPower);
            BattleStateMachine.playerMagPow[i] = statDerivedOther.CalculateDerivedStatByte(BattleStateMachine.players[i].Intelect, 0, StatCalculations.DerivedStatTypes.MagicPower);
            BattleStateMachine.playerSpeed[i] = statDerivedOther.CalculateDerivedStatByte(BattleStateMachine.players[i].Agility, 0, StatCalculations.DerivedStatTypes.Speed);
            BattleStateMachine.playerPhyDef[i] = statDerivedOther.CalculateDerivedStatByte(BattleStateMachine.players[i].Vitality, 0, StatCalculations.DerivedStatTypes.PhyDmgNeg);
            BattleStateMachine.playerMagDef[i] = statDerivedOther.CalculateDerivedStatByte(BattleStateMachine.players[i].Spirit, 0, StatCalculations.DerivedStatTypes.MagDmgNeg);
            BattleStateMachine.MaxPlayerHP[i] = statDerivedHP.CalculateDerivedStatUshort(BattleStateMachine.players[i].Stamina, 0, StatCalculations.DerivedStatTypes.HealthPoints);
            BattleStateMachine.MaxPlayerMP[i] = statDerivedMP.CalculateDerivedStatUshort(BattleStateMachine.players[i].Intelect, BattleStateMachine.players[i].Spirit, 0);
            byte tempHpMp = 100;
            switch(BattleInfomation.MaxSettingHpMp) {
                case (0):
                    tempHpMp = 100;
                    break;
                case (1):
                    tempHpMp = 75;
                    break;
                case (2):
                    tempHpMp = 50;
                    break;
                case (3):
                    tempHpMp = 25;
                    break;
                case (4):
                    tempHpMp = 1;
                    break;
            }
            BattleStateMachine.CurrentPlayerHP[i] = tempHpMp == 1 ? (ushort)1 : (ushort)(BattleStateMachine.MaxPlayerHP[i] * tempHpMp / 100);
            Debug.Log("temp: " + tempHpMp + " HP:" + BattleStateMachine.CurrentPlayerHP[i] + " / " + BattleStateMachine.MaxPlayerHP[i] + " speed: " + BattleStateMachine.playerSpeed[i]);
            BattleStateMachine.CurrentPlayerMP[i] = tempHpMp == 1 ? (ushort)1 : (ushort)(BattleStateMachine.MaxPlayerMP[i] * tempHpMp / 100);
        }
    }
    private void TestPlayer() {
        //pure testing
        if(string.IsNullOrEmpty(GameInformation.PlayerName)) {
            BaseBMageClass rouge = new BaseBMageClass();
            GameInformation.PlayerClass = BaseCharacterClass.CharacterClasses.ROUGE;
            GameInformation.PlayerName = "Deatho0ne";
            byte multiple = 10;
            GameInformation.Strength = (byte)(rouge.RecStr * multiple);
            GameInformation.Agility = (byte)(rouge.RecAgi * multiple);
            GameInformation.Stamina = (byte)(rouge.RecSta * multiple);
            GameInformation.Spirit = (byte)(rouge.RecSpi * multiple);
            GameInformation.Vitality = (byte)(rouge.RecVit * multiple);
            GameInformation.Intelect = (byte)(rouge.RecInt * multiple);
            GameInformation.PlayerLevel = 1;
            GameInformation.SpriteString = "Base Female";
            GameInformation.PlayerSkills.Add(new Attack());
            GameInformation.PlayerSkills.Add(new Defend());
            GameInformation.PlayerSkills.Add(new Defend());
            for(int i = 0; i < 5; i++) {
                GameInformation.items[i] = (byte)(i + 1);
            }
        }
    }
}
