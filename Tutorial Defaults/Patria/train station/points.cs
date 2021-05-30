using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class points : MonoBehaviour
{
    public GameObject Congrats;
    private int pointNum=0;
    private float delayTimer;
    private Text theText;

    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<Text>();
        Congrats.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        delayTimer += Time.deltaTime;
        theText.text = "Points: " + pointNum;
        if (pointNum == 2000 || delayTimer > 50f)
        {
            Congrats.gameObject.SetActive(true);
        }
    }

    public void AddPoints()
    {
        pointNum += 100;
    }
}
