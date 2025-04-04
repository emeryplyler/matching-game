using UnityEngine;

[System.Serializable]
public class PlayerWord // how many times a player has encountered a word/ remembered it
{
    public string word = "";
    public int testCorrectCount = 0;
    public int testIncorrectCount = 0;
    public string[] image_paths = new string[7];

    public PlayerWord(string name, int right, int wrong, string[] images)
    {
        word = name;
        testCorrectCount = right;
        testIncorrectCount = wrong;
        image_paths = images;
    }
}
