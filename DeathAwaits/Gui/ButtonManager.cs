using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public Economy eco;
    public int Zcount, Kcount, ADUCounter, ASUCounter, UpgradeCost, MaxHPCounter;
    public ZombieBasicAI zb;
    public TMP_Text textL, textR, AtkDMG, AtkSPD, MaxHUp, UpCost;
    public DarkTowerStats dts;
    public CastleStats Cs;
    public GameObject upgrade;
    public SpawnQueue spawnQueue;

    public bool canClick, borClick;
    public float buttonCoolDown, borCooldown, Atd, Ats, Mhp;

    // Start is called before the first frame update
    void Start()
    {
        UpgradeCost = 1;
        buttonCoolDown = 1f;
        borCooldown = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        clickTimer();
        borTimer();

        Zcount = GameObject.FindGameObjectsWithTag("Friendly").Length;
        Kcount = GameObject.FindGameObjectsWithTag("Enemy").Length;



        if (textL != null || textR != null)
        {



            if ((textL.gameObject.activeInHierarchy || textR.gameObject.activeInHierarchy) && borClick)
            {

                textL.gameObject.SetActive(false);
                textR.gameObject.SetActive(false);
            }
        }
        if (upgrade != null)
        {
            UpdateStats();
        }

        if (zb != null)
        {
            zb.AttackDmg = Atd;
            zb.ModAttackTime = Ats;
            zb.MaxHP = Mhp;

        }
        if(GameObject.FindGameObjectsWithTag("Friendly").Length > 0)
        {
            zb = GameObject.Find("ZombieBasic").GetComponent<ZombieBasicAI>();
        }

    }

    public void UpdateStats()
    {
        
        Atd = 1 + (ADUCounter * .25f);
        AtkDMG.SetText(Atd.ToString());

        Ats = 1 - (ASUCounter * .05f);
        AtkSPD.SetText(Ats.ToString());

        Mhp = 5 + (MaxHPCounter * .25f);
        MaxHUp.SetText(Mhp.ToString());

        if (upgrade.activeInHierarchy)
        {
            UpCost.SetText(UpgradeCost.ToString());
        }
    }

    public void BOR()
    {
        BORevents();
        int r, mod;
        r = Random.Range(0, 10);
        mod = r % 2;

        if (mod == 1)
        {
            eco.Souls += 1;
            if(r == 4)
            {
                eco.Souls += 2;
                eco.updateSoulCount();
            }
            eco.updateSoulCount();
            textL.gameObject.SetActive(true);
            borClick = false;
        }
        else
        {
            eco.Cure += 1;
            eco.updateCureCount();
            textR.gameObject.SetActive(true);
            borClick = false;
        }


    }
    public void LevelUp()
    {


        if (!upgrade.activeInHierarchy)
        {
            upgrade.SetActive(true);
        }
        else
        {
            upgrade.SetActive(false);
        }
    }


    public void spawnBZ()
    {

        if (Zcount <= 10 && eco.Souls > 0 && spawnQueue.spawnList[9] == "")
        {
            spawnQueue.PushToQueue("zombie");
            eco.Souls -= 1;
            eco.updateSoulCount();
        }
    }
    
    public void clickTimer()
    {
        if (!canClick)
        {
            buttonCoolDown -= Time.unscaledDeltaTime;
            if (buttonCoolDown <= 0)
            {
                buttonCoolDown = 1;
                canClick = true;
            }
        }
    }
    public void borTimer()
    {
        if (!borClick)
        {
            borCooldown -= Time.unscaledDeltaTime;
            if (borCooldown <= 0)
            {
                borCooldown = 1;
                borClick = true;
            }
        }
    }
    public void BORevents()
    {
        int t = Random.Range(0, 100);

        if (t == 83 && Kcount >= 1)
        {

            Destroy(GameObject.Find("Knight"));
        }
        else if (t == 19 && Zcount >= 1)
        {


            Destroy(GameObject.Find("ZombieBasic"));
            eco.Souls += 1;
            eco.updateSoulCount();

        }


    }
    public void AttackDmgUp()
    {
        if (eco.Souls >= UpgradeCost)
        {
            eco.Souls -= UpgradeCost;
            eco.updateSoulCount();
            ADUCounter += 1;
            UpgradeCost += 1;
        }
    }
    public void AttackSpeedUp()
    {
        if (eco.Souls >= UpgradeCost)
        {
            eco.Souls -= UpgradeCost;
            eco.updateSoulCount();
            ASUCounter += 1;
            UpgradeCost += 1;
        }
    }
    public void MaxHPUp()
    {
        if (eco.Souls >= UpgradeCost)
        {
            eco.Souls -= UpgradeCost;
            eco.updateSoulCount();
            MaxHPCounter += 1;
            UpgradeCost += 1;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Credits()
    {
        SceneManager.LoadScene(2);
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene(3);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
