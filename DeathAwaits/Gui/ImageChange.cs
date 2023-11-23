using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public Image I;
    public Sprite z,n;
    public SpawnQueue sq;

    // Start is called before the first frame update
    void Start()
    {
        I = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sq.spawnList[0] == "zombie")
        {
            I.sprite = z;
        }
        else if (sq.canSpawn)
        {
            I.sprite = n;
        }
        
    }
}
