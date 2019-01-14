using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class RpgMonsterDatabase: BaseInternalDataBase {
    const string items = "monster";

    public static void BuildItemDatabases() {
        ConstructMonsterDataBase();
        //TestFetchers();
    }

    public static BaseMonsterClasses FetchSkillByID(int id) {
        for(int i = 0; i < databaseMonster.Count; i++) {
            if(databaseMonster[i].MonsterId == id) {
                //Debug.Log("ID found will not always work");
                return databaseMonster[i];
            }
        }
        Debug.Log("No monster by ID found");
        return null;
    }

    //constructors of the Database
    private static void ConstructMonsterDataBase() {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + path + items + ".json"));
        for(int i = 0; i < itemData.Count; i++) {
            /*for(int j = 0; j < itemData[i].Count; j++) {
              Debug.Log("i: " + i + ", j: " + j + ", itemData: " + itemData[i][j]);
            }*/
            databaseMonster.Add(new BaseMonsterClasses(
                (int)itemData[i]["id"], itemData[i]["name"].ToString(), itemData[i]["description"].ToString(), itemData[i]["spritemodel"].ToString(),
                (BaseMonsterClasses.MonsterClasses)ItemTypes(i, "class"), (byte)itemData[i]["level"],
                (byte)itemData[i]["str"], (byte)itemData[i]["intel"], (byte)itemData[i]["agi"], (byte)itemData[i]["sta"], (byte)itemData[i]["vit"], (byte)itemData[i]["spi"],
                (byte)itemData[i]["attpower"], (byte)itemData[i]["magpower"], (byte)itemData[i]["speed"], (byte)itemData[i]["phydmgneg"], (byte)itemData[i]["magdmgneg"],
                (ushort)itemData[i]["maxhealthpoints"], (ushort)itemData[i]["maxmanapoints"],
                (uint)itemData[i]["moneyout"], (uint)itemData[i]["expout"]
                ));
        }
    }
}
