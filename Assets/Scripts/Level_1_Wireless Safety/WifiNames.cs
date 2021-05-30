using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// This script is responsible for handling the Wifi names to be displayed in the Wifi Catching game,.
public class WifiNames : MonoBehaviour
{
    /// Game object representing the Wifi Name.
    public GameObject WifiName;
    /// Game object representing the Fish.
    public GameObject Fish;
    /// Audio that is played when the incorrect Wifi Name is picked.
    public AudioSource MissCorrectAudio;
    /// Array representing the Wifi names.
    public string[] wifiNames = { "Wireless@SG", "Real WiFi", "WiFi@Changi", "Secure wifi", "Govt Wifi" };
    /// Hash map to keep track whether each Wifi has been displayed and pressed.
    public static IDictionary<string, bool> secureWifiPickedTracker;


    void Start()
    {
        StartCoroutine(ShowWifiName(wifiNames));
        secureWifiPickedTracker = new Dictionary<string, bool>() {
        {"Wireless@SG" , false }, {"WiFi@Changi", false}
    };

    }

    IEnumerator ShowWifiName (string[] wifiNames) {
        foreach (string name in wifiNames)
        {
            Fish.SetActive(true);
            WifiName.GetComponent<Text>().text = name;
            yield return new WaitForSeconds(3);

            //after 3 seconds if secure wifi not picked, deduct a live
            if (secureWifiPickedTracker.ContainsKey(name) && secureWifiPickedTracker[name] == false)
            {
                LivesController.livesCount--;
                MissCorrectAudio.Play();
            }
        }

        // If successfully clear the game, load next scene
        if (LivesController.livesCount > 0) SceneManager.LoadScene("Level1_1.3");
    }
}
