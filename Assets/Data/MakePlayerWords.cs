using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using TMPro;

public class MakePlayerWords : MonoBehaviour
{
    [HideInInspector]
    public PlayerWordsScriptable playerWords; // instance of scriptable object
    
    public GameObject idea; // reference to idea prefab to instantiate

    public Transform spawnPoint1, spawnPoint2;
    public List<GameObject> ideas; // all ideas spawned in

    public List<PlayerWord> ideasToSpawn;
    public GameObject goalword; // the one they have to touch

    public bool canSpawn = true;

    public TextMeshProUGUI goalText;

    const string jsonFilePath = "Assets/Data/PlayerWordFile.json";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerWords = ScriptableObject.CreateInstance<PlayerWordsScriptable>();
        playerWords.allPlayerWords = MakeTempList();

        ReadFile(jsonFilePath); // retrieve player's words, store in playerWords
        ideasToSpawn = playerWords.allPlayerWords;

        // WriteFile("Assets/Data/PlayerWordFile.json");
        // playerWords.display(); // debug

        ideas = new List<GameObject>{}; // list of references to spawned objects
        StartCoroutine(SpawnIdeas());
    }

    void Update()
    {
        // if (canSpawn) {
        //     StartCoroutine(spawnIdeas());
        //     canSpawn = false;
        // }
    }

    List<PlayerWord> MakeTempList() // just generate the user's words for now
    {
        List<PlayerWord> list = new()
        {
            // List<PlayerWord> list = new List<PlayerWord>{};
            new PlayerWord("cat", 3, 2, new string[7]),
            new PlayerWord("dog", 2, 1, new string[7]),
            new PlayerWord("me", 6, 1, new string[7]),
            new PlayerWord("you", 5, 1, new string[7]),
            new PlayerWord("I", 4, 2, new string[7]),
            new PlayerWord("am", 3, 4, new string[7]),
            new PlayerWord("is", 3, 5, new string[7])
        };
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

    IEnumerator SpawnIdeas()
    {
        while (ideasToSpawn.Count > 0)
        {
            int randNum = Random.Range(0, ideasToSpawn.Count);
            GameObject newIdeaGO = Instantiate(idea, spawnPoint1.position, spawnPoint1.rotation);
            IdeaInteraction newIdea = newIdeaGO.GetComponent<IdeaInteraction>();
            
            // choose which of the words to spawn
            PlayerWord chosenWord = ideasToSpawn[randNum];
            newIdea.SetWord(chosenWord);
            ideasToSpawn.RemoveAt(randNum);

            ideas.Add(newIdeaGO);
            yield return null;
        }
        goalword = ChooseGoal(); // choose one of the words spawned in
    }

    GameObject ChooseGoal()
    {
        int randNum = Random.Range(0, ideas.Count);
        GameObject chosen = ideas[randNum];
        goalText.text = chosen.GetComponent<IdeaInteraction>().word.word;
        return chosen;
    }
}
