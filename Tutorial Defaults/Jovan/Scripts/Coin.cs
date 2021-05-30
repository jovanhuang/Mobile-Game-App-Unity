using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Destroy(gameObject);
            return;
        }
        //if coin has been hit, get out of this method
        Coin coin = collision.collider.GetComponent<Coin>();
        if (coin != null)
        {
            return;
        }

        //if reach here means bird didn't hit a coin

        // new deal with crates hitting coins
        //collision.contacts gives the collection of contacts (in array)
        if (collision.contacts[0].normal.y != null)
        {
            Destroy(gameObject);
        }



        //if (collision.contacts[0].normal.y < -0.5)
        // {
        //     Destroy(gameObject);
        // }

    }
}
