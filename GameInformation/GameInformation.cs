using UnityEngine;
using System.Collections;
//next 2 required for saving to a Comp IOS/PC/Mac
using System;
using System.Collections.Generic;

public class GameInformation: MonoBehaviour {
    const byte maxByte = 250;
    private static GameInformation information; //= new GameInformation();
    void Awake() {
        //Debug.Log("GameInformaiton Awake start");
        if(information == null) {
            DontDestroyOnLoad(gameObject);
            information = this;
            //might have to move the following to out of this if, hope not the, since it would be easy to force to leave the game if an update
            //items
            RPGItemDatabase.BuildItemDatabases();
            //armors

            //weapons

            //static npcs

            //skills

        }
        else if(information != this) {
            Destroy(gameObject);
        }
        //monsters

        //Debug.Log("GameInformaiton Awake end");
        
    }

    //known player data
    private static string userName;
    private static string password = "12qw#$ER";
    private static string playerName = "Please enter a Name";
    private static string playerBio = "Please enter a Bio";
    
    private static BaseCharacterClass.CharacterClasses playerClass = new BaseCharacterClass.CharacterClasses();
    //need an intial value
    public static string UserName {
        get {
            return userName;
        }
        set {
            userName = value;
        }
    }
    public static string Password {
        get {
            return password;
        }
        set {
            password = value;
        }
    }
    //offline/online
    private static bool isOffline = true;
    public static bool IsOffline {
        get {
            return isOffline;
        }
        set {
            isOffline = value;
        }
    }
    //admin access?
    private static bool admin = false;
    public static bool Admin {
        get {
            return admin;
        }
        set {
            admin = value;
        }
    }

    public static string PlayerName {
        get {
            return playerName;
        }
        set {
            playerName = value;
        }
    }
    //just a Bio of the player
    public static string PlayerBio {
        get {
            return playerBio;
        }
        set {
            playerBio = value;
        }
    }
    //male or female?
    private static bool isMale = true;
    public static bool IsMale {
        get {
            return isMale;
        }
        set {
            isMale = value;
        }
    }

    //class of the player
    public static BaseCharacterClass.CharacterClasses PlayerClass {
        get {
            return playerClass;
        }
        set {
            playerClass = value;
        }
    }
    //money max is 9999999
    private static uint money = 0;
    public static uint Money {
        get {
            return money;
        } set {
            if(value > 9999999)
                money = 9999999;
            else
                money = value;
        }
    }
    //exp and level information max for both is 9999999
    public static uint SkillPoints {
        get;
        set;
    }
    private static uint playerCurrentExp = 0;
    public static uint PlayerCurrentExp {
        get {
            return playerCurrentExp;
        }
        set {
            if(value > 9999999)
                playerCurrentExp = 9999999;
            else
                playerCurrentExp = value;
        }
    }
    private static uint playerRequiredExp = 0;
    public static uint PlayerRequriredExp {
        get {
            return playerRequiredExp;
        }
        set {
            if(value > 9999999)
                playerRequiredExp = 9999999;
            else
                playerRequiredExp = value;
        }
    }
    //level 
    private static byte playerLevel = 1;
    public static byte PlayerLevel {
        get {
            return playerLevel;
        }
        set {
            if(value > 20)
                playerLevel = 20;
            else
                playerLevel = value;
        }
    }
    //phyiscal attack
    private static byte strength = 1;
    public static byte Strength {
        get {
            return strength;
        }
        set {
            if(value > 250)
                strength = 250;
            else if(value < 1)
                strength = 1;
            else
                strength = value;
        }
    }
    //magical attack & mana points
    private static byte intelect = 1;
    public static byte Intelect {
        get {
            return intelect;
        }
        set {
            if(value > 250)
                intelect = 250;
            else if(value < 1)
                intelect = 1;
            else
                intelect = value;
        }
    }
    //speed of attacks
    private static byte agility = 1;
    public static byte Agility {
        get {
            return agility;
        }
        set {
            if(value > maxByte)
                agility = maxByte;
            else
                agility = value;
        }
    }
    //max HP
    private static byte stamina = 1;
    public static byte Stamina {
        get {
            return stamina;
        }
        set {
            if(value > maxByte)
                stamina = maxByte;
            else if(value < 1)
                stamina = 1;
            else
                stamina = value;
        }
    }
    //physical damage negation
    private static byte vitality = 1;
    public static byte Vitality {
        get {
            return vitality;
        }
        set {
            if(value > maxByte)
                vitality = maxByte;
            else if(value < 1)
                vitality = 1;
            else
                vitality = value;
        }
    }
    //magical deamage negation & mana points
    private static byte spirit = 1;
    public static byte Spirit {
        get {
            return spirit;
        }
        set {
            if(value > maxByte)
                spirit = maxByte;
            else if(value < 1)
                spirit = 1;
            else
                spirit = value;
        }
    }
    //only making two genders, inital value of false
    //for the personality system, max is 250
    private const byte middleByte = maxByte / 2;
    private static byte evilGood = middleByte, lawChaos = middleByte, neutralPshyco = middleByte;
    public static byte EvilGood {
        get {
            return evilGood;
        }
        set {
            if(value > maxByte)
                evilGood = maxByte;
            else
                evilGood = value;
        }
    }
    public static byte LawChaos {
        get {
            return lawChaos;
        }
        set {
            if(value > maxByte)
                evilGood = maxByte;
            else
                lawChaos = value;
        }
    }
    public static byte NeutralPshyco {
        get {
            return neutralPshyco;
        }
        set {
            if(value > maxByte)
                evilGood = maxByte;
            else
                neutralPshyco = value;
        }
    }

    //quest passed or not with 255 steps
    public static byte[] quest = new byte[32];
    public static bool[] battleNum = new bool[32];
    public static byte[] items = new byte[32];
    public static byte equipedWeapon;
    public static byte equipedArmorHead;
    public static byte equipedOffHand;
    public static byte equipedArmorBody;
    public static byte equipedArmorFeet;
    public static byte equipedArmorLegs;
    public static byte equipedArmorRing;
    public static byte equipedArmorNeck;

    //dictonary of Player Skills, attack and defense needed for everyone. Just a guess of 40 skills in the end, might need to be more
    public static List<BaseSkills> PlayerSkills = new List<BaseSkills>(40) {
        new Attack(),
        new Defend()
    };

    //sprite for the character, will figure this out
    private static string spriteString;
    public static string SpriteString {
        get {
            return spriteString;
        }
        set {
            spriteString = value;
        }
    }
    public static string HairSprite {
        get; set;
    }
    public static string SkinSprite {
        get; set;
    }

    private static Vector3 position;
    public static Vector3 Position {
        get {
            return position;
        }
        set {
            position = value;
        }
    }
    public static string SceneAt {
        get;
        set;
    }

    //private static Quaternion rotation;
    /*public static Quaternion Rotation {
        get {
            return rotation;
        }
        set {
            rotation = value;
        }
    }*/

    public static void Reset() {
        UserName = default(string);
        Password = default(string);
        IsOffline = true;
        Admin = false;
        PlayerName = default(string);
        PlayerBio = default(string);
        IsMale = true;
        PlayerClass = BaseCharacterClass.CharacterClasses.NONE;
        Money = PlayerCurrentExp = PlayerRequriredExp = 0;
        PlayerLevel = Strength = Intelect = Agility = Stamina = Vitality = Spirit = 1;
        EvilGood = LawChaos = neutralPshyco = middleByte;
        for(byte i = 0; i < quest.Length; i++) {
            quest[i] = 0;
        }
        for(byte i = 0; i < battleNum.Length; i++) {
            battleNum[i] = true;
        }
        for(byte i = 0; i < items.Length; i++) {
            items[i] = 0;
        }
        equipedWeapon = equipedArmorHead = equipedOffHand = equipedArmorBody = equipedArmorFeet = equipedArmorLegs = equipedArmorRing = equipedArmorNeck = default(byte);
        SpriteString = HairSprite = SkinSprite = default(string);
        Position = default(Vector3);
        SceneAt = default(string);
    }
}

[Serializable]  //player Stats
class PlayerData {
    public string playerName = "Please enter a Name", playerBio = "Please enter a Bio";
    private byte evilGood, lawChaos, neutralPshyco;
    public byte playerClass;
    public uint money, playerCurrentExp, playerRequiriredExp, skillPoints;
    public byte level, strength, intellect, agility, stamina, vitalitiy, spirit;
    public bool isMale;

    public byte EvilGood, LawChaos, NeutralPshyco;

    public byte[] quest = new byte[32];
    public bool[] battleNum = new bool[32];
    public byte[] items = new byte[32];
    public byte equipedWeapon;
    public byte equipedArmorHead;
    public byte equipedOffHand;
    public byte equipedArmorBody;
    public byte equipedArmorFeet;
    public byte equipedArmorLegs;
    public byte equipedArmorRing;
    public byte equipedArmorNeck;

    //public List<BaseSkills> PlayerSkills = new List<BaseSkills>(40);
    public string spriteString, hairSprite, skinSprite;
    public float positionX, positionY, positionZ;
    public string sceneAt;
    //public Quaternion rotation;
}

[Serializable] //player UserName, Password, Admin
class UserInformation {
    public string userName = "test", password = "1234";
    public bool admin, isOffline;
}
