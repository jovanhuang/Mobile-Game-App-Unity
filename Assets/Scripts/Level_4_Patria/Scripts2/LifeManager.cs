using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// This script is responsible for managing lives.
public class LifeManager : MonoBehaviour
{
    /// Determines the number of lives at the start.
    public int startingLives;
    /// Audio played when live is lost.
    public AudioSource loseLiveSource;
    /// Counter to keep track of number of lives.
    private int lifeCounter;
    /// Canvas displayed when game over.
    public GameObject gameOver;
    /// Text detailing the number of lives.
    private Text theText;

    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<Text>();
        lifeCounter = startingLives;
        loseLiveSource = GetComponent<AudioSource>();
        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        theText.text = "x" + lifeCounter;
        if (lifeCounter == 0)
        {
            gameOver.gameObject.SetActive(true);
        }
    }
    /// This function decreases one life.
    public void takeLife()
    {
        if (lifeCounter>0)
        {
            lifeCounter--;
            loseLiveSource.Play();
        }
    }
    /// This function is a boolean for zero lives.
    public bool zeroLives()
    {
        if (lifeCounter == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}