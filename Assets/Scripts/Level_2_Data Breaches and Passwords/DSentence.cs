using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

[System.Serializable]
/// This is the script for the dialogue box content.
/// 
/// It aids in dialogue sentence generation. It can also be used to customise the text area size.
public class DSentence 
{
    public string name;

    [TextArea(3,15)]
    public string[] sentences;
}
