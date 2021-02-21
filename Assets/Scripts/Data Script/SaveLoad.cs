using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad {


    public static void CreateFile()
    {
        string path = Application.persistentDataPath + "/save.hai";
        if (File.Exists(path))
        {
            Debug.Log(path);
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            path = Application.persistentDataPath + "/save.hai";
            FileStream stream = new FileStream(path, FileMode.Create);
            LevelData data = new LevelData();
            formatter.Serialize(stream, data);
            stream.Close();
        }
    }
    public static void SaveSystem(int level, int star, int itemCount, int unlock)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.hai";
        LevelData data = LoadSystem();
        FileStream stream = new FileStream(path, FileMode.Create);
        data.SaveData(level, star, itemCount, 1);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LevelData LoadSystem()
    {
        string path = Application.persistentDataPath + "/save.hai";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();
            return data;
        } else
        {
            Debug.Log(path);
            Debug.LogError("File not Found");
            return null;
        }
    }
}
