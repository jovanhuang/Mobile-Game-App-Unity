using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotAudio : MonoBehaviour
{
    private static SlingShotAudio instance = null;
    public static SlingShotAudio Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
