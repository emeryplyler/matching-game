using UnityEngine;

public class IdeaInteraction : MonoBehaviour
{
    public PlayerWord word;

    public void setWord(string name, int right, int wrong)
    {
        word = new PlayerWord(name, right, wrong);
    }

    public void setWord(PlayerWord newWord)
    {
        word = newWord;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("GameObject1 collided with player");
        }
    }
}
