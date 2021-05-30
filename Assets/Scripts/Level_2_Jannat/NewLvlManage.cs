using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// This is the script for the main manager file for EndLvlScene.
/// 
/// On a mouse click, it transitions to the next scene.
public class NewLvlManage : MonoBehaviour
{
    
    /// Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            string nextmoving= "";
            SceneManager.LoadScene("Introduction");
        }
    }
}
