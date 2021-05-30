 using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLaunched = false;
    private float _timeSittingAround;
 
    [SerializeField] private float _launchPower = 500;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
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

    private void OnMouseDown()
    {
        if (_birdWasLaunched == false)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<LineRenderer>().enabled = true;
        }
    }

    private void OnMouseUp()
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

    private void OnMouseDrag()
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
