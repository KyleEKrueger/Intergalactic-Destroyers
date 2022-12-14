using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Movement : MonoBehaviour
{
[Header("Set in Inspector")]
    public GameObject projectilePrefab; // Projectile Prefab
    public float startPositionX = 0; //Starting position for the ship on the X axis
    public float startPositionY = -35;  // Starting position for the ship on the Y axis
    public float shipSpeed = 15f; // Speed multiplier for the ship
    public float leftAndRightEdge = 25f; // Boundries of the playable gamespace
    public int lifeCount = 3; // Lives that the ship has
    public float fireRate = 0.75f;
    float timeSinceLastShot = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //--BEGIN MOVEMENT INPUT--
    Vector3 pos = transform.position; // Get the transform vector as pos
    if (Input.GetKey("d")) //Ship should move to the right
        {
     //Check if on the edge of the screen. If not, move right
     if (pos.x < leftAndRightEdge){
        pos.x += shipSpeed*Time.deltaTime;
        transform.position = pos; 
            }
        }
    if (Input.GetKey("a")) //Ship should move to the left
        {
     //Check if on the edge of the screen. If not, move left
     if (pos.x > -leftAndRightEdge){
        pos.x += -shipSpeed*Time.deltaTime;
        transform.position = pos; 
            }
        } 
     //--END MOVEMENT INPUT--
     //--BEGIN PROJECTILE INPUT--
        if (Input.GetKey(KeyCode.Mouse1)){
            fireProjectile();
        }    
    }
    
    void fireProjectile(){ // Spawns a projectile at a constant fire rate if the mouse button is held down. 
    //If statement, compares the time from the last shot to the fire rate. and fires if enough time has passed
    if (Time.time > timeSinceLastShot + fireRate ){
        timeSinceLastShot = Time.time;
        GameObject projectile = Instantiate<GameObject> ( projectilePrefab );
        SoundManagerScript.PlaySound("fire");
        Vector3 projPos = transform.position;
        projPos.y = projPos.y + 5;
        projectile.transform.position = projPos;

        }
     
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject collidedWith = coll.gameObject;
        //Collision is a projectile
        if (collidedWith.tag == "ProjectileEnemy")
        {
            Destroy(collidedWith);
        }
        if (collidedWith.tag == "PowerUp"){
            Debug.Log("PowerUp Collision Detected");
            SoundManagerScript.PlaySound("powerUp");
            fireRate = fireRate * 0.95f; 
            Destroy(collidedWith);   
        }
    }

    public void stopShip()
    {
        shipSpeed = 0;
    }

}
