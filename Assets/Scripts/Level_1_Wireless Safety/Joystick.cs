using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// The script helps to integrate the use of a joystick in the spacesship shooting game.
public class Joystick : MonoBehaviour
{
    /// Represents the spaceship.
    public Transform player;
    /// Represents the speed of the spaceship.
    public float speed = 15.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    /// Represents the inner circle in the joystick.
    public Transform circle;
    /// Represents the outer circle in the joystick.
    public Transform outerCircle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //moveCharacter(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))); //keyboard

        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            circle.transform.position = pointA * -1;
            outerCircle.transform.position = pointA * -1;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }

    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * -1);

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    /// Function is called whenver the joystick is moved.
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
