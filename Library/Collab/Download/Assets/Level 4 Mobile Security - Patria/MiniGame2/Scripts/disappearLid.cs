using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;




public class disappearLid : MonoBehaviour
{
    public GameObject Panel;
    int counter;

    public void showhidePanel()
    {
        counter++;
        if (counter%2!=0)
        {
            Panel.gameObject.SetActive(false);
        }
        else
        {
            Panel.gameObject.SetActive(true);
        }
    }


}
