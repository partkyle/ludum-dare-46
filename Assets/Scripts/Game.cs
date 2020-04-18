using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject gameUi;
    public Timer timer;
    public GameController controller;

    public float currentTime;

    public bool playing = false;

    public float maxTime = 5;

    void Start()
    {
        gameUi = FindObjectOfType<GameUI>().gameObject;
        timer = FindObjectOfType<Timer>();
        controller = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (playing)
        {
            currentTime -= Time.deltaTime;
            timer.current = currentTime;

            if (currentTime <= 0)
            {
                GameOver();
            }
        }
    }

    public void NewGame()
    {
        gameUi.SetActive(true);

        timer.total = maxTime;
        currentTime = maxTime;

        playing = true;
    }

    public void Initialize()
    {
        gameUi.SetActive(false);
        playing = false;
    }

    public void GameOver()
    {
        Initialize();
        controller.GameOver();
    }
}
