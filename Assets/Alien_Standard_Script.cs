using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_Standard_Script : MonoBehaviour
{
    public int health;
    public float speed = 10;
    public float wallWidth = 30;
    public float floorHeight = -35;
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
        if (collidedWith.tag == "Projectile"){
        Debug.Log("Projectile Collision Detected");
        Destroy( collidedWith );        
        }
    }
    
}
