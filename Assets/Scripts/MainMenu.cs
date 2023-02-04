using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI.Menus
{
    /// <summary>
    /// Main menu responsible for most UI screens, except for lobby and room.
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
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

        private int chosenAnimal = 0;
        private int currentPlayer = 1;

        
        public void Awake()
        {
            SetActivePanel(startPanel);
        }

        #region UI Callbacks

        //when player selects a character. int 1,2,3,4 for the 4 animal choices
        public void OnCharacterSelected(int animal)
        {
            nameEditorPopup.SetActive(true);
            chosenAnimal = animal;
        }

        public void OnConfirmEditNameClicked()
        {
            string newName = nameInputField.text;

            string[] defaultNames = { "BUCKWHEAT", "WHISKERS", "REX", "BILLY BOY", "JEB", "FRANCOIS", "BIG BERTHA", "BLITZ" };

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
                newName = defaultNames[Random.Range(0, defaultNames.Length-1)];
            }

            charNamePlates[chosenAnimal-1].text = newName;
            charSelectButtons[chosenAnimal-1].GetComponent<Button>().enabled = false;
            charSelectButtons[chosenAnimal - 1].GetComponent<Image>().color = Color.gray;
            currentPlayer++;
            if(currentPlayer < 5)
            {
                characterSelectTooltip.text = "Player " + currentPlayer + ", decide!";
            }
            else
            {
                characterSelectTooltip.text = "Let's go!";
            }
            

            //TO-DO: SET UP A PLAYER

            
            nameEditorPopup.SetActive(false);
        }

        public void OnStartClicked()
        {
            charSelectPanel.SetActive(true);
            startPanel.SetActive(false);
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