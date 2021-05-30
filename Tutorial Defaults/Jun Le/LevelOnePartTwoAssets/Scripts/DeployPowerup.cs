using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployPowerup : MonoBehaviour
{
    public GameObject powerupPrefab;
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