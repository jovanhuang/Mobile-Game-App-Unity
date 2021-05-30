using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckifWin : MonoBehaviour
{
    private bool _allCoinsCollected = false;
    private Coin[] _coins;


    private void OnEnable()
    {
        _coins = FindObjectsOfType<Coin>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Coin coin in _coins)
        {
            if (coin != null)
                return;
        }
        
        _allCoinsCollected = true;
        
        if (_allCoinsCollected)
        {
            Debug.Log("You managed to get all the coins!");
            wait();
            SceneManager.LoadScene("Lvl3_Dialog_Scene4.1");
        }
        
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }

}
