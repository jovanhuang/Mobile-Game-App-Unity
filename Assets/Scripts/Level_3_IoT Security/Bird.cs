using UnityEngine;
using UnityEngine.SceneManagement;

/// This class is used to handle the behaviours of the green bird.
/// 
/// It will decides on what the bird do at every frame, in every possible situations (eg: hit a crate, hit a wall, hit a coin).
public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLaunched = false;
    private float _timeSittingAround;
    public GameObject Instruction;
 
    [SerializeField] private float _launchPower = 500;

    /// This method is called after all objects are initialized.
    /// 
    /// This assigns current position to initial position.
    public void Awake()
    {
        _initialPosition = transform.position;
    }

    /// This method is called every frame.
    /// 
    /// If the green bird has not moved for more than 2 seconds and it has been launched, it means the game has ended.
    /// Since game has ended, call next scene.
    public void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        if (_birdWasLaunched && 
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y > 10 || 
            transform.position.y < -10||
            transform.position.x > 15 ||
            transform.position.x < -15|| 
            _timeSittingAround > 2)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Lvl3_Dialog_TryAgain");
        }
    }
    /// This method is triggered when user has pressed the mouse button while over the Collider which in this case, is the green bird.
    /// 
    /// This method checks if bird has been launched.
    /// If bird has not been launched, it will destroy the instruction speech bubble and make the bird red to show that it is being clicked on.
    public void OnMouseDown()
    {
        if (_birdWasLaunched == false)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<LineRenderer>().enabled = true;
            Instruction = GameObject.Find("SpeechBubble");
            Destroy(this.Instruction);
        }
    }

    /// This method is triggered when the user has released the mouse button.
    /// 
    /// This method checks if bird has been launched.
    /// If bird has not been launched, it will calculate the vector difference between initial position and position after user has dragged it.
    /// It will then add force to the bird using the difference calculated. The forced applied on the bird is opposite to the direction which the user dragged. 
    public void OnMouseUp()
    {
        if (_birdWasLaunched == false)
        {
            GetComponent<SpriteRenderer>().color = Color.white;

            Vector2 directionToInitialPosition = _initialPosition - transform.position;

            GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            _birdWasLaunched = true;
            GetComponent<LineRenderer>().enabled = false;
        }
    }

    /// This method is triggered when the user has clicked on a Collider and is still holding down the mouse.
    /// 
    /// This method checks if bird has been launched.
    /// If bird has not been launched, it will limit the distance which user can drag the bird until.
    /// It will save the bird's new position after it has been dragged and assign it to transform position.
    public void OnMouseDrag()
    {
        if (_birdWasLaunched == false)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.x = Mathf.Clamp(newPosition.x, -9, -5);
            newPosition.y = Mathf.Clamp(newPosition.y, -6, 1.5f);
            transform.position = new Vector3(newPosition.x, newPosition.y);
        }
    }

}
