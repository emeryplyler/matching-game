using UnityEngine;
// script to be attached to idea instances
public class IdeaInteraction : MonoBehaviour
{
    public PlayerWord word;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        loadSprite();
    }

    public void SetWord(string name, int right, int wrong, string[] images)
    {
        word = new PlayerWord(name, right, wrong, images);
    }

    public void SetWord(PlayerWord newWord)
    {
        word = newWord;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("GameObject1 collided with player");
        }
    }

    void loadSprite()
    {
        int randomNum = Random.Range(0, 7);
        Sprite newSprite = Resources.Load<Sprite>(word.image_paths[randomNum]);
        if (newSprite == null)
        {
            newSprite = Resources.Load<Sprite>(word.image_paths[0]); // try to load first in array
            if (newSprite == null)
            {
                newSprite = Resources.Load<Sprite>("Images/misc"); // load backup texture
                print("misc image used for word " + word.word);
            }
        }
        spriteRenderer.sprite = newSprite;
    }
}
