using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This script is responsible for managing the falling applications.
public class FallingObject : MonoBehaviour
{
    private float[] listOfValues = new float[] {-12f, -7f, -2f};
    private Random rand = new Random();
    private LifeManager lifeSystem;
    private Points pointSystem;
    private float delayTimer;
    [SerializeField] AudioSource fxSource;
    [SerializeField] float speed;
    [SerializeField] float lowerBound;
    [SerializeField] float upperBound;
    [SerializeField] float position;
    [SerializeField] float LB;
    [SerializeField] float UB;

    // Start is called before the first frame update
    void Start()
    {
        fxSource = GetComponent<AudioSource>();
        lifeSystem = FindObjectOfType<LifeManager>();
        pointSystem = FindObjectOfType<Points>();
    }

    // Update is called once per frame
    void Update()
    {
        //move the object down the screen 
        //Vector3.down = 0,-1,0 move 1 unit down every time
        delayTimer += Time.deltaTime;
        if (LB < delayTimer){
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (LB < delayTimer && delayTimer < UB){
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
        if (lowerBound < delayTimer && delayTimer < upperBound)
        {
            //move the object back to the top of the screen and give a new random x coordinate
            //generate random number
            float randomNumber = listOfValues[Random.Range(0, listOfValues.Length)];
            // create vector 3 to store the new position we want the object to move to
            Vector3 newPos = new Vector3(randomNumber, 10f, 0);
            transform.position = newPos;
        }
        if (delayTimer > upperBound)
        {
            //move to top and disappear
            Vector3 newPos = new Vector3(0, position, 0);
            transform.position = newPos;
            //destroy batches of gameobjects after some time
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
                lifeSystem.takeLife();
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
                lifeSystem.takeLife();
                MoveToTop();
            }
        }
    }
}