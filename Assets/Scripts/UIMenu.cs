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
    //deprecated player scriptable object
    //private PlayerInfoScriptableObject playerInfo;

    GameInfo gameinfo;
    public Sprite[] characterAvatars;

    private void Awake()
    {
        gameinfo = GameInfo.Instance;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

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

    public void CallUpdateUI()
    {
        //this could be a loop or something less ugly but it's a game jam so whatever

        //set names
        playerNames[0].text = gameinfo.mPlayer1.PlayerName;
        playerNames[1].text = gameinfo.mPlayer2.PlayerName;
        playerNames[2].text = gameinfo.mPlayer3.PlayerName;
        playerNames[3].text = gameinfo.mPlayer4.PlayerName;

        //set avatars
        playerAvatars[0].GetComponent<Image>().sprite = characterAvatars[gameinfo.mPlayer1.ChosenAnimal - 1];
        playerAvatars[1].GetComponent<Image>().sprite = characterAvatars[gameinfo.mPlayer2.ChosenAnimal - 1];
        playerAvatars[2].GetComponent<Image>().sprite = characterAvatars[gameinfo.mPlayer3.ChosenAnimal - 1];
        playerAvatars[3].GetComponent<Image>().sprite = characterAvatars[gameinfo.mPlayer4.ChosenAnimal - 1];

    }

    // Update is called once per frame
    void Update()
    {

    }
}
