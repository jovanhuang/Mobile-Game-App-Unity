using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This script is used to set the correct resolution for the cross-platform mobile devices.
/// 
/// For standardization, set resolution 1920x1080.
public class SetResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
