using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This script is responsible for initialising the random index which the thief appears and managing the visibility of Canvases.
public class GameObjectInitialisation : MonoBehaviour
{
    /// Initialise canvas gameobjects.
    public GameObject Canvas, Canvas1, Canvas2, Canvas3, Canvas4, Canvas5, Canvas6, Canvas7, Canvas8;
    /// Initialise the Control Buttons.
    [SerializeField] private GameObject Left, Right, Jump;
    /// Listing the names of the monster sprites.
    private string[] monsterList = new string[] {"monster1", "monster2", "monster3", "monster4", "monster5", "monster6", "monster7", "monster8"};
    /// Initialising the randomIndex to pick a monster from the list.
    private int randomIndex;

    /// Getter method for monsterList.
    public string[] getMonsterList(){
        return monsterList;
    }
    /// Setter method for monsterList.
    private void setMonsterList(string[] ml){
        monsterList = ml;
    }
    /// Getter method for randomIndex.
    public int getRandomIndex(){
        return randomIndex;
    }
    /// Set Canvases to False at the Start of the Game.
    void Start()
    {
        Canvas.gameObject.SetActive(false);
        Canvas1.gameObject.SetActive(false);
        Canvas2.gameObject.SetActive(false);
        Canvas3.gameObject.SetActive(false);
        Canvas4.gameObject.SetActive(false);
        Canvas5.gameObject.SetActive(false);
        Canvas6.gameObject.SetActive(false);
        Canvas7.gameObject.SetActive(false);
        Canvas8.gameObject.SetActive(false);
        // randomise the monster list index being called
        randomIndex = Random.Range(0, monsterList.Length);

        
    }
    /// Set of actions undertaken when Current Object collides with Other Objects.
    void OnTriggerEnter2D(Collider2D other)
    {
        // Buttons are set to be invisible so that player cannot progress without reading through the dialogues
        Left.gameObject.SetActive(false);
        Right.gameObject.SetActive(false);
        Jump.gameObject.SetActive(false);
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
