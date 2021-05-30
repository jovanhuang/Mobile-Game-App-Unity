using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// This class is used to handle background sound in Level 3.
/// 
/// It will decide when the background sound for Level 3 will start and end.
public class BGSoundScript : MonoBehaviour
{
    private static BGSoundScript instance = null;
    public static BGSoundScript Instance
    {
        get { return instance; }
    }

    /// This method is called after all objects are initialized.
    /// 
    /// The background sound for Level 3 will end when it reaches "Game" Scene.
    public void Awake()
    {
        if (instance !=null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        if (SceneManager.GetActiveScene ().name == "Game") 
        {
            Destroy(this.gameObject);
        }
    }
}
