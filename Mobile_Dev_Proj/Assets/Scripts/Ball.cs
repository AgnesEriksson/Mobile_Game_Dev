using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isDropped = false;
    private Spawner ballSpawner;
    public Transform spawnPoint;
    private AccelerometerController acc;
    public string id = "0";
    public Vector3 mergepoint;
    public bool moveAllowed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        GetComponent<CircleCollider2D>().enabled = false;
        ballSpawner = FindObjectOfType<Spawner>();
        //spawnPoint = GetComponent<GameObject>();
        if (transform.position.y < 1.2)
        {
            isDropped = true;
            if (rb != null)
            {
                moveAllowed = true;
                rb.gravityScale = 1f;
                GetComponent<CircleCollider2D>().enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDropped && ballSpawner != null)
        {
            transform.position = new Vector3(ballSpawner.transform.position.x, ballSpawner.transform.position.y-1, 0);
            moveAllowed = false;
        }
    }

    public void DropBall()
    {
        if (rb != null)
        {

            rb.gravityScale = 1f;  
            isDropped = true;
            GetComponent<CircleCollider2D>().enabled = true;
            moveAllowed = true;
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
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            mergepoint = gameObject.transform.position;
            Destroy(gameObject);
            ScoreManager.score += int.Parse(gameObject.tag);
            Debug.Log(mergepoint);
            Spawner.newBallSpawnPos = mergepoint;
            Spawner.newBall = true;
            Spawner.whatBall = int.Parse(gameObject.tag);

            if (gameObject.tag == "5")
            {
                Debug.Log("scramble time");
                AccelerometerController.ActivateAccelerometer();
            }
            
        }
    }
}
