using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This class is used to handle the behaviours of the coin.
/// 
/// It will decides on what the coin do at every frame, in every possible situations (eg: coming into contact with a crate or bird).
public class Coin : MonoBehaviour
{
    /// This method is called when an incoming collider makes contact with this object's (coin) collider (2D physics only).
    /// 
    /// It will destroy the coin once it comes into contact with the bird or the crate.
    /// @param collision This will get us the Collision details returned by 2D physics callback functions of the coin.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Destroy(gameObject);
            return;
        }
        //if coin has been hit, get out of this method by doing a return.
        Coin coin = collision.collider.GetComponent<Coin>();
        if (coin != null)
        {
            return;
        }

        //if reach here means bird didn't hit a coin.

        //now, this part deals with crates hitting coins.
        //collision.contacts gives us the collection of contacts (in array)
        //if there is any other contact, coin will be destroyed. In this case, the only possible contact is with crates apart from the green bird.
        if (collision.contacts[0].normal.y != null)
        {
            Destroy(gameObject);
        }
    }
}
