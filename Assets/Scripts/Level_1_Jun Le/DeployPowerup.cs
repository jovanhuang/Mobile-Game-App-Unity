using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// The script is used to deploy the Powerup on a fixed time interval.
public class DeployPowerup : MonoBehaviour
{
    /// Game Object representing the prefab of the Powerup.
    public GameObject powerupPrefab;
    /// Time interval for the powerup respawn.
    public float respawnTime = 10.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(powerupWave());
    }
    private void spawnPowerup()
    {
        Debug.Log("spawn");
        GameObject a = Instantiate(powerupPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }
    IEnumerator powerupWave()
    {
        while (Time.timeSinceLevelLoad < 30)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnPowerup();
        }
    }
}