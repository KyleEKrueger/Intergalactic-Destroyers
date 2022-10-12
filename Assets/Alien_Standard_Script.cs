using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Alien_Standard_Script : MonoBehaviour
{
    public int health;
    public float speed = 10;
    public float wallWidth = 30;
    public float floorHeight = -35;
    public float powerUpSpawnChance = 0.2f;
    private float powerUpRoll;
    public GameObject powerUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        //Changing Direction
        if (pos.x < -wallWidth ){
            speed = Mathf.Abs(speed);        
        }
        else if (pos.x > wallWidth){
            speed = -Mathf.Abs(speed);
        }
        //Move across the X axis
        pos.x += speed*Time.deltaTime;
        transform.position = pos;
    }

     void OnTriggerEnter2D(Collider2D coll){
        GameObject collidedWith = coll.gameObject;
        //Collision is a projectile
        if (collidedWith.tag == "Projectile"){
        powerUpRoll = Random.value;
        if (powerUpRoll <= powerUpSpawnChance){
           GameObject powerUp = Instantiate<GameObject>(powerUpPrefab);
            Vector2 pos = transform.position;
           powerUp.transform.position = pos;
        }
        Destroy( collidedWith );        
        }
        //Collision is a ship
        if(collidedWith.tag == "Alien")
        {
            speed = -speed;
        }
    }
    
}
