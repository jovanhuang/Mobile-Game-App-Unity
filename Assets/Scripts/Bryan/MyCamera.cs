using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// MyCamera is responsible for the camera behaviour
public class MyCamera : MonoBehaviour
{
    /// @param player is the game object "Player"
    public GameObject player;
    /// @param thief is the game object "Thief"
    public GameObject thief;
    /// @param playerPosition gets the vector of the player
    private Vector3 playerPosition;
    /// @param leftLimit left limit vector
    public float leftLimit;
    /// @param rightLimit right limit vector
    public float rightLimit;
    /// @param topLimit top limit vector
    public float topLimit;
    /// @param bottomLimit bottom limit vector
    public float bottomLimit;

    /// Start is called before the first frame update
    /// Start function here hides game object thief
    void Start()
    {
        thief.SetActive(false);
    }

    /// Update is called once per frame
    /// Update function here sets the vector of the camera to follow the player's vector and limits the boundaries of the camera vector
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
