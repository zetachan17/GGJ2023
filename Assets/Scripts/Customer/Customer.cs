using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Customer : MonoBehaviour
{
    // GameObject _gameObject
    private Power _power;

    private Dictionary<Vegetable.VegetableType, int> quest = new Dictionary<Vegetable.VegetableType, int>();

    public Dictionary<Vegetable.VegetableType, int> getQuest()
    {
        return quest;
    }

    public void CreateQuests(string customerType)
    {
        Dictionary<Vegetable.VegetableType, int> newRequest = new Dictionary<Vegetable.VegetableType, int>();
        switch (customerType)
        {
            //charioteer
            case "charioteer":
                newRequest.Add(Vegetable.VegetableType.carrot, 1);
                newRequest.Add(Vegetable.VegetableType.potato, 1);
                newRequest.Add(Vegetable.VegetableType.turnip, 1);
                break;
            //connaisseur 1
            case "potatoConnaisseur":
                newRequest.Add(Vegetable.VegetableType.potato, 3);
                break;
            //connaisseur 2
            case "turnipConnaisseur":
                newRequest.Add(Vegetable.VegetableType.turnip, 3);
                break;
            //connaisseur 3
            case "carrotConnaisseur":
                newRequest.Add(Vegetable.VegetableType.carrot, 3);
                break;
            //soupGuy 
            case "armyChef":
                break;
            //standard3
            case "standard3":
                var randomQuest3 = Random.Range(0, 7);
                switch (randomQuest3)
                {
                    case 0:
                        newRequest.Add(Vegetable.VegetableType.carrot, 2);
                        newRequest.Add(Vegetable.VegetableType.turnip, 1);
                        break;
                    case 1:
                        newRequest.Add(Vegetable.VegetableType.carrot, 2);
                        newRequest.Add(Vegetable.VegetableType.potato, 1);
                        break;
                    case 2:
                        newRequest.Add(Vegetable.VegetableType.turnip, 2);
                        newRequest.Add(Vegetable.VegetableType.carrot, 1);
                        break;
                    case 3:
                        newRequest.Add(Vegetable.VegetableType.turnip, 2);
                        newRequest.Add(Vegetable.VegetableType.potato, 1);
                        break;
                    case 4:
                        newRequest.Add(Vegetable.VegetableType.potato, 2);
                        newRequest.Add(Vegetable.VegetableType.carrot, 1);
                        break;
                    case 5:
                        newRequest.Add(Vegetable.VegetableType.potato, 2);
                        newRequest.Add(Vegetable.VegetableType.turnip, 1);
                        break;
                    case 6:
                        newRequest.Add(Vegetable.VegetableType.carrot, 1);
                        newRequest.Add(Vegetable.VegetableType.turnip, 1);
                        newRequest.Add(Vegetable.VegetableType.potato, 1);
                        break;
                }

                break;
            //standard4
            case "standard4":
                var randomQuest4 = Random.Range(0, 12);
                switch (randomQuest4)
                {
                    case 0:
                        newRequest.Add(Vegetable.VegetableType.carrot, 3);
                        newRequest.Add(Vegetable.VegetableType.turnip, 1);
                        break;
                    case 1:
                        newRequest.Add(Vegetable.VegetableType.carrot, 3);
                        newRequest.Add(Vegetable.VegetableType.potato, 1);
                        break;
                    case 2:
                        newRequest.Add(Vegetable.VegetableType.turnip, 3);
                        newRequest.Add(Vegetable.VegetableType.carrot, 1);
                        break;
                    case 3:
                        newRequest.Add(Vegetable.VegetableType.turnip, 3);
                        newRequest.Add(Vegetable.VegetableType.potato, 1);
                        break;
                    case 4:
                        newRequest.Add(Vegetable.VegetableType.potato, 3);
                        newRequest.Add(Vegetable.VegetableType.carrot, 1);
                        break;
                    case 5:
                        newRequest.Add(Vegetable.VegetableType.potato, 3);
                        newRequest.Add(Vegetable.VegetableType.turnip, 1);
                        break;
                    case 6:
                        newRequest.Add(Vegetable.VegetableType.carrot, 2);
                        newRequest.Add(Vegetable.VegetableType.turnip, 2);
                        break;
                    case 7:
                        newRequest.Add(Vegetable.VegetableType.carrot, 2);
                        newRequest.Add(Vegetable.VegetableType.potato, 2);
                        break;
                    case 8:
                        newRequest.Add(Vegetable.VegetableType.potato, 2);
                        newRequest.Add(Vegetable.VegetableType.turnip, 2);
                        break;
                    case 9:
                        newRequest.Add(Vegetable.VegetableType.potato, 1);
                        newRequest.Add(Vegetable.VegetableType.turnip, 1);
                        newRequest.Add(Vegetable.VegetableType.carrot, 2);
                        break;
                    case 10:
                        newRequest.Add(Vegetable.VegetableType.potato, 1);
                        newRequest.Add(Vegetable.VegetableType.carrot, 1);
                        newRequest.Add(Vegetable.VegetableType.turnip, 2);
                        break;
                    case 11:
                        newRequest.Add(Vegetable.VegetableType.potato, 2);
                        newRequest.Add(Vegetable.VegetableType.carrot, 1);
                        newRequest.Add(Vegetable.VegetableType.turnip, 1);
                        break;
                }

                break;
        }


        quest = newRequest;
    }


    public void SetUpCustomers(int type)
    {
        switch (type)
        {
            //OverPayer
            case 1:
                _power = Power.DoublePoints;
                CreateQuests("standard3");
                break;
            //TeleportWizard
            case 2:
                _power = Power.Teleport;
                CreateQuests("standard4");
                break;
            //Ap dealer
            case 3:
                _power = Power.ApBoost;
                CreateQuests("standard4");
                break;
            //Hortimancer
            case 4:
                _power = Power.AdjacentVeggie;
                CreateQuests("standard4");
                break;
            //Moleman
            case 5:
                _power = Power.ReducePull;
                CreateQuests("standard4");
                break;
            //Construction Worker
            case 6:
                _power = Power.Block;
                CreateQuests("standard4");
                break;
            //potato connaisseur 
            case 7:
                _power = Power.PriceBoost;
                CreateQuests("potatoConnaisseur");
                break;
            //carrot connaisseur
            case 8:
                _power = Power.PriceBoost;
                CreateQuests("carrotConnaisseur");
                break;
            //turnip connaisseur
            case 9:
                _power = Power.PriceBoost;
                CreateQuests("turnipConnaisseur");
                break;
            //normal
            case 10:
                _power = Power.None;
                CreateQuests("standard4");
                break;
            //normal
            case 11:
                _power = Power.None;
                CreateQuests("standard4");
                break;
            //charioteer
            case 12:
                _power = Power.FirstPlayer;
                CreateQuests("charioteer");
                break;
            //armyChef
            case 13:
                _power = Power.None;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.transform.localScale += new Vector3(1, 1, 0);
        print("this is highlighted");

        GameInfo gameInfo = FindObjectOfType<GameInfo>();

        checkIfEligible(gameInfo.mPlayer1.Vegetables);
        print("player1: " + gameInfo.mPlayer1.Vegetables);

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Sell!");
            GameInfo gameInfo = FindObjectOfType<GameInfo>();
            completeQuest(gameInfo.mPlayer1.Vegetables);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.transform.localScale -= new Vector3(1, 1, 0);
        print("this is leaving forever");
    }

    public void completeQuest(List<Vector2Int> playerInventory)
    {
        if (checkIfEligible(playerInventory))
        {
            int score = 0;
            foreach(var vege in quest)
            {
                score += 10;

            }
            quest.Clear();
            GameInfo gameInfo = FindObjectOfType<GameInfo>();
            gameInfo.mPlayer1.playerScore += score;
            gameInfo.mPlayer1.Vegetables.Clear();
            
            GetComponent<SpriteRenderer>().color = Color.black;

        }
    }

    public bool checkIfEligible(List<Vector2Int> playerInventory)
    {
        int carrotCount = 0;
        int potatoCount = 0;
        int turnipCount = 0;

        foreach (var vege in playerInventory)
        {
            switch (vege.x)
            {
                case 0:
                    carrotCount++;
                    break;
                case 1:
                    potatoCount++;
                    break;
                case 2:
                    turnipCount++;
                    break;
            }
        }

        foreach (var questVege in quest)
        {
            switch (questVege.Key)
            {
                case Vegetable.VegetableType.carrot:
                    if (questVege.Value > carrotCount)
                    {
                        return false;
                    }

                    break;
                case Vegetable.VegetableType.potato:
                    if (questVege.Value > potatoCount)
                    {
                        return false;
                    }

                    break;
                case Vegetable.VegetableType.turnip:
                    if (questVege.Value > potatoCount)
                    {
                        return false;
                    }

                    break;
                default:
                    return false;
            }
        }

        

        return true;
    }

    public string getPower()
    {
        return _power.ToString();
    }
    // private void OnColliderEnter2D(Collider2D other)
    // {
    //     print("this is highlighted");
    // }
}

public enum Power
{
    DoublePoints,
    Teleport,
    ApBoost,
    AdjacentVeggie,
    ReducePull,
    Block,
    PriceBoost,
    None,
    FirstPlayer
}