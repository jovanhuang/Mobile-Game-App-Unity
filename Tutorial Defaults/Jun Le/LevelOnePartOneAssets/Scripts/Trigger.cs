using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public GameObject Grabber;
    public GameObject WifiName;
    public GameObject ExplosionAnim;
    public GameObject Fish;

    public GameObject Explosion;

    public AudioSource ExplosionAudio;
    public AudioSource CorrectAudio;

    // Update is called once per frame
    public void OnTrigger ()
    {
        Grabber.GetComponent<Animation>().Play("GrabAnim");

        if (!WifiNames.secureWifiPickedTracker.ContainsKey(WifiName.GetComponent<Text>().text))
        {
            Debug.Log("Bad");
            //Deduct life
            LivesController.livesCount --;

            // Animation
            ExplosionAnim.SetActive(true);
            ExplosionAnim.transform.position = Fish.transform.position;
            ExplosionAnim.GetComponent<Animation>().Play("Explosion");

            //Audio
            ExplosionAudio.Play();

        } else
        {
            Debug.Log("Good");
            WifiNames.secureWifiPickedTracker[WifiName.GetComponent<Text>().text] = true;
            CorrectAudio.Play();
        }

        //Remove after each trigger
        Fish.SetActive(false);
        WifiName.GetComponent<Text>().text = "";


    }

}
