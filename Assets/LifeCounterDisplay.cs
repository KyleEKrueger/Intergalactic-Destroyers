using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeCounterDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Component playerHealth;
    TMP_Text tmpHealth;
    
    void Start()
    {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<Health_and_Status>();
        displayHearts();
    }

    // Update is called once per frame
    void Update()
    {
        displayHearts();
    }

         // Displays life remaining
    void displayHearts(){
        int i = 0;
        string hearts = "";
        tmpHealth.text = "";
        for(i = 0; i < 3; i++ ){
            hearts += "<3 ";
    }
        tmpHealth.text = hearts;
}
}
