using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager
{
    public static string _dirName = "SaveData";
    public static string _fileName = "SaveFile.txt";

    public static void Save(SaveData saveData)
    {
        if (!DirectoryExists())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/" + _dirName);
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream saveFile = File.Create(GetFilePathName());
        binaryFormatter.Serialize(saveFile, saveData);
        saveFile.Close();
    }

    public static SaveData Load ()
    {
        SaveData saveData;

        if(!FileExists())
        {
            saveData = null;
            Debug.Log("Failed to load data");
        }

        else
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream loadFile = File.Open(GetFilePathName(), FileMode.Open);
                saveData = (SaveData)binaryFormatter.Deserialize(loadFile);
                loadFile.Close();
            }

            catch(SerializationException)
            {
                saveData =null;
                Debug.Log("Failed to load data");
            }
        }

        return saveData;
    }

    public static bool FileExists()
    {
        return File.Exists(GetFilePathName());
    }

    public static bool DirectoryExists()
    {
        return Directory.Exists(Application.persistentDataPath + "/" + _dirName);
    }

    public static string GetFilePathName()
    {
        return Application.persistentDataPath + "/" + _dirName + "/" + _fileName;
    }
}
