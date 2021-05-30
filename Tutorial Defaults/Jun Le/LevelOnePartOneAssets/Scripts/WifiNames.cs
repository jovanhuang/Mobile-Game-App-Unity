using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WifiNames : MonoBehaviour
{
    public GameObject WifiName;
    public GameObject Fish;
    public AudioSource MissCorrectAudio;
    public string[] wifiNames = { "Wireless@SG", "Real WiFi", "WiFi@Changi", "Secure wifi", "Govt Wifi" };
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
        SceneManager.LoadScene("Level1_1.3");
    }
}
