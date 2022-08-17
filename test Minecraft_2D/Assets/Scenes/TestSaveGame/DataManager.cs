using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public PlayerData data;

    public string file = "player.txt";

    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);
    }
    public void Load()
    {

    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter write = new StreamWriter(fileName))
        {
            write.Write(json);
        }
    }

    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader render = new StreamReader(fileName))
            {
                string json = render.ReadToEnd();
                return json;
            }
        }
        else
            Debug.LogWarning("File not found!");
        return "";
    }

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}
