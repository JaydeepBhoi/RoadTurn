using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.GamePlay;

    public static GameManager instance;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
       
    }

    public void StateManage(GameState state)
    {
        gameState = state;
    }

    public GameState CurrentState()
    {
        return gameState;
    }
}
public enum GameState
{
    GamePlay,
    Pause,
    GameOver,
    MainScreen,
    UserInput,
    LevelComplete
}
