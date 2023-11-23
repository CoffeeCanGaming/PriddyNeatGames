using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    public CollectibleGui gui;
    public int LeafCount;
    public AudioSource Collect;

    // Start is called before the first frame update0
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Collectible"))
        {
            
            LeafCount++;
            gui.guiUpdate();
            Collect.Play();
            Destroy(collision.collider.gameObject.transform.parent.gameObject);
        }
        else if (collision.collider.CompareTag("LevelExit") && LeafCount == 10 && LeafCount <= 14)
        {
            SceneManager.LoadScene(4);
        }
        else if(collision.collider.CompareTag("LevelExit") && LeafCount == 15)
        {
            SceneManager.LoadScene(5);
        }
        else if (collision.collider.CompareTag("Respawn"))
        {
            gameObject.transform.position = new Vector3(-8f, 4f,-1f);
        }
    }
}
