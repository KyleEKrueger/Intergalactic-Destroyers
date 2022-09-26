using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntergalacticDestroyers : MonoBehaviour
{
[Header("Set in Inspector")]
    public GameObject playerShipPrefab;
    public GameObject alienStandardPrefab;
    public int playerLives = 3;
    public float playerAxis = -35;
    public float androidAxis = 35;
    public float alienStartingAxis = 30;
    public float alienStartingX = 30;
    public int aliensPerRow = 8;
    public float alienSpacing;
    public float alienRowSpacing = 2f;
    public int alienRows = 3;
    public static int alienWidth = 3;
    public int gameWidth = 30;
    float elapsedTime;
    float timeLimit = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
     //Place the player
        GameObject playerGO = Instantiate<GameObject>(playerShipPrefab);
        Vector2 pos = Vector2.zero;
        pos.y = playerAxis;
        playerGO.transform.position = pos;
        //Place the Aliens
        spawnAliens();
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeLimit)
        {
            elapsedTime = 0;
            alienCheck();
        }
    }

    void spawnAliens()
    {
        alienSpacing = (2 * (gameWidth - ((1 / 2) * alienWidth))) / aliensPerRow;
        for (int i = 0; i < alienRows; i++)
        {
            for (int j = 0; j < aliensPerRow; j++)
            {
                GameObject alienGO = Instantiate<GameObject>(alienStandardPrefab);
                Vector2 posA = Vector2.zero;
                posA.y = alienStartingAxis - (alienRowSpacing * i);
                posA.x = (-alienStartingX) + (alienSpacing * j);
                alienGO.transform.position = posA;


            }
        }
    }

    bool alienCheck()
    {
        //Checks if there are aliens on screen, returns true if there exists an alien
        if (GameObject.Find("Alien_Standard(Clone)") != null){
            Debug.Log("WE FOUND AN ILLEGAL ALIEN BOYS");
           return true;
        }
        spawnAliens();
        return false;
    }
}
