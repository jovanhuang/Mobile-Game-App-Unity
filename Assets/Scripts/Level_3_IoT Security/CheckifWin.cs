using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// This class is used to check if user has managed to win Level 3.
/// 
/// It checks if all coins has been collected.
public class CheckifWin : MonoBehaviour
{
    private bool _allCoinsCollected = false;
    private Coin[] _coins;

    /// This method is called when the object becomes enabled and active.
    /// 
    /// It gets all the objects that is of type Coin.
    public void OnEnable()
    {
        _coins = FindObjectsOfType<Coin>();
    }

    /// This method is called every frame.
    /// 
    /// If there is still a single coin left, do a return to stop this function.
    /// If there is not a single coin left, user has collected all of it and win the game. Load next scene.
    public void Update()
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
            SceneManager.LoadScene("Lvl3_Dialog_Scene4.1");
        }
        
    }
}
