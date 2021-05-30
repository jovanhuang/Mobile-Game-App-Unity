using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployEnemy : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }
    IEnumerator asteroidWave()
    {
        // Spawn enemies for 30 seconds
        while (Time.timeSinceLevelLoad < 30)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}