using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;

public class RPGSkillDatabase : BaseInternalDataBase {
    const string skills = "skills";
    public static void BuildSkillDatabase() {

        //TestFetchers();
    }

    private static void TestFetchers() {

    }


    private static void ConstructItemDataBase() {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + path + skills + ".json"));
        for(int i = 0; i < itemData.Count; i++) {
            /*for(int j = 0; j < itemData[i].Count; j++) {
              Debug.Log("i: " + i + ", j: " + j + ", itemData: " + itemData[i][j]);
            }*/
            //databaseSkills.Add();
        }
    }
}
