using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntergalacticDestroyers : MonoBehaviour
{
[Header("Set in Inspector")]
    public GameObject playerShipPrefab;
    public GameObject alienStandardPrefab;
    public GameObject androidShipPrefab;
    int playerHealth;
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
    public TMP_Text waveCounter;
    private int wavesSpawned = 0;
    float elapsedTime;
    float timeLimit = 0.1f;
    GameObject playerGO;

    // Start is called before the first frame update
    void Start()
    {
     //Place the player
        playerGO = Instantiate<GameObject>(playerShipPrefab);
        Vector2 pos = Vector2.zero;
        pos.y = playerAxis;
        playerGO.transform.position = pos;
        //Place the Android
        GameObject androidGO = Instantiate<GameObject>(androidShipPrefab);
        pos = Vector2.zero;
        pos.y = androidAxis;
        androidGO.transform.position = pos;
        //Place the Aliens
        spawnAliens();
        wavesSpawned++;
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeLimit)
        {
            elapsedTime = 0;
            alienCheck();
            playerCheck();
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
           return true;
        }
        wavesSpawned++;
        waveCounter.text = wavesSpawned.ToString();
        spawnAliens();
        return false;
    }
    bool playerCheck(){
    if (GameObject.Find("PlayerShip(Clone)") != null){
        return true;    
    }
    Invoke("restartGame",4);
    return false;
    
}
    private void restartGame(){
        SceneManager.LoadScene("Title");
}
    
    //Code to get player health inside of my Main Camera object

//   public void getPlayerHealth(){
//    Health_and_Status playerhealthcomp =  playerGO.GetComponent<Health_and_Status>();
//    playerHealth =  playerhealthcomp.getHealth();
//}
}
