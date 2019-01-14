using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;

public class RPGItemDatabase: BaseInternalDataBase {
    //will make more const as needed
    const string items = "items", weapons = "weapons", armors = "armors";

    //should be in start or run
    public static void BuildItemDatabases() {
        ConstructItemDataBase();
        ConstructWeaponDataBase();
        ConstructArmorDataBase();
        //TestFetchers();
    }
    //to test any new fetchers we may include later
    private static void TestFetchers() {
        //test the fetcher and several types at fist .ItemName did not work basic items
        Debug.Log(FetchItemByID(0).ItemTag);
        Debug.Log(FetchArmorByTag("Whatever_WARRIOR_PANTS").ItemTag);
    }

    //single fetchers
    //id fetchers
    public static BaseInvoItems FetchItemByID(int id) {
        for(int i = 0; i < databaseInvoItems.Count; i++) {
            if(databaseInvoItems[i].ItemID == id) {
                //Debug.Log("ID found will not always work");
                return databaseInvoItems[i];
            }
        }
        Debug.Log("No item by ID found");
        return null;
    }
    public static BaseArmors FetchArmorByID(int id) {
        for(int i = 0; i < databaseArmors.Count; i++) {
            if(databaseArmors[i].ItemID == id) {
                //Debug.Log("ID found will not always work");
                return databaseArmors[i];
            }
        }
        Debug.Log("No armor by ID found");
        return null;
    }
    public static BaseWeapons FetchWeaponByID(int id) {
        for(int i = 0; i < databaseWeapons.Count; i++) {
            if(databaseWeapons[i].ItemID == id) {
                //Debug.Log("ID found will not always work");
                return databaseWeapons[i];
            }
        }
        Debug.Log("No weapon by ID found");
        return null;
    }
    //tag fetchers
    public static BaseInvoItems FetchItemByTag(string tag) {
        for(int i = 0; i < databaseInvoItems.Count; i++) {
            if(databaseInvoItems[i].ItemTag == tag) {
                //Debug.Log("Tag found should work based that it is name + extra stuff to identify it");
                return databaseInvoItems[i];
            }
        }
        Debug.Log("No item by Tag found");
        return null;
    }
    public static BaseArmors FetchArmorByTag(string tag) {
        for(int i = 0; i < databaseArmors.Count; i++) {
            if(databaseArmors[i].ItemTag == tag) {
                //Debug.Log("Tag found should work based that it is name + extra stuff to identify it");
                return databaseArmors[i];
            }
        }
        Debug.Log("No armor by Tag found");
        return null;
    }
    public static BaseWeapons FetchWeaponByTag(string tag) {
        for(int i = 0; i < databaseWeapons.Count; i++) {
            if(databaseWeapons[i].ItemTag == tag) {
                //Debug.Log("Tag found should work based that it is name + extra stuff to identify it");
                return databaseWeapons[i];
            }
        }
        Debug.Log("No weapon by Tag found");
        return null;
    }

    //constructors of the Database
    private static void ConstructItemDataBase() {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + path + items + ".json"));
        for(int i = 0; i < itemData.Count; i++) {
            /*for(int j = 0; j < itemData[i].Count; j++) {
              Debug.Log("i: " + i + ", j: " + j + ", itemData: " + itemData[i][j]);
            }*/
            databaseInvoItems.Add(new BaseInvoItems(
                (int)itemData[i]["itemid"], itemData[i]["itemname"].ToString(), itemData[i]["itemdescription"].ToString(), (bool)itemData[i]["stackable"],
                (BaseItems.ItemTypes)ItemTypes(i, "itemtype"), (bool)itemData[i]["quest"], (bool)itemData[i]["inventorybattle"], (int)itemData[i]["cost"], itemData[i]["tag"].ToString(),
                (BaseInvoItems.InvoItemTypes)ItemTypes(i, "invoitemtype"), (bool)itemData[i]["inventoryfield"], (int)itemData[i]["spelleffectsid"],
                (BaseInvoItems.PotionTypes)ItemTypes(i, "potiontype"), (bool)itemData[i]["infinteusage"]
                ));
        }
    }
    private static void ConstructWeaponDataBase() {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + path + weapons + ".json"));
        for(int i = 0; i < itemData.Count; i++) {
            /*for(int j = 0; j < itemData[i].Count; j++) {
                Debug.Log("i: " + i + ", j: " + j + ", itemData: " + itemData[i][j]);
            }*/
            databaseWeapons.Add(new BaseWeapons(
                (int)itemData[i]["itemid"], itemData[i]["itemname"].ToString(), itemData[i]["itemdescription"].ToString(), (bool)itemData[i]["stackable"],
                (BaseItems.ItemTypes)ItemTypes(i, "itemtype"), (bool)itemData[i]["quest"], (bool)itemData[i]["inventorybattle"], (int)itemData[i]["cost"], itemData[i]["tag"].ToString(),
                (bool)itemData[i]["equipable"], (BaseStatItems.WhoCanEquips)ItemTypes(i, "whocanequip"),
                (int)itemData[i]["strength"], (int)itemData[i]["intellect"], (int)itemData[i]["agility"], (int)itemData[i]["stamina"], (int)itemData[i]["vitality"], (int)itemData[i]["spirit"],
                (int)itemData[i]["attackpower"], (int)itemData[i]["magicpower"], (int)itemData[i]["speed"], (int)itemData[i]["phydmgneg"], (int)itemData[i]["magdmgneg"], (int)itemData[i]["hitpoints"], (int)itemData[i]["manapoints"],
                (int)itemData[i]["spelleffectinventoryid"], (bool)itemData[i]["spelleffectsequipedid"], (int)(itemData[i]["spelleffectequipedpercent"]),
                (BaseWeapons.WeaponTypes)ItemTypes(i, "weapontype"), (bool)itemData[i]["phyormag"]
                ));
        }
    }
    private static void ConstructArmorDataBase() {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + path + armors + ".json"));
        for(int i = 0; i < itemData.Count; i++) {
            /*for(int j = 0; j < itemData[i].Count; j++) {
                Debug.Log("i: " + i + ", j: " + j + ", itemData: " + itemData[i][j]);
            }*/
            databaseArmors.Add(new BaseArmors(
                (int)itemData[i]["itemid"], itemData[i]["itemname"].ToString(), itemData[i]["itemdescription"].ToString(), (bool)itemData[i]["stackable"],
                (BaseItems.ItemTypes)ItemTypes(i, "itemtype"), (bool)itemData[i]["quest"], (bool)itemData[i]["inventorybattle"], (int)itemData[i]["cost"], itemData[i]["tag"].ToString(),
                (bool)itemData[i]["equipable"], (BaseStatItems.WhoCanEquips)ItemTypes(i, "whocanequip"),
                (int)itemData[i]["strength"], (int)itemData[i]["intellect"], (int)itemData[i]["agility"], (int)itemData[i]["stamina"], (int)itemData[i]["vitality"], (int)itemData[i]["spirit"],
                (int)itemData[i]["attackpower"], (int)itemData[i]["magicpower"], (int)itemData[i]["speed"], (int)itemData[i]["phydmgneg"], (int)itemData[i]["magdmgneg"], (int)itemData[i]["hitpoints"], (int)itemData[i]["manapoints"],
                (int)itemData[i]["spelleffectinventoryid"], (bool)itemData[i]["spelleffectsequipedid"], (int)(itemData[i]["spelleffectequipedpercent"]),
                (BaseArmors.ArmorTypes)ItemTypes(i, "armortype")
                ));
        }
    }
}