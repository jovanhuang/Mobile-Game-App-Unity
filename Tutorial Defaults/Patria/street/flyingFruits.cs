
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingFruits : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (transform.position.x < screenBounds.x * 32)
        {
            Destroy(this.gameObject);
        }
    }

}
