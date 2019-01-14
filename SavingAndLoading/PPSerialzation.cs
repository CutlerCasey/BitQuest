using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class PPSerialzation {
    public static BinaryFormatter binaryFormatter = new BinaryFormatter();

    public static void Save(string saveTag, object obj) {
        //next 3 lines convert it to a 64 bit string
        MemoryStream memoryStream = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, obj);
        string temp = System.Convert.ToBase64String(memoryStream.ToArray());

        PlayerPrefs.SetString(saveTag, temp);
    }

    public static object Load(string saveTag) {
        string temp = PlayerPrefs.GetString(saveTag);
        if(temp == string.Empty) { //checking if anything in the tag
            Debug.Log("Not loading anything");
            return null;
        }
        //next 2 lines converts it back to something that we can use
        MemoryStream memoryStream = new MemoryStream(System.Convert.FromBase64String(temp));
        return binaryFormatter.Deserialize(memoryStream);
    }
}
