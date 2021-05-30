using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// MusicDestructor class is responsible for destroying music when not in use
public class MusicDestructor : MonoBehaviour
{
    /// Start is called before the first frame update
    /// Start function here destroys music if scene is not "Introduction"
    void Start()
    {
        if (SceneManager.GetActiveScene().name == ("Introduction"))
        {
            Destroy(gameObject);
        }
    }
}
