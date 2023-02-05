using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;

public class UIMenu : MonoBehaviour
{
    public static UIMenu Instance;

    [Header("Player Profile")]
    public TMP_Text[] playerNames;
    public GameObject[] playerAvatars;


    [Header("Inventory")]
    public TMP_Text[] player1CarrotPotatoTurnip;
    public TMP_Text[] player2CarrotPotatoTurnip;
    public TMP_Text[] player3CarrotPotatoTurnip;
    public TMP_Text[] player4CarrotPotatoTurnip;

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
        Instance = this;
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
            turnIndicator.GetComponent<RectTransform>().localPosition = new Vector2(800, 80);
            turnIndicator.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            turnText.text = playerNames[1].text + "'s Turn!";
        }
        if (pos.x > 0 && pos.y > 0)
        {
            turnIndicator.GetComponent<RectTransform>().localPosition = new Vector2(800, -80);
            turnIndicator.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            turnText.text = playerNames[2].text + "'s Turn!";
        }
        if (pos.x > 0 && pos.y < 0)
        {
            turnIndicator.GetComponent<RectTransform>().localPosition = new Vector2(-800, -80);
            turnIndicator.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            turnText.text = playerNames[3].text + "'s Turn!";
        }
        if (pos.x < 0 && pos.y < 0)
        {
            turnIndicator.GetComponent<RectTransform>().localPosition = new Vector2(-800, 80);
            turnIndicator.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            turnText.text = playerNames[0].text + "'s Turn!";
        }
        CallUpdateUI();
    }

    public void CallUpdateUI()
    {



        
        
        //this could be a loop or something less ugly but it's a game jam so whatever

        //set names
        playerNames[0].text = gameinfo.mPlayer1.PlayerName;
        playerNames[1].text = gameinfo.mPlayer2.PlayerName;
        playerNames[2].text = gameinfo.mPlayer3.PlayerName;
        playerNames[3].text = gameinfo.mPlayer4.PlayerName;

        try
        {
            //set avatars
            playerAvatars[0].GetComponent<Image>().sprite = characterAvatars[gameinfo.mPlayer1.ChosenAnimal - 1];
            playerAvatars[1].GetComponent<Image>().sprite = characterAvatars[gameinfo.mPlayer2.ChosenAnimal - 1];
            playerAvatars[2].GetComponent<Image>().sprite = characterAvatars[gameinfo.mPlayer3.ChosenAnimal - 1];
            playerAvatars[3].GetComponent<Image>().sprite = characterAvatars[gameinfo.mPlayer4.ChosenAnimal - 1];
        }
        
        catch (Exception ex)
        {
            Debug.Log("Lazy way to check for 4 players: If this is during the main menu, or you didn't start the game from the main menu, it's fine.");
            return;
        }

        //set inventories
        player1CarrotPotatoTurnip[1].text = "x " + gameinfo.mPlayer1.Vegetables.Count(v => v.getType() == "potato");
        player1CarrotPotatoTurnip[0].text = "x " + gameinfo.mPlayer1.Vegetables.Count(v => v.getType() == "carrot");
        player1CarrotPotatoTurnip[2].text = "x " + gameinfo.mPlayer1.Vegetables.Count(v => v.getType() == "turnip");

        player2CarrotPotatoTurnip[1].text = "x " + gameinfo.mPlayer2.Vegetables.Count(v => v.getType() == "potato");
        player2CarrotPotatoTurnip[0].text = "x " + gameinfo.mPlayer2.Vegetables.Count(v => v.getType() == "carrot");
        player2CarrotPotatoTurnip[2].text = "x " + gameinfo.mPlayer2.Vegetables.Count(v => v.getType() == "turnip");

        player3CarrotPotatoTurnip[1].text = "x " + gameinfo.mPlayer3.Vegetables.Count(v => v.getType() == "potato");
        player3CarrotPotatoTurnip[0].text = "x " + gameinfo.mPlayer3.Vegetables.Count(v => v.getType() == "carrot");
        player3CarrotPotatoTurnip[2].text = "x " + gameinfo.mPlayer3.Vegetables.Count(v => v.getType() == "turnip");

        player4CarrotPotatoTurnip[1].text = "x " + gameinfo.mPlayer4.Vegetables.Count(v => v.getType() == "potato");
        player4CarrotPotatoTurnip[0].text = "x " + gameinfo.mPlayer4.Vegetables.Count(v => v.getType() == "carrot");
        player4CarrotPotatoTurnip[2].text = "x " + gameinfo.mPlayer4.Vegetables.Count(v => v.getType() == "turnip");

        //set scores
        playerScores[0].text = "Score: " + gameinfo.mPlayer1.playerScore;
        playerScores[1].text = "Score: " + gameinfo.mPlayer2.playerScore;
        playerScores[2].text = "Score: " + gameinfo.mPlayer3.playerScore;
        playerScores[3].text = "Score: " + gameinfo.mPlayer4.playerScore;


    }

    // Update is called once per frame
    void Update()
    {

    }
}
