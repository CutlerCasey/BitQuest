using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class RpgNpcDatabase: BaseInternalDataBase {
    const string items = "npcSet";

    public static void BuildNpcDatabase() {
        ConstructNpcDataBase();
        //TestFetchers();
    }

    public static BaseNPC FetchNpcByID(int id) {
        for(int i = 0; i < databaseNPC.Count; i++) {
            if(databaseNPC[i].NpcID == id) {
                //Debug.Log("ID found will not always work");
                return databaseNPC[i];
            }
        }
        Debug.Log("No npc by ID found");
        return null;
    }

    //constructors of the Database
    private static void ConstructNpcDataBase() {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + path + items + ".json"));
        for(int i = 0; i < itemData.Count; i++) {
            /*for(int j = 0; j < itemData[i].Count; j++) {
              Debug.Log("i: " + i + ", j: " + j + ", itemData: " + itemData[i][j]);
            }*/
            databaseNPC.Add(new BaseNPC(
                (int)itemData[i]["id"], itemData[i]["name"].ToString(), itemData[i]["description"].ToString(), itemData[i]["spritemodel"].ToString(),
                (BaseNPC.NpcClasses)ItemTypes(i, "class"), (byte)itemData[i]["level"],
                (byte)itemData[i]["str"], (byte)itemData[i]["intel"], (byte)itemData[i]["agi"], (byte)itemData[i]["sta"], (byte)itemData[i]["vit"], (byte)itemData[i]["spi"],
                (byte)itemData[i]["attpower"], (byte)itemData[i]["magpower"], (byte)itemData[i]["speed"], (byte)itemData[i]["phydmgneg"], (byte)itemData[i]["magdmgneg"],
                (ushort)itemData[i]["maxhealthpoints"], (ushort)itemData[i]["maxmanapoints"]
                ));
        }
    }
}
