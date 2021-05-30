using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popOutMessage : MonoBehaviour
{
    public GameObject Canvas, Canvas1, Canvas2, Canvas3, Canvas4, Canvas5, Canvas6, Canvas7, Canvas8;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("got start");
        Canvas.gameObject.SetActive(false);
        Canvas1.gameObject.SetActive(false);
        Canvas2.gameObject.SetActive(false);
        Canvas3.gameObject.SetActive(false);
        Canvas4.gameObject.SetActive(false);
        Canvas5.gameObject.SetActive(false);
        Canvas6.gameObject.SetActive(false);
        Canvas7.gameObject.SetActive(false);
        Canvas8.gameObject.SetActive(false);

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject.name == "monster2")
        // {
        //     Debug.Log("got collide again");
        //     Canvas.gameObject.SetActive(true);
        // }
        string option = other.gameObject.name;
        switch(option)
        {
            case "monster1":
                Canvas.gameObject.SetActive(true);
                break;
            case "monster2":
                Canvas1.gameObject.SetActive(true);
                break;
            case "monster3":
                Canvas2.gameObject.SetActive(true);
                break;
            case "monster4":
                Canvas3.gameObject.SetActive(true);
                break;
            case "monster5":
                Canvas4.gameObject.SetActive(true);
                break;
            case "monster6":
                Canvas5.gameObject.SetActive(true);
                break;
            case "monster7":
                Canvas6.gameObject.SetActive(true);
                break;
            case "monster8":
                Canvas7.gameObject.SetActive(true);
                break;
            case "Thief":
                Canvas8.gameObject.SetActive(true);
                break;
        }
    }

}
