using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
[Header("Set in Inspector")]
    public string TargetScene;

    public void LoadLevel(){
        SceneManager.LoadScene(TargetScene);        
        }
}
