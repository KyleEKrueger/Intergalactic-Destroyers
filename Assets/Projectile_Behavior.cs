using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Behavior : MonoBehaviour
{
[Header("Set in Inspector")]
    private int friendOrfoe = 0; // 0 for a friendly projectile, 1 for a foe
    public float pSpeed = 2;
    public float deletionZone = 40;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 pos = transform.position;
        if (pos.y > 0 ){
            friendOrfoe = 1;
                    
        }
    }

    // Update is called once per frame
    void Update()
    {
    
        Vector2 pos = transform.position;
        if (friendOrfoe == 0){
            pos.y += pSpeed*Time.deltaTime ;
            transform.position = pos;         
            }
        if (friendOrfoe == 1){
            pos.y -= pSpeed*Time.deltaTime ;  
            transform.position = pos;       
            }
        //Boundry Check
        if (pos.y > deletionZone || pos.y < -deletionZone ){
            Destroy(this.gameObject);           
            }
        
    }
    void OnTriggerEnter2D(Collider2D coll){
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Alien"){
        Debug.Log("Alien Collision Detected");
        Destroy( collidedWith );        
        }
    }
}
