using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSlingShotAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SlingShotAudio.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
