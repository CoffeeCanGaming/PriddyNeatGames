using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleGui : MonoBehaviour
{
    
    public GameObject collectGui;
    public PlayerScore score;
    public TMP_Text text;

    void Start()
    {
     
        

    }
    void Update()
    {

        if (gameObject.activeSelf)
        {

            guiUpdate();
        }

    }

    public void guiUpdate()
    {
        
        text.SetText(score.LeafCount.ToString() + "/ 10");
        Fade();

    }

    IEnumerator Fade()
    {
        Color c = GetComponent<Renderer>().material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            GetComponent<Renderer>().material.color = c;
            yield return null;
        }
        if (c.a <= 0)
        {
            
            gameObject.SetActive(false);
        }
    }
}
