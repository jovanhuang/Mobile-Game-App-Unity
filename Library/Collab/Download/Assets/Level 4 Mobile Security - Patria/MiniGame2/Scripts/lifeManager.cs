using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class lifeManager : MonoBehaviour
{
    public int startingLives;
    public AudioSource loseLiveSource;
    private int lifeCounter;
    public GameObject gameOver;

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
            Debug.Log("zero alr leh");
            gameOver.gameObject.SetActive(true);
        }
    }

    public void TakeLife()
    {
        if (lifeCounter>0)
        {
            lifeCounter--;
            loseLiveSource.Play();
        }
    }

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

    public void destroyGameObject(GameObject obj)
    {
        Destroy(obj);
    }
}
