using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace UI.Menus
{
    /// <summary>
    /// Main menu responsible for most UI screens, except for lobby and room.
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        UIMenu uimenu;
        GameInfo gameinfo;

        [Header("General Settings")] 
        byte maxPlayers = 0;
        
        [Header("Loading Panel")] 
        public GameObject loadingPanel;
        
        [Header("Main Selection Panel")] 
        public GameObject startPanel;

        public GameObject startButton;
        public GameObject instructionsButton;
        public GameObject quitButton;

        [Header("Character Select Panel")]
        public GameObject charSelectPanel;
        public GameObject[] charSelectButtons;
        public TMP_Text[] charNamePlates;
        public TMP_Text characterSelectTooltip;

        [Header("Instruction Panel")]
        public GameObject instructionPanel;
        public GameObject closeInstructionsButton;

        [Header("Info Message Popup")] 
        public GameObject nameEditorPopup;
        public TMP_InputField nameInputField;
        public GameObject closePopupButton;
        
        
        private GameObject _activePanel;

        public GameObject audioManager;

        private int chosenAnimal = 0;
        private int currentPlayer = 1;
        private AudioSource[] audios;

        [Header("Player Manager")]
        [SerializeField]
        private PlayerInfoScriptableObject playerManager;
        public void Awake()
        {
            gameinfo = GameInfo.Instance;
            uimenu = GameObject.Find("UI Menu").GetComponent<UIMenu>();
            SetActivePanel(startPanel);
            audios = audioManager.GetComponents<AudioSource>();
            uimenu.gameObject.SetActive(false);
        }

        public void Update()
        {
            //press enter on name select
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (nameEditorPopup.activeInHierarchy)
                {
                    OnConfirmEditNameClicked();
                }
            }
        }

        #region UI Callbacks

        //when player selects a character. int 1,2,3,4 for the 4 animal choices
        public void OnCharacterSelected(int animal)
        {
            nameEditorPopup.SetActive(true);
            chosenAnimal = animal;
            audios[chosenAnimal-1].Play();
        }

        public void OnConfirmEditNameClicked()
        {
            string newName = nameInputField.text;

            string[] defaultNames = { "WHISKERS", "REX", "BUCKWHEAT", "BIG BERTHA" };

            // If provided name is empty, pick a default name
            if (newName != string.Empty)
            {
                //limit to 10 characters
                if(newName.Length > 10)
                {
                    newName = newName.Substring(0, 10).ToUpper(); 
                }
                else
                {
                    newName = newName.ToUpper();
                }
                
                nameInputField.text = "";
            }
            else
            {
                newName = defaultNames[chosenAnimal-1];
            }

            charNamePlates[chosenAnimal-1].text = newName;
            
            charSelectButtons[chosenAnimal-1].GetComponent<Button>().enabled = false;
            charSelectButtons[chosenAnimal - 1].GetComponent<Image>().color = Color.gray;

            if (!gameinfo)
            {
                gameinfo = GameInfo.Instance;
            }

            switch (currentPlayer)
            {

                case 1:
                    gameinfo.mPlayer1 = new PlayerAttributes(newName, chosenAnimal);
                    break;
                case 2:
                    gameinfo.mPlayer2 = new PlayerAttributes(newName, chosenAnimal);
                    break;
                case 3:
                    gameinfo.mPlayer3 = new PlayerAttributes(newName, chosenAnimal);
                    break;
                case 4:
                    gameinfo.mPlayer4 = new PlayerAttributes(newName, chosenAnimal);
                    break;
            }

            currentPlayer++;
            if(currentPlayer < 5)
            {
                characterSelectTooltip.text = "Player " + currentPlayer + ", decide!";
            }
            else
            {
                characterSelectTooltip.text = "Let's go!";
                uimenu.gameObject.SetActive(true);
                SceneManager.LoadScene("FarmScene");
            }


            //deprecated ScriptableObject
            //playerManager.AddPlayer(newName, chosenAnimal);

            uimenu.CallUpdateUI();
            
            nameEditorPopup.SetActive(false);
        }

        public void OnStartClicked()
        {
            charSelectPanel.SetActive(true);
            startPanel.SetActive(false);
            audios[4].Play();
        }
        

        public void OnQuitButtonClicked()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
        
        #endregion
        
        
        #region Helper Methods
        
        private void SetActivePanel(GameObject panel)
        {
            if(_activePanel != null) _activePanel.SetActive(false);
            
            _activePanel = panel;
            _activePanel.SetActive(true);
        }
        
        #endregion
    }
}