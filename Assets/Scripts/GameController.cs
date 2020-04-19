using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Overlay titleScreen;
    public GameOver gameOver;

    public Game game;

    public enum State
    {
        Initializing,
        Title,
        GameOver,
        Playing
    }

    private void Start()
    {
        titleScreen = FindObjectOfType<TitleScreen>();
        gameOver = FindObjectOfType<GameOver>();
        game = FindObjectOfType<Game>();
        Initialize();
    }

    private void Update()
    {
        // TODO: make a better way to start the game that the user can see
        if (Input.GetKeyDown(KeyCode.F1))
        {
            NewGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Initialize();
        }
    }
    
    public void Initialize()
    {
        titleScreen.Activate();
        gameOver.Deactivate();
        game.Initialize();
    }

    public void NewGame()
    {
        titleScreen.Deactivate();
        gameOver.Deactivate();
        game.NewGame();
    }

    public void GameOver(Score score)
    {
        gameOver.Activate();
        gameOver.SetScore(score);
    }
}
