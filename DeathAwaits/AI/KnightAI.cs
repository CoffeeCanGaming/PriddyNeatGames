using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAI : MonoBehaviour
{
    public int R;
    public Rigidbody2D rb, Enemyrb;
    public float AttackTime, HP, MaxHP, AttackDmg, modAttackTime;
    public bool Attack;
    public GameObject Enemy;
    public ZombieBasicAI zombie;
    public DarkTowerStats DTS;
    public Animator anim;
    public Economy eco;
    public AudioSource H1, H2, D;


    // Start is called before the first frame update
    void Start()
    {
        eco = GameObject.Find("GameManager").GetComponent<Economy>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        MaxHP = 5;
        HP = MaxHP;
        modAttackTime = 1;
        AttackTime = modAttackTime;
        AttackDmg = 1;
        Attack = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AttackTimer();
        detectInFront();
        if (HP <= 0)
        {

            R = Random.Range(0, 3);

            if (R == 2)
            {
                D.Play();
                eco.Souls += 1;
                eco.updateSoulCount();
            }

            GameObject Soul = Instantiate(Resources.Load("Prefabs/Soul", typeof(GameObject))) as GameObject;
            Soul.gameObject.name = "Soul";
            Soul.transform.position = gameObject.transform.position;
            Destroy(gameObject);

        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.tag == "Friendly" && Attack)
        {
            Enemy = col.collider.gameObject;
            Enemyrb = Enemy.GetComponent<Rigidbody2D>();
            zombie = Enemy.GetComponent<ZombieBasicAI>();
            rb.velocity = Vector2.zero;
            anim.SetBool("Attacking", true);
            Attack = false;
            zombie.hurt(AttackDmg);
        }
        else if (col.collider.tag == "DarkTower" && Attack)
        {
            Enemy = col.collider.gameObject;
            Enemyrb = Enemy.GetComponent<Rigidbody2D>();
            DTS = Enemy.GetComponent<DarkTowerStats>();
            anim.SetBool("Attacking", true);
            DTS.hurt(AttackDmg);
            Attack = false;
        }
    }
    public void detectInFront()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - .75f, transform.position.y), -Vector3.forward);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Enemy")
            {
                rb.velocity = Vector2.zero;
            }
            else if (hit.collider.tag == "Church")
            {
                rb.velocity = new Vector2(-1, 0);
            }
            else if (hit.collider.tag == "DarkTower")
            {
                rb.velocity = new Vector2(-1, 0);
            }
            else if (hit.collider.tag == "Friendly")
            {
                rb.velocity = new Vector2(-1, 0);
            }
        }
        else
        {

            anim.SetBool("Attacking", false);
            rb.velocity = new Vector2(-1, 0);
        }

    }
    public float hurt(float i)
    {
        int b = Random.Range(1, 2);
        if (b == 1)
        {
            H1.Play();
        }
        else if (b == 2)
        {
            H2.Play();
        }
        return HP -= i;
    }
    public void AttackBasic()
    {

        Attack = false;

    }
    public void AttackTimer()
    {
        if (!Attack)
        {
            AttackTime -= Time.unscaledDeltaTime;
            if (AttackTime <= 0)
            {
                AttackTime = modAttackTime;
                Attack = true;
            }
        }
    }
}
