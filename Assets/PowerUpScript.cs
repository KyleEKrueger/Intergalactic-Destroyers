using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public int friendOrFoe = -1; //Will be 1 for friend, -1 for foe.
    public float dropSpeed = 0.5f;
    public float deletionZone = 40f;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.value >= 0.5){
            // Change the value of friend or foe    
            friendOrFoe = friendOrFoe * -1;       
            }
        dropSpeed = dropSpeed * friendOrFoe;
    }

    // Update is called once per frame
    void Update()
    {
    Vector2 pos = transform.position;
    //Fall towards friend or foe
        pos.y += dropSpeed*Time.deltaTime;
        transform.position = pos;
        //BoundryCheck
        if (pos.y > deletionZone || pos.y < -deletionZone ){
            Destroy(this.gameObject);           
            }
        
    }
    
}
