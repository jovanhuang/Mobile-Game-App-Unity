using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
/// This script is responsible for managing the visibility of the lid.
public class DisappearLid : MonoBehaviour
{
    /// Lid is a sprite GameObject.
    public GameObject Lid;
    private int counter;
    /// Alternate clicks enables and disables the lid.
    public void showhidePanel()
    {
        counter++;
        if (counter%2!=0)
        {
            Lid.gameObject.SetActive(false);
        }
        else
        {
            Lid.gameObject.SetActive(true);
        }
    }


}
