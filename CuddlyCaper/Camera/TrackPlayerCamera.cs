using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerCamera : MonoBehaviour
{
    public GameObject player;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-10f);
    }
}
