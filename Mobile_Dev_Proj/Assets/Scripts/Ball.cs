using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isDropped = false;
    private bool hasCollided = false; 
    private Spawner ballSpawner;
    public string id = "0";


    private Vector2 touchPos;
    public Vector2 midpoint;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        ballSpawner = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDropped && ballSpawner != null)
        {
            transform.position = new Vector2(ballSpawner.transform.position.x, ballSpawner.transform.position.y);
        }
    }

    public void DropBall()
    {
        if (rb != null)
        {
            rb.gravityScale = 1f;  
            isDropped = true;
        }
        /*ballSpawner.SpawnBall();*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
/*        if (!hasCollided)
        {
            hasCollided = true;

            Spawner ballSpawner = FindObjectOfType<Spawner>();
            if (ballSpawner != null)
            {
                ballSpawner.SpawnBall();
            }
        }*/
 
        if(collision.gameObject.tag == gameObject.tag)
        {
            midpoint = (transform.position + collision.transform.position) / 2;
            Debug.Log(midpoint);
            Spawner.newBallSpawnPos = midpoint;
            Spawner.newBall = "y";
            Spawner.whatBall = int.Parse(gameObject.tag);
            Destroy(gameObject);
        }
    }
}
