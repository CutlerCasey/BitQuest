using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class RpgSkillsDatabase: BaseInternalDataBase {
    const string items = "skills";

    public static void BuildItemDatabases() {
        ConstructSkillDataBase();
        //TestFetchers();
    }

    public static BaseSkills FetchSkillByID(int id) {
        for(int i = 0; i < databaseSkills.Count; i++) {
            if(databaseSkills[i].SkillID == id) {
                //Debug.Log("ID found will not always work");
                return databaseSkills[i];
            }
        }
        Debug.Log("No skill by ID found");
        return null;
    }

    //constructors of the Database
    private static void ConstructSkillDataBase() {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + path + items + ".json"));
        for(int i = 0; i < itemData.Count; i++) {
            /*for(int j = 0; j < itemData[i].Count; j++) {
              Debug.Log("i: " + i + ", j: " + j + ", itemData: " + itemData[i][j]);
            }*/
            databaseSkills.Add(new BaseSkills(
                (int)itemData[i]["id"], itemData[i]["name"].ToString(), itemData[i]["description"].ToString(), (BaseSkills.PhysMagiNot)ItemTypes(i, "physmaginot"),
                (BaseSkills.PowerTypes)ItemTypes(i, "powertypeone"), (int)itemData[i]["typeone"], (BaseSkills.PowerTypes)ItemTypes(i, "powertypetwo"), (int)itemData[i]["typetwo"],
                (bool)itemData[i]["crit"], (int)itemData[i]["manacost"], (int)itemData[i]["powerpointcost"], (int)itemData[i]["healthcost"],
                (int)itemData[i]["statuseffectid"]
                ));
        }
    }
}
