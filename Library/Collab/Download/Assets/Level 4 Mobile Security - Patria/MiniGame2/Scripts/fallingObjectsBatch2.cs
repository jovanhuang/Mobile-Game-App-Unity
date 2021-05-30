using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingObjectsBatch2 : MonoBehaviour
{
    public int speed; //speed is how many units per second we move
    private float[] listOfValues = new float[] {-12f, -7f, -2f};
    private Random rand = new Random();
    public AudioSource fxSource;
    private points pointSystem;
    private lifeManager lifeSystem;
    private float delayTimer;

    // Start is called before the first frame update
    void Start()
    {
        // speed = Random.Range(1,5);
        fxSource = GetComponent<AudioSource>();
        lifeSystem = FindObjectOfType<lifeManager>();
        pointSystem = FindObjectOfType<points>();
    }

    // Update is called once per frame
    void Update()
    {
        //move the object down the screen 
        //Vector3.down = 0,-1,0 move 1 unit down every time
        delayTimer += Time.deltaTime;
        if (33f <delayTimer)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        if (33f < delayTimer && delayTimer < 45f)
        {
            Debug.Log("hey1");
            if (transform.position.y < -2.09f)
            {
                MoveToTop();
            }
        }
        if (lifeSystem.zeroLives())
        {
            gameObject.SetActive(false);
        }
    }

    void MoveToTop()
    {   
        if (33f < delayTimer && delayTimer < 45f)
        {
            //move the object back to the top of the screen and give a new random x coordinate
            //generate random number
            float randomNumber = listOfValues[Random.Range(0, listOfValues.Length)];
            // create vector 3 to store the new position we want the object to move to
            Vector3 newPos = new Vector3(randomNumber, 10f, 0);
            transform.position = newPos;
            //give new random speed
            // speed = Random.Range(1,5);
        }
        if (delayTimer > 45f)
        {
            //PLEASE MOVE TO TOP AND DISAPPEAR
            Debug.Log("hey2");
            Vector3 newPos = new Vector3(0, 100f, 0);
            transform.position = newPos;
            // transform.Translate(Vector3.down * Time.deltaTime * speed);
            Destroy(gameObject, 5);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "lid")
        {
            if (gameObject.tag == "good")
            {
                //bad
                lifeSystem.TakeLife();
                MoveToTop();
                
            }
            else if (gameObject.tag == "bad")
            {
                //good
                pointSystem.AddPoints();
                fxSource.Play();
                MoveToTop();
            }
        }

        if (other.gameObject.tag == "basket")
        {
            Debug.Log("touch basket liao");
            if (gameObject.tag == "good")
            {
                //good
                pointSystem.AddPoints();
                fxSource.Play();
                MoveToTop();
            }
            else if (gameObject.tag == "bad")
            {
                //bad
                lifeSystem.TakeLife();
                MoveToTop();
            }
        }
    }


    public void destroyGameObject()
    {
        Destroy(gameObject);
    }
}
