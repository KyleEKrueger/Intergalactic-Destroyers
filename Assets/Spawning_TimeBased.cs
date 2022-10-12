using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawning_TimeBased : MonoBehaviour
{
    public int spawnLimit; // Spawn limit will increase over time
    public int startingSpawnSize;
    public float enemySpawnRate;
    public int totalEnemies;
    public float timeSinceLastSpawn;
    public float spawnDelay;
    public GameObject enemyPrefab;
    public int spawningRangeX;
    public int spawningRangeY;
    private const int spawningLocations = 1;
    private  int[] spawningArrayX = {0};
    private  int[] spawningArrayY = {0};
    private bool[] spawnedHere = {false};
    // Start is called before the first frame update
    void Start()
    {
        //Instantiation of variables
        totalEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //--Caclulate spawn limit-- 
        spawnLimit = spawnLimit + (int)(Mathf.Floor(Time.time / enemySpawnRate));

        //--Try to spawn an enemy--
        if (totalEnemies < spawnLimit){
            if (timeSinceLastSpawn < spawnDelay){
                spawnEnemyRandomly();
            }
        }

    }

    bool spawnEnemyRandomly(){
        //--Enemy Spawning--
        //Randomly generate an xy cooridinate to check for spawning. Keep generating a potential spawn
        //point until a valid one is found
        bool foundSpawn = false;
        int randomLocation;
        while(!foundSpawn){
            //Check a random x y coordinate from spawning array to see if it is a valid point
            randomLocation = Random.Range(0,spawningLocations-1);
            if (spawnedHere[randomLocation]){
                foundSpawn = true;
                spawnEnemyXY(spawningArrayX[randomLocation],spawningArrayY[randomLocation]);
                spawnedHere[randomLocation] = true;
            }
        }
        return true;
    }
    void spawnEnemyXY(int x, int y){
        GameObject enemyGO = Instantiate<GameObject>(enemyPrefab);
        Vector2 posE = Vector2.zero;
        posE.x = x;
        posE.y = y;
        enemyGO.transform.position = posE;

    }
}
