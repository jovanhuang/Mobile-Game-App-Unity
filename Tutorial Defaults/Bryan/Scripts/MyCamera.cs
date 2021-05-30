using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public GameObject player;
    public GameObject thief;
    private Vector3 playerPosition;
    public float leftLimit;
    public float rightLimit;
    public float topLimit;
    public float bottomLimit;

    // Start is called before the first frame update
    void Start()
    {
        thief.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(player.transform.position.x,
        // transform.position.y,
        // transform.position.z);

        playerPosition = new Vector3(player.transform.position.x,
        player.transform.position.y, 
        transform.position.z);

        // transform.position = playerPosition;

        transform.position = new Vector3(
            Mathf.Clamp(player.transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(player.transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
    }
}
