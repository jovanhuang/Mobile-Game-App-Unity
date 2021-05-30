using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This script is responsible for disabling the instructions at the start of the game.
public class DisableInstruction : MonoBehaviour
{
    /// Panel is a GameObject that holds HostSpeechCanvas.
    public GameObject Panel;
    /// This function hides the Panel.
    public void disablePanel()
    {
        Panel.SetActive(false);
    }

}
