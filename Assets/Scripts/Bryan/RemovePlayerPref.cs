using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// RemovePlayerPref class removes stored data within a project under player preferences between game sessions
public class RemovePlayerPref : MonoBehaviour
{
    /// Awake is called when the script instance is being loaded.
    /// Awake function here deletes data under player preferences
    void Awake()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
