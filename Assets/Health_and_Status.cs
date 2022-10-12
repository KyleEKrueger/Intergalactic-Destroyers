using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health_and_Status : MonoBehaviour

{
    //This script is to provide information on any powerups and health this object may have.

    Component shipController;
    public float deathTime = 3;
    public float deathFlashDelay = .25f;
    public TMP_Text tmpHealth;
    public static int health = 3; // Amount of hits one can take before dying
    public GameObject healthPrefab;
    Vector2 pos;
    public GameObject[] healthObjects;

    // Start is called before the first frame update
     void  Start()
    {
        healthObjects = new GameObject[health];
        //Check if ship or android
        if (gameObject.tag == "Player")
        {
            shipController = gameObject.GetComponent < Ship_Movement >();
            int i = 0;
            for (i = 0; i <health; i++){
                GameObject healthSpriteGO = Instantiate<GameObject>(healthPrefab);
                pos.x = 35 + (5*i);
                pos.y = -35;
                healthSpriteGO.transform.position = pos; 
                healthObjects[i] = healthSpriteGO;           
        }

        }
    
  
        
        
    }

    // Update is called once per frame
     void  Update()
    {

        
    }
     void  OnTriggerEnter2D(Collider2D coll)
    {
        GameObject collidedWith = coll.gameObject;
        //Collision is a projectile
        if (collidedWith.tag == "ProjectileEnemy")
        {
            Debug.Log("Collision detected with Enemy Projectile");
            Destroy(collidedWith);
            health = health - 1;
            destroyHealthSprite();
        }
        if (health <= 0)
        {
           Debug.Log("Out of health");
           SoundManagerScript.PlaySound("death");
           Destroy(this.gameObject);

           

        }
    }
    public static int getHealth(){
        return health;
    }
    public void destroyHealthSprite(){
        Debug.Log("DestroyHealth Entered");
        Destroy(healthObjects[health]);


       
    }

}
