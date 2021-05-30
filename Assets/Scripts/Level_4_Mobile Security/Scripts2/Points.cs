using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// This script is responsible for managing the number of points.
public class Points : MonoBehaviour
{
    /// Congrats Canvas shows when the player wins the game.
    public GameObject Congrats;
    /// The total number of points is initialised to be 0 at the start.
    private int pointNum=0;
    /// This variable helps to keep track of time.
    private float delayTimer;
    /// Number of points displayed.
    private Text theText;

    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<Text>();
        Congrats.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        delayTimer += Time.deltaTime;
        theText.text = "Points: " + pointNum;
        // Player suceeds either when he has 2000 points (full) or when he finishes the game without losing all lives.(takes about 50s)
        if (pointNum == 2000 || delayTimer > 50f)
        {
            Congrats.gameObject.SetActive(true);
        }
    }

    /// Adds points when a falling object is correctly classified.
    public void AddPoints()
    {
        pointNum += 100;
    }
}
