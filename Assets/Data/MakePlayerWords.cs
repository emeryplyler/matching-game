using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class MakePlayerWords : MonoBehaviour
{
    public PlayerWordsScriptable playerWords; // instance of scriptable object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerWords = ScriptableObject.CreateInstance<PlayerWordsScriptable>();
        playerWords.allPlayerWords = makeTempList();

        ReadFile("Assets/Data/PlayerWordFile.json");

        // WriteFile("Assets/Data/PlayerWordFile.json");
        playerWords.display();

    }

    List<PlayerWord> makeTempList() // just generate the user's words for now
    {
        List<PlayerWord> list = new List<PlayerWord>{};
        list.Add(new PlayerWord("cat", 3, 2));
        list.Add(new PlayerWord("dog", 2, 1));
        list.Add(new PlayerWord("me", 6, 1));
        list.Add(new PlayerWord("you", 5, 1));
        list.Add(new PlayerWord("I", 4, 2));
        list.Add(new PlayerWord("am", 3, 4));
        list.Add(new PlayerWord("is", 3, 5));
        return list;
    }

    void ReadFile(string path) 
    {
        if (File.Exists(path)) 
        {
            string infoString = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(infoString, playerWords);
        }
        else
        {
            Debug.Log("JSON path not found");
        }
        
    }

    void WriteFile(string path)
    {
        string infoString = JsonUtility.ToJson(playerWords);
        File.WriteAllText(path, infoString);
    }
}
