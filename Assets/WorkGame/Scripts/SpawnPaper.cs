using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPaper: MonoBehaviour
{
    public GameObject[] Paper;
    // public float YLocation;
    private Vector2 spawnLocation;
    public Slider Money;
    public float spawnRate = 2.0f;
    private float nextSpawn = 0.0f;
    public float Xmin, Xmax, Y;
    public int MaxType, MaxSpawnTimes;
    private int SpawnTimes = 0;
    // public GameObject FaterTrash, PowerUp;
    public int MoneyAmount;

    public int StartSpawnTime = 10;
    private bool Startspawn;
    private float SpawnTimecounter = 0f, GameStartTime, GameStartTimerCounter;
    private bool PlusSpeed1, PlusSpeed2;
    public float ChangeSpawnRateTime1 = 10f, ChangeSpawnRateTime2 = 30f;
    public float ChangeSpawnRate1 = 1.5f, ChangeSpawnRate2 = 1f;
    public float ChangeGraviteScale1, ChangeGraviteScale2;

    private void Update()
    {
        GameStartTime = GameStartTime + Time.deltaTime;
        if (GameStartTime >= ChangeSpawnRateTime1 && PlusSpeed1 == false)
        {

            spawnRate = ChangeSpawnRate1;
            PlusSpeed1 = true;

        }
        if (GameStartTime >= ChangeSpawnRateTime2 && PlusSpeed2 == false)
        {

            spawnRate = ChangeSpawnRate2;
            PlusSpeed2 = true;

        }
        if (SpawnTimecounter > StartSpawnTime)
            Startspawn = true;
        else
        {
            SpawnTimecounter = SpawnTimecounter + Time.deltaTime;
            // Debug.Log(SpawnTimecounter);
        }
        if (Startspawn == true)
        {
            if (Time.time > nextSpawn)   // && SpawnTimes < MaxSpawnTimes)
            {
                nextSpawn = Time.time + spawnRate;
                SpawnTimes = SpawnTimes + 1;
                spawnLocation = new Vector2(Random.Range(Xmin, Xmax), Y);

                GameObject newpaper = Instantiate(Paper[Random.Range(0, MaxType)], spawnLocation, Quaternion.identity);
                newpaper.GetComponent<PaperHover>().Money = Money;
                newpaper.GetComponent<PaperHover>().MoneyAmount = MoneyAmount;
                if (PlusSpeed1 == true)
                {
                    newpaper.GetComponent<Rigidbody2D>().gravityScale = ChangeGraviteScale1;

                }

                if (PlusSpeed2 == true)
                {
                    newpaper.GetComponent<Rigidbody2D>().gravityScale = ChangeGraviteScale2;

                }
            }


        }
    }
}
