using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes
{

    [SerializeField] private string playerName;
    [SerializeField] private int chosenAnimal;
    
    //player position
    [SerializeField] private Vector2 playerPosition;

    //AP
    [SerializeField] private int maxAP = 6;
    private int currentAP;

    //a enum that has powers

    //a list of all the vegetables the player has
    private List<Vegetable> vegetables = new List<Vegetable>();
    
    // a list of powers the player has
    private List<Power> powers = new List<Power>();
    
    //bool if the player has left
    private bool hasLeft = false;

    //int player leave order
    public int playerLeaveOrder;
    
    //int player score
    public int playerScore;
    
    // Start is called before the first frame update


    //getters and setters
    public List<Vegetable> Vegetables
    {
        get => vegetables;
        set => vegetables = value;
    }

    //add a vegetable to the list
    public void AddVegetable(Vegetable vegetable)
    {
        vegetables.Add(vegetable);
    }

    //remove a vegetable from the list
    public void RemoveVegetable(Vegetable vegetable)
    {
        vegetables.Remove(vegetable);
    }
    
    //getter and setter for the player name
    public string PlayerName
    {
        get => playerName;
        set => playerName = value;
    }
    
    //getter and setter for the chosen animal
    public int ChosenAnimal
    {
        get => chosenAnimal;
        set => chosenAnimal = value;
    }
    
    //getter and setter for the player position
    public Vector2 PlayerPosition
    {
        get => playerPosition;
        set => playerPosition = value;
    }

    //getter and setter for has left
    public bool HasLeft
    {
        get => hasLeft;
        set => hasLeft = value;
    }
    
    //getter and setter for currentAP
    public int CurrentAP
    {
        get => currentAP;
        set => currentAP = value;
    }
    
    //constructor with player name and chosen animal
    public PlayerAttributes(string playerName, int chosenAnimal)
    {
        this.playerName = playerName;
        this.chosenAnimal = chosenAnimal;
    }

    public PlayerAttributes()
    {
        this.playerName = "PlaceHolder";
        this.chosenAnimal = 0;
    }

    // private void MoveToGrid(Vector2 TargetPosition)
    // {
    //     //move the player to the grid position
    //     if (!hasLeft)
    //     {
    //         //roundedUp = (int)Math.Ceiling(precise);
    //         int APNeeded = (int)Math.Ceiling(Math.Abs(TargetPosition.x - playerPosition.x) + Math.Abs(TargetPosition.y - playerPosition.y));
    //     
    //         if (APNeeded <= currentAP)
    //         {
    //             currentAP -= APNeeded;
    //             playerPosition = TargetPosition;
    //         }
    //     }
    // }

}

