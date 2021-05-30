using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// This script is in charge of the logic of validating the correct catch in the WiFi Catching game.
public class Trigger : MonoBehaviour
{
    /// Game object representing the grabber.
    public GameObject Grabber;
    /// Game object representing the Wifi Name.
    public GameObject WifiName;
    /// Game object representing the explosion animation.
    public GameObject ExplosionAnim;
    /// Game object representing the fish.
    public GameObject Fish;

    /// Game object representing the explosion.
    public GameObject Explosion;

    /// Audio that is played in the background in the game.
    public AudioSource BackgroundAudio;
    /// Audio that is played whenever the user catches the wrong Wifi.
    public AudioSource ExplosionAudio;
    /// Audio that is played whenever the user selects the correct Wifi.
    public AudioSource CorrectAudio;

    void Start()
    {
        BackgroundAudio.Play();
    }

    /// Function that is called whenver the user presses Catch,  which helps to validate whether the user is correct or wrong.
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
