using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveInformation {
    const string saveType = ".dat";
    private static string playerName = "Need a name";
    private static PlayerData data = new PlayerData();
    private static UserInformation user = new UserInformation();
    private static BinaryFormatter bf = new BinaryFormatter();
    private static FileStream file;

    //should not be used for the most part
    public static void SaveAllinformation() {
        SaveAccountInformation();
        SaveAccountInformation();
        SaveNameBioGender();
    }
    //when creating an account
    public static void SaveAccountInformation() {
        playerName = GameInformation.UserName;
        if(Create()) {
            user.userName = playerName;
            user.password = GameInformation.Password;
            user.admin = GameInformation.Admin;
            user.isOffline = GameInformation.IsOffline;
            Close();
        }
        else {
            Debug.Log("AccountInformation did not save.");
        }
    }
    //when creating a char
    public static void SaveNameBioGender() {
        playerName = GameInformation.PlayerName;
        if(Create()) {
            data.playerName = playerName;
            data.playerBio = GameInformation.PlayerBio;
            data.isMale = GameInformation.IsMale;
            Close();
            SaveStatsInformation();
        }
        else {
            Debug.Log("NameBioGender did not save.");
        }
    }
    //when in game
    public static void SaveStatsInformation() {
        playerName = GameInformation.PlayerName;
        if(Create()) {
            data.playerClass = (byte)GameInformation.PlayerClass;
            data.money = GameInformation.Money;
            data.playerCurrentExp = GameInformation.PlayerCurrentExp;
            data.playerRequiriredExp = GameInformation.PlayerRequriredExp;
            data.level = GameInformation.PlayerLevel;
            data.skillPoints = GameInformation.SkillPoints;
            
            data.strength = GameInformation.Strength;
            data.agility = GameInformation.Agility;
            data.intellect = GameInformation.Intelect;
            data.stamina = GameInformation.Stamina;
            data.spirit = GameInformation.Spirit;
            data.vitalitiy = GameInformation.Vitality;

            data.EvilGood = GameInformation.EvilGood;
            data.LawChaos = GameInformation.LawChaos;
            data.NeutralPshyco = GameInformation.NeutralPshyco;

            data.quest = GameInformation.quest;
            data.battleNum = GameInformation.battleNum;
            data.items = GameInformation.items;

            data.equipedArmorBody = GameInformation.equipedArmorBody;
            data.equipedArmorFeet = GameInformation.equipedArmorFeet;
            data.equipedArmorHead = GameInformation.equipedArmorHead;
            data.equipedArmorLegs = GameInformation.equipedArmorLegs;
            data.equipedArmorNeck = GameInformation.equipedArmorNeck;
            data.equipedArmorRing = GameInformation.equipedArmorRing;
            data.equipedOffHand = GameInformation.equipedOffHand;
            data.equipedWeapon = GameInformation.equipedWeapon;

            //data.PlayerSkills = GameInformation.PlayerSkills;

            data.spriteString = GameInformation.SpriteString;
            data.hairSprite = GameInformation.HairSprite;
            data.skinSprite = GameInformation.SkinSprite;
            NavMeshAgent agentPosition = new NavMeshAgent();
            int currScene = SceneManager.GetActiveScene().buildIndex;
            if(currScene != 0 && currScene != 2) {
               agentPosition = GameObject.Find("Agent").GetComponent<NavMeshAgent>();
            }

            GameInformation.Position = agentPosition.transform.position;
            Debug.Log("Save x: " + GameInformation.Position.x + " z: " + GameInformation.Position.z);
            data.positionX = GameInformation.Position.x;
            data.positionY = GameInformation.Position.y;
            data.positionZ = GameInformation.Position.z;

            GameInformation.SceneAt = SceneManager.GetActiveScene().name;
            data.sceneAt = GameInformation.SceneAt;
            //data.rotation = GameInformation.Rotation;
            Close();
        }
        else {
            Debug.Log("Stats did not save.");
        }
    }

    private static bool Create() { //creates or replaces
        try {
            Debug.Log(Application.persistentDataPath + "/" + playerName + "_Save" + saveType); //so we can know
            file = File.Create(Application.persistentDataPath + "/" + playerName + "_Save" + saveType);
            return true;
        }
        catch(Exception e) {
            Debug.Log("Open Create Error: " + e);
            return false;
        }
    }
    private static void Close() {
        bf.Serialize(file, data);
        file.Close();
    }

    //sort of what we need
    public static void SaveSettings() {
        string[] options = new string[6] {
            "Sound Volume",
            "Music Volume",
            "Alpha",
            "Beta",
            "Gamma",
            "Delta"
        };
        for(int i = 0; i < options.Length; i++) {
            PPSerialzation.Save(options[i], 10);
        }
    }
}
