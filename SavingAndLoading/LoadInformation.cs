using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class LoadInformation {
    const string saveType = ".dat";
    private static string playerName = "Need a name";
    private static PlayerData data = new PlayerData();
    private static UserInformation user = new UserInformation();
    private static BinaryFormatter bf = new BinaryFormatter();
    private static FileStream file;

    //should not be used for the most part
    public static void LoadAllinformation() {
        if(Open()) {
            GameInformation.UserName = user.userName;
            GameInformation.Password = user.password;
            GameInformation.Admin = user.admin;
            GameInformation.IsOffline = user.isOffline;
        }
    }
    //when creating opening account
    public static void LoadAccountInformation() {
        if(Open()) {
            GameInformation.PlayerName = data.playerName;
            GameInformation.PlayerBio = data.playerBio;
            GameInformation.IsMale = data.isMale;
            LoadStatsInformation();
        }
    }
    //when in game, which might not be included
    public static void LoadStatsInformation() {
        if(Open()) {
            GameInformation.PlayerClass = (BaseCharacterClass.CharacterClasses)data.playerClass;
            GameInformation.Money = data.money;
            GameInformation.PlayerCurrentExp = data.playerCurrentExp;
            GameInformation.PlayerRequriredExp = data.playerRequiriredExp;
            GameInformation.PlayerLevel = data.level;
            GameInformation.SkillPoints = data.skillPoints;

            GameInformation.Strength = data.strength;
            GameInformation.Agility = data.agility;
            GameInformation.Intelect = data.intellect;
            GameInformation.Stamina = data.stamina;
            GameInformation.Spirit = data.spirit;
            GameInformation.Vitality = data.vitalitiy;

            GameInformation.EvilGood = data.EvilGood;
            GameInformation.LawChaos = data.LawChaos;
            GameInformation.NeutralPshyco = data.NeutralPshyco;
            
            GameInformation.quest = data.quest;
            GameInformation.battleNum = data.battleNum;
            GameInformation.items = data.items;

            GameInformation.equipedArmorBody = data.equipedArmorBody;
            GameInformation.equipedArmorFeet = data.equipedArmorFeet;
            GameInformation.equipedArmorHead = data.equipedArmorHead;
            GameInformation.equipedArmorLegs = data.equipedArmorLegs;
            GameInformation.equipedArmorNeck = data.equipedArmorNeck;
            GameInformation.equipedArmorRing = data.equipedArmorRing;
            GameInformation.equipedOffHand = data.equipedOffHand;
            GameInformation.equipedWeapon = data.equipedWeapon;

            //GameInformation.PlayerSkills = data.PlayerSkills;

            GameInformation.SpriteString = data.spriteString;
            GameInformation.HairSprite = data.hairSprite;
            GameInformation.SkinSprite = data.skinSprite;
            Vector3 location = new Vector3();
            location.x = data.positionX;
            location.y = data.positionY;
            location.z = data.positionZ;
            Debug.Log("load x: " + location.x + " z: " + location.z);
            GameInformation.Position = location;
            
            Debug.Log("Data: " + data.sceneAt);
            GameInformation.SceneAt = data.sceneAt;
            //GameInformation.Rotation = data.rotation;
        }
    }

    private static bool Open() { //creates or replaces
        playerName = GameInformation.PlayerName;
        //Debug.Log("playerName: " + playerName);
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] files = dir.GetFiles("*" + saveType);
        foreach(FileInfo f in files) {
            string name = f.Name;
            Debug.Log("name: " + name);
            playerName = f.Name.Substring(0, name.LastIndexOf("_Save"));
            break;
        }
        Debug.Log("playerName: " + playerName);
        
        try {
            Debug.Log(Application.persistentDataPath);
            file = File.Open(Application.persistentDataPath + "/" + playerName + "_Save" + saveType, FileMode.Open);
            Debug.Log("Does it get here? 1");
            data = (PlayerData)bf.Deserialize(file);
            Debug.Log("Does it get here? 2");
            file.Close();
            return true;
        }
        catch(Exception e) {
            Debug.Log("Open Read Error: " + e);
            //GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200, 200), "No Save File!");
            return false;
        }
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
            PPSerialzation.Load(options[i]);
        }
    }
}
