using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparkles : MonoBehaviour
{
    public GameObject Sparkle;
    public float rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = -.25f;
    }

    // Update is called once per frame
    void Update()
    {
        Sparkle.transform.Rotate(new Vector3(0,0,transform.position.z), rotation);
    }
}
