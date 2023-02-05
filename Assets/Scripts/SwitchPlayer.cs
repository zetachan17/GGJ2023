using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private GameObject player4;
    
    private List<GameObject> players = new List<GameObject>();
    private int playerCount;
    public GameObject activePlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        players.Add(player4);
        activePlayer = player1;
        playerCount = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            Switch();
        }
    }

    public void Switch()
    {
        DisableInput(activePlayer);
        playerCount++;
        switch (playerCount % 4)
        {
            case 0:
                activePlayer = player1;
                break;
            case 1:
                activePlayer = player2;
                break;
            case 2:
                activePlayer = player3;
                break;
            case 3:
                activePlayer = player4;
                break;
        }
            
        Debug.Log("Player " + (playerCount % 4 + 1) + " is active");
        ActiveInput(activePlayer);
    }
    
    private void ActiveInput(GameObject player)
    {
        player.GetComponent<PlayerControls>().enabled = true;
    }
    
    private void DisableInput(GameObject player)
    {
        player.GetComponent<PlayerControls>().enabled = false;
    }
}
