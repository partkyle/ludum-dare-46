using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOver gameOver;

    private void Start()
    {
        gameOver = FindObjectOfType<GameOver>();
        NewGame();
    }

    private void Update()
    {
        // TODO: make a better way to start the game that the user can see
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("new game started");
            NewGame();
        }
    }

    public void NewGame()
    {
        gameOver.Deactivate();
    }

    public void GameOver()
    {
        gameOver.Activate();
    }
}
