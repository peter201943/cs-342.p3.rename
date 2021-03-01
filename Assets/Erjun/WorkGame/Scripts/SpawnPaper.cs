using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPaper: MonoBehaviour
{
    public GameObject[] Paper;
   // public float YLocation;
    private Vector2 spawnLocation;
    public Text Money;
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
    

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        GameStartTime = GameStartTime + Time.deltaTime;
        if(GameStartTime >= 10 && PlusSpeed1 == false)
        {
            
            spawnRate = 3;
            PlusSpeed1 = true;
            
        }
        if (GameStartTime >= 40 && PlusSpeed2 == false)
        {

            spawnRate = 2;
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
            if (Time.time > nextSpawn && SpawnTimes < MaxSpawnTimes)
            {
                nextSpawn = Time.time + spawnRate;
                SpawnTimes = SpawnTimes + 1;
                spawnLocation = new Vector2(Random.Range(Xmin, Xmax), Y);
                
               GameObject newpaper = Instantiate(Paper[Random.Range(0, MaxType)], spawnLocation, Quaternion.identity);
                newpaper.GetComponent<PaperHover>().Money = Money;
                newpaper.GetComponent<PaperHover>().MoneyAmount = MoneyAmount;
            }

            
        }
    }
}
