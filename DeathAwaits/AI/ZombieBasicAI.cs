using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBasicAI : MonoBehaviour
{
    public Rigidbody2D rb, Enemyrb;
    public float AttackTime, HP, MaxHP, AttackDmg,ModAttackTime,soundTime;
    public bool Attack,sound;
    public GameObject Enemy;
    public KnightAI knightAI;
    public CastleStats CHP;
    public Animator anim;
    public AudioSource z1, z2, z3;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        MaxHP = 5;
        HP = MaxHP;
        ModAttackTime = 1;
        AttackTime = ModAttackTime;
        AttackDmg = 1;
        Attack = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AttackTimer();
        detectInFront();
        soundTimer();
        if (HP <= 0)
        {
            GameObject Soul = Instantiate(Resources.Load("Prefabs/Soul", typeof(GameObject))) as GameObject;
            Soul.gameObject.name = "Soul";
            Soul.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
        if (sound)
        {
            Playsound();
            sound = false;
        }
    }

    public void Playsound()
    {
        int t = Random.Range(1, 6);
        
        if(t == 1)
        {
            z1.Play();
        }else if(t == 2)
        {
            z2.Play();
        }else if (t == 3)
        {
            z3.Play();
        }

    }

    

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.tag == "Enemy" && Attack)
        {
            Enemy = col.collider.gameObject;
            Enemyrb = Enemy.GetComponent<Rigidbody2D>();
            knightAI = Enemy.GetComponent<KnightAI>();
            rb.velocity = Vector2.zero;
            anim.SetBool("Attacking", true);
            Attack = false;
            knightAI.hurt(AttackDmg);
        }
        else if (col.collider.tag == "Church" && Attack)
        {
            Enemy = col.collider.gameObject;
            Enemyrb = Enemy.GetComponent<Rigidbody2D>();
            CHP = Enemy.GetComponent<CastleStats>();
            anim.SetBool("Attacking", true);
            CHP.hurt(AttackDmg);
            Attack = false;
        }
    }
    public void detectInFront()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + .75f, transform.position.y), -Vector3.forward);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Friendly")
            {
                rb.velocity = Vector2.zero;
            }
            else if (hit.collider.tag == "DarkTower")
            {
                rb.velocity = new Vector2(1, 0);
            }
            else if (hit.collider.tag == "Church")
            {
                rb.velocity = new Vector2(1, 0);
            }
            else if (hit.collider.tag == "Enemy")
            {
                rb.velocity = new Vector2(1, 0);
            }
        }
        else
        {
            anim.SetBool("Attacking", false);
            rb.velocity = new Vector2(1, 0);
        }

    }
    public float hurt(float i)
    {
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
                AttackTime = ModAttackTime;
                Attack = true;
            }
        }

    }
    public void soundTimer()
    {
        float L = Random.Range(5, 20);

        if (!sound)
        {
            soundTime -= Time.unscaledDeltaTime;
            if (soundTime <= 0)
            {
                soundTime = L;
                sound = true;
            }
        }
    }

}
