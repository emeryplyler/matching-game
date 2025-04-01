using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerWords", menuName = "Scriptable Objects/PlayerWords")]
[System.Serializable]
public class PlayerWordsScriptable : ScriptableObject
{
    public string username;
    public List<PlayerWord> allPlayerWords;

    // get user data from database/website/wherever

    public void display()
    {
        foreach (PlayerWord word in allPlayerWords)
        {
            Debug.Log(string.Format("Word detected: {0}, correct {1}, wrong {2}", word.word, word.testCorrectCount, word.testIncorrectCount));
        }
    }
    
}
