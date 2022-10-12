using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Android_Ship : MonoBehaviour
{
[Header("Set in Inspector")]

    //--Ship Declarations--
    public GameObject projectilePrefab; // Projectile Prefab
    private GameObject playerShip;
    public float fireRate = 0.75f;

    //--Timing Declarations--
    float timeSinceLastShot = 0;
    public float inputDelay = 0.05f;
    Queue<float> inputQueue = new Queue<float>();
    float delayedInput;
    float lastActionTime;
    Queue<float> timeQueue = new Queue<float>();
    Queue<float> shotQueue = new Queue<float>();
    bool shootThisFrame;
    float shotDelay = 200;
    float lastAndroidShot;
    Component playerMovementComp;
    float delayedTime;

    //--Powerup Declarations--
    // Start is called before the first frame update
    void Start()
    {
        playerShip = GameObject.FindWithTag("Player");
        playerMovementComp = playerShip.GetComponent<Ship_Movement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeQueue.Count != 0)
        {
            lastActionTime = timeQueue.Peek();
            
        }
        //--Shot timing--
        if (shotQueue.Count !=0 && shotQueue.Peek() > lastAndroidShot)
        {
            shotQueue.Dequeue();
            lastAndroidShot = Time.time;
            fireProjectile(fireRate);
        }
        //--Shot capture--
        if (Input.GetKey(KeyCode.Mouse1))
        {
            shotQueue.Enqueue(Time.time + shotDelay);
        }

        //Position vector
        Vector3 pos = transform.position; 

        //Checks if the last action was longer than the time delay
        if ((Time.time-inputDelay) > lastActionTime && lastActionTime != 0 && inputQueue.Count !=0)
        {
            delayedInput = inputQueue.Dequeue();
            delayedTime =  timeQueue.Dequeue();
            Debug.Log(shootThisFrame);
            //Delayed movement
            pos.x = delayedInput;
            transform.position = pos;
            
        }
        //Checks if there are any keys pressed, put them in two queues. One for the position of the ship and one for the time. 
        if (Input.anyKey)
        {
            timeQueue.Enqueue(Time.time);
            inputQueue.Enqueue(playerShip.transform.position.x);
            
        }

    
        
    }
    
    void fireProjectile(float thisFireRate){ // Spawns a projectile at a constant fire rate if the mouse button is held down. 
    //If statement, compares the time from the last shot to the fire rate. and fires if enough time has passed
    if (Time.time > timeSinceLastShot + thisFireRate ){
        timeSinceLastShot = Time.time;
        GameObject projectile = Instantiate<GameObject> ( projectilePrefab );
        Vector3 projPos = transform.position;
        projPos.y = projPos.y - 5;
        projectile.transform.position = projPos;  
        }
     
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.tag == "PowerUp"){
            Debug.Log("PowerUp Collision Detected");
            SoundManagerScript.PlaySound("powerUp");
            fireRate = fireRate * 0.95f;   
            Destroy(collidedWith);  
        }
    }
}
