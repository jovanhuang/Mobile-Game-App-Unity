using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// endScene class is responsible for transition to end scene
public class endScene : MonoBehaviour
{
    /// OnTriggerEnter2D function is responsible for transition to end scene if game object and player collides
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "THE END")
        {
            SceneManager.LoadScene("LastScene"); 
        }
    }

}
