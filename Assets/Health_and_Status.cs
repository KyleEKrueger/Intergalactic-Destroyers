using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_and_Status : MonoBehaviour
{
    //This script is to provide information on any powerups and health this object may have.

    Component shipController;
    public float deathTime = 3;
    public float deathFlashDelay = .25f;

    public int health = 3; // Amount of hits one can take before dying

    // Start is called before the first frame update
    void Start()
    {
        //Check if ship or android
        if (gameObject.tag == "Player")
        {
            shipController = gameObject.GetComponent < Ship_Movement >();
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //Death
            //Stop the ship
            shipController.stopShip();
            //Critically flash the ship
            float currentTime = Time.time;
            while (currentTime > currentTime + deathTime)
            {
                gameObject.Color = Color.yellow;
                WaitForSeconds(deathFlashDelay);
                gameObject.Color = Color.red;
                WaitForSeconds(deathFlashDelay);
                gameObject.Color = Color.white;
                WaitForSeconds(deathFlashDelay);
            }
            
            

        }
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject collidedWith = coll.gameObject;
        //Collision is a projectile
        if (collidedWith.tag == "ProjectileEnemy")
        {
            Destroy(collidedWith);
            health = health - 1;
        }
    }
}
