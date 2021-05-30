using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableInstruction : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    public void disablePanel()
    {
        Panel.SetActive(false);
    }

}
