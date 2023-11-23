using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleStats : MonoBehaviour
{
    public float MaxHP, HP;
    public CastleHP D;
    public GameObject Victory;
    public bool blocked;

    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 100;
        D.SetMaxHealth(MaxHP);
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {

        D.SetHealth(HP);
        isSpawnBlocked();
        if (HP <= 0)
        {
            Victory.SetActive(true);
        }
    }

    public float hurt(float i)
    {

        return HP -= i;
    }
    public void isSpawnBlocked()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(8.15f, -3.53025f), -Vector3.forward);

        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            blocked = true;
        }
        else
        {
            blocked = false;
        }
    }
}
