using UnityEngine;

[System.Serializable]
public class PlayerWord // how many times a player has encountered a word/ remembered it
{
    public string word = "";
    public int testCorrectCount = 0;
    public int testIncorrectCount = 0;

    public PlayerWord(string name, int right, int wrong)
    {
        word = name;
        testCorrectCount = right;
        testIncorrectCount = wrong;
    }
}
