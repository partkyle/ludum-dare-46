using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;

    public Game game;
    public bool alive = true;

    public GameObject heldTree;
    public Vector3 heldTreeOffset;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, vertical).normalized;
            gameObject.transform.position += direction * Time.deltaTime * speed;

            if (heldTree != null)
            {
                heldTree.transform.position = transform.position + heldTreeOffset;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            if (heldTree == null)
            {
                game.GameOver();
                alive = false;
            }
            else
            {
                game.FeedTree();
                Destroy(heldTree);
                heldTree = null;
                heldTreeOffset = Vector3.zero;
            }
        }

        if (collision.gameObject.CompareTag("Tree"))
        {
            heldTree = collision.gameObject;
            heldTreeOffset = collision.gameObject.transform.position - transform.position;
        }
    }
}
