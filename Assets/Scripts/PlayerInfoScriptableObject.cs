using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "Scriptable/PlayerInfo")]
public class PlayerInfoScriptableObject : ScriptableObject
{
    [SerializeField]
    private List<string> playerAttributesList;

    [System.NonSerialized]
    public UnityEvent<GameObject> addPlayerEvent;

    private void OnEnable()
    {
        playerAttributesList = new List<string>();
    }
    
    public void AddPlayer(string newName, int choseAnimal)
    {
        //GameObject playerObject = new GameObject(newName);
        //PlayerAttributes player = playerObject.AddComponent<PlayerAttributes>();
        //player.PlayerName = newName;
        //player.ChosenAnimal = choseAnimal;
        
        playerAttributesList.Add(newName);
        playerAttributesList.Add(choseAnimal.ToString());
    }
    
    public string getStringFromIndex(int i)
    {
        return playerAttributesList[i];
    } 
}



