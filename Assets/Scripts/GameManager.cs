using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;
    public static event Action<GameState> onGameStateChange;
    
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }
    
    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                break;
            case GameState.InGame:
                break;
            case GameState.PauseMenu:
                break;
            case GameState.GameOver:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        
        onGameStateChange?.Invoke(newState);
    }
}

public enum GameState
{
    MainMenu,
    InGame,
    PauseMenu,
    GameOver
}
