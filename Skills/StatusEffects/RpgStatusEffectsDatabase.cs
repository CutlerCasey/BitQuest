using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class RpgStatusEffectsDatabase: BaseInternalDataBase {
    const string items = "statusEffects";

    public static void BuildItemDatabases() {
        ConstructStatusEffectsDataBase();
        //TestFetchers();
    }

    public static BaseStatusEffects FetchStatusEffectByID(int id) {
        for(int i = 0; i < databaseStatusEffects.Count; i++) {
            if(databaseStatusEffects[i].StatusEffectID == id) {
                //Debug.Log("ID found will not always work");
                return databaseStatusEffects[i];
            }
        }
        Debug.Log("No status effect by ID found");
        return null;
    }

    //constructors of the Database
    private static void ConstructStatusEffectsDataBase() {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + path + items + ".json"));
        for(int i = 0; i < itemData.Count; i++) {
            /*for(int j = 0; j < itemData[i].Count; j++) {
              Debug.Log("i: " + i + ", j: " + j + ", itemData: " + itemData[i][j]);
            }*/
            databaseStatusEffects.Add(new BaseStatusEffects(
                (int)itemData[i]["id"], itemData[i]["name"].ToString(), itemData[i]["description"].ToString(),
                (int)itemData[i]["applypercent"], (int)itemData[i]["effectdmg"], (int)itemData[i]["staypercent"], (int)itemData[i]["minturns"], (int)itemData[i]["maxturns"],
                (BaseStatusEffects.StatChanges)ItemTypes(i, "statchange1"), (int)itemData[i]["statmulti1"], (BaseStatusEffects.StatChanges)ItemTypes(i, "statchange2"), (int)itemData[i]["statmulti2"]
                ));
        }
    }
}
