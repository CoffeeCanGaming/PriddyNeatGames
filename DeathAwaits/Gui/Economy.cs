using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    public int Souls, Cure;
    public TMP_Text soulscount, curecount;
    public bool cureGain;
    public float cureGainTimer; 
    

    // Start is called before the first frame update
    void Start()
    {
        Souls = 0;
        Cure = 0;
        cureGainTimer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        cureGen();
        if (cureGain)
        {
            cureGain = false;
        }
    }
    public void updateSoulCount()
    {
        soulscount.SetText(Souls.ToString());
    }
    public void updateCureCount()
    {
        curecount.SetText(Cure.ToString());
    }
    public void cureGen()
    {
        if (cureGain == false)
        {
            cureGainTimer -= Time.unscaledDeltaTime;
            if (cureGainTimer <= 0)
            {
                Cure += 1;
                updateCureCount();
                cureGain = true;
                cureGainTimer = 15;

                
            }
        }
    }
}
