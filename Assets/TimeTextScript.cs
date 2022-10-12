using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeTextScript : MonoBehaviour
{
    public TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = Time.time.ToString();
    }
}
