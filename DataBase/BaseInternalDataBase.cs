using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;

public class BaseInternalDataBase {
    //might want to be able to do both, since this is how most game work
    //"/StreamingAssests/DataBase/xxx.json" these assests are after build you just upload these files
    const string streamingAssests = "/StreamingAssests/DataBase/";
    //"/Scripts/DataBase/xxx.json" these assests are included in the normal build
    const string dataBase = "/Scripts/DataBase/";

    protected static string path = dataBase; //should act more like a const, but maybe we want both
    protected static JsonData itemData;

    //different internal databases
    protected static List<BaseInvoItems> databaseInvoItems = new List<BaseInvoItems>();
    protected static List<BaseArmors> databaseArmors = new List<BaseArmors>();
    protected static List<BaseWeapons> databaseWeapons = new List<BaseWeapons>();
    //not done
    protected static List<BaseSkills> databaseSkills = new List<BaseSkills>();
    protected static List<BaseStatusEffects> databaseStatusEffects = new List<BaseStatusEffects>();
    protected static List<BaseMonsterClasses> databaseMonster = new List<BaseMonsterClasses>();
    protected static List<BaseNPC> databaseNPC = new List<BaseNPC>();

    //required by the constructers of the DBs to make shorten them a bit
    protected static object ItemTypes(int i, string type) {
        switch(type.ToLower()) {
            //items
            case "itemtype":
                return System.Enum.Parse(typeof(BaseItems.ItemTypes), itemData[i][type].ToString().ToUpper());
            case "invoitemtype":
                return System.Enum.Parse(typeof(BaseInvoItems.InvoItemTypes), itemData[i][type].ToString().ToUpper());
            case "potiontype":
                return System.Enum.Parse(typeof(BaseInvoItems.PotionTypes), itemData[i][type].ToString().ToUpper());
            case "whocanequip":
                return System.Enum.Parse(typeof(BaseStatItems.WhoCanEquips), itemData[i][type].ToString().ToUpper());
            case "weapontype":
                return System.Enum.Parse(typeof(BaseWeapons.WeaponTypes), itemData[i][type].ToString().ToUpper());
            case "armortype":
                return System.Enum.Parse(typeof(BaseArmors.ArmorTypes), itemData[i][type].ToString().ToUpper());
            //skills
            case "physmaginot":
                return System.Enum.Parse(typeof(BaseSkills.PhysMagiNot), itemData[i][type].ToString().ToUpper());
            case "powertypeone":
            case "powertypetwo":
                return System.Enum.Parse(typeof(BaseSkills.PowerTypes), itemData[i][type].ToString().ToUpper());
            //status effects
            case "statchange1":
            case "statchange2":
                return System.Enum.Parse(typeof(BaseStatusEffects.StatChanges), itemData[i][type].ToString().ToUpper());
            //NPC data
            case "npcclass":
                return System.Enum.Parse(typeof(BaseNPC.NpcClasses), itemData[i][type].ToString().ToUpper());
            //monster data
            case "monsterclass":
                return System.Enum.Parse(typeof(BaseMonsterClasses.MonsterClasses), itemData[i][type].ToString().ToUpper());
            default:
                Debug.Log("Not a valid string: " + type);
                return null;
        }
    }
}
