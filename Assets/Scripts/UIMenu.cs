using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [Header("Player Profile")]
    public TMP_Text[] playerNames;
    public GameObject[] playerAvatars;


    [Header("Inventory")]
    public TMP_Text[] player1CarrotPotatoTurnip;
    public TMP_Text[] player2CarrotPotatoTurnip;
    public TMP_Text[] player3CarrotPotatoTurnip;

    [Header("Score")]
    public TMP_Text[] playerScores;

    [Header("Pause Popup")]
    public GameObject infoMessagePopup;
    public GameObject closePopupButton;
    public GameObject quitButton;

    [SerializeField]
    private PlayerInfoScriptableObject playerInfo;
    public Sprite[] characterAvatars;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            try
            {
                playerNames[i].text = playerInfo.getStringFromIndex(i * 2);
                playerAvatars[i].GetComponent<Image>().sprite = characterAvatars[Convert.ToInt32(playerInfo.getStringFromIndex(i * 2+1))-1];
            }
            catch(Exception ex)
            {
                Debug.Log("Player Scriptable Object Not Set Up!!");
            } 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
