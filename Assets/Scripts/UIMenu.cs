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

    [Header("Indicators")]
    public Image turnIndicator;
    public TMP_Text turnText;

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
                Debug.Log("Player Scriptable Object Not Set Up! If you started the game from somewhere other than the main menu this is fine. Otherwise, oh fuck!");
            } 
        }
    }

    public void NextTurn()
    {
        Vector2 pos = turnIndicator.GetComponent<RectTransform>().localPosition;
        if(pos.x < 0 && pos.y > 0)
        {
            turnIndicator.GetComponent<RectTransform>().localPosition = new Vector2(-800, -80);
            turnIndicator.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            turnText.text = playerNames[1].text + "'s Turn!";
        }
        if (pos.x < 0 && pos.y < 0)
        {
            turnIndicator.GetComponent<RectTransform>().localPosition = new Vector2(800, 80);
            turnIndicator.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            turnText.text = playerNames[2].text + "'s Turn!";
        }
        if (pos.x > 0 && pos.y > 0)
        {
            turnIndicator.GetComponent<RectTransform>().localPosition = new Vector2(800, -80);
            turnIndicator.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            turnText.text = playerNames[3].text + "'s Turn!";
        }
        if (pos.x > 0 && pos.y < 0)
        {
            turnIndicator.GetComponent<RectTransform>().localPosition = new Vector2(-800, 80);
            turnIndicator.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            turnText.text = playerNames[0].text + "'s Turn!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
