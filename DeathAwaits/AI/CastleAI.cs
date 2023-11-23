using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleAI : MonoBehaviour
{
    public Economy eco;
    public CastleStats stats;
    public KnightAI kAI;
    public int ADUCounter, ASUCounter, UpgradeCost, MaxHPCounter,count;

    public bool canClick;
    public float buttonCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clickTimer();
        if(kAI != null) { 
        UpdateStats();
        }

        if(eco.Cure > 0 && canClick && !stats.blocked)
        {
            spawnKnight();
            canClick = false;
        }
        else if(eco.Cure >= UpgradeCost && canClick)
        {
            
            PumpStats();
            Debug.Log("blip");
        }


    }
    public void UpdateStats()
    {   
        kAI.AttackDmg = 1 + (ADUCounter * .25f);
        kAI.modAttackTime = 1 - (ASUCounter * .05f);
        kAI.MaxHP = 5 + (MaxHPCounter * .25f);
    }


    public void PumpStats()
    {
        int i = Random.Range(1, 3);

        if(i == 1)
        {
            eco.Cure -= UpgradeCost;
            eco.updateCureCount();
            ADUCounter += 1;
            UpgradeCost += 1;

        }
        else if (i == 2)
        {

            eco.Cure -= UpgradeCost;
            eco.updateCureCount();
            ASUCounter += 1;
            UpgradeCost += 1;
        }
        else if(i == 3)
        {
            eco.Cure -= UpgradeCost;
            eco.updateCureCount();
            MaxHPCounter += 1;
            UpgradeCost += 1;
        }

    }

    public void spawnKnight()
    {
        GameObject Knight = Instantiate(Resources.Load("Prefabs/Knight", typeof(GameObject))) as GameObject;
        kAI = Knight.GetComponent<KnightAI>();
        Knight.gameObject.name = "Knight";
        Knight.transform.position = new Vector2(8.15f, -3.53025f);
        eco.Cure -= 1;
        eco.updateCureCount();
    }
    public void clickTimer()
    {
        if (canClick == false)
        {
            buttonCoolDown -= Time.unscaledDeltaTime;
            if (buttonCoolDown <= 0)
            {
                buttonCoolDown = 4;
                count++;
                canClick = true;
            }
        }
    }
}
