using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnQueue : MonoBehaviour
{

    public string[] spawnList = new string[10];
    public bool canSpawn;
    public int spawnCount;
    public float spawnTime, maxSpawnTime;
    public string Str;
    public DarkTowerStats dts;
    public SpawnSlider s;
    public TMP_Text text, x;

    // Start is called before the first frame update
    void Start()
    {
        maxSpawnTime = 5f;
        s.SetMaxSpawnTime(maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer();
        Spawn();
        SpawnListCleanUp();

        spawnSlider();
        if(spawnList[0] != "")
        {
        s.gameObject.SetActive(true);
        
        }
        else
        {
            s.gameObject.SetActive(false);
        }
    }

    public void spawnSlider()
    {
        if (s.gameObject.activeSelf)
        {
            text.gameObject.SetActive(true);
            x.gameObject.SetActive(true);
            text.SetText(spawnCount.ToString());
        }
        else
        {
            text.gameObject.SetActive(false);
            x.gameObject.SetActive(false);
        }
    }


    public void Spawn()
    {
        if (canSpawn && spawnList[0] != "" && !dts.blocked)
        {
            spawnCount--;

            if (spawnList[0] == "zombie")
            {
                
                GameObject Zombie = Instantiate(Resources.Load("Prefabs/ZombieBasic", typeof(GameObject))) as GameObject;
                Zombie.gameObject.name = "ZombieBasic";
                Zombie.transform.position = new Vector2(-7f, -3.53025f);
                spawnList[0] = "";
                canSpawn = false;
            }
        }
    }
    public void SpawnListCleanUp()
    {
        if (spawnList[0] == "" && spawnList[1] != "")
        {

            for (int i = 0; i <= spawnList.Length; i++)
            {
                if (i + 1 < spawnList.Length)
                {
                    Str = spawnList[i + 1];
                    spawnList[i] = Str;
                    spawnList[i + 1] = "";
                    Str = "";
                }
                else
                {
                    return;
                }
            }
        }
    }
    public void PushToQueue(string s)
    {
        spawnCount++;
        for (int i = 0; i <= spawnList.Length; i++)
        {

            if (spawnList[i] == "")
            {

                spawnList[i] = s;

                return;
            }
        }

    }



    public void spawnTimer()
    {
        if (!canSpawn)
        {
            spawnTime -= Time.unscaledDeltaTime;
            s.SetSpawnTime(spawnTime);
            if (spawnTime <= 0)
            {
                spawnTime = maxSpawnTime;

                canSpawn = true;
            }
        }
    }
}
