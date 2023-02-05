using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [Header("Player Profile")]
    public TMP_Text[] playerNames;
    public GameObject playerAvatars;


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

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            /*
            if(playerInfo. > i * 2)
            {
                playerNames[i].text = playerInfo.
            }
            else
            {
                playerNames[i].text = "BUCKWHEAT";
            }
            */
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
