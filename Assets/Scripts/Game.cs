using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject gameUi;
    public Timer timer;
    public GameController controller;

    public GameObject floorPrefab;
    public GameObject playerPrefab;
    public GameObject firePrefab;
    public GameObject treePrefab;

    public GameObject container;
    public GameObject currentPlayer;

    public float currentTime;

    public bool playing = false;

    public float maxTime = 5;
    public float numTrees = 100;

    public Rect treeRect;
    public Rect forbiddenRect;

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
        Setup();
    }

    public void Initialize()
    {
        Stop();
    }

    public void Setup()
    {
        if (container != null)
        {
            Destroy(container);
        }

        container = new GameObject("Container");
        container.transform.parent = transform;

        Instantiate(floorPrefab, container.transform);
        Instantiate(playerPrefab, container.transform);
        Instantiate(firePrefab, container.transform);

        SpawnTrees();
    }

    public void SpawnTrees()
    {
        for (int i=0; i< numTrees; i++)
        {
            GameObject tree = Instantiate(treePrefab, container.transform);

            // take advantage of the fact that 0,0 is where the fire is, and we don't
            // want any trees in the fire because that's too easy.
            Vector3 location = Vector3.zero;
            while (forbiddenRect.Contains(location))
            {
                location = new Vector3(Random.Range(treeRect.x, treeRect.width), Random.Range(treeRect.y, treeRect.height), 0);
            }

            tree.transform.position = location;
        }
    }

    public void Stop()
    {
        gameUi.SetActive(false);
        playing = false;
    }

    public void GameOver()
    {
        Stop();
        controller.GameOver();

    }
}
