using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] BallPrefabs;
    public GameObject[] MatchedBallPrefabs;
    public Transform Chicken;
    public Transform SpawnPoint;
    public GameObject currentBall;
    static public Vector3 newBallSpawnPos;
    static public bool newBall = false;
    static public int whatBall = 0;
    public Drag drag;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        ReplaceBall();
        //transform.position = new Vector3(Chicken.position.x, Chicken.position.y, -1);

        if (drag.drop)
        {
            drag.drop = false;
            DropCurrent();
        }
    }
    public void Drop()
    {
        DropCurrent();
    }
    public void DropCurrent()
    {
        if (currentBall != null)
        {
            currentBall.GetComponent<Ball>().DropBall();
            currentBall = null;
        }
        SpawnBall();
    }
    public void SpawnBall()
    {
        if (currentBall == null) {
            StartCoroutine(nameof(delay));
        }

    }

    void ReplaceBall()
    {
        if (newBall)
        {
            newBall = false;
            Debug.Log(newBallSpawnPos);
            Instantiate(MatchedBallPrefabs[(whatBall+1)%MatchedBallPrefabs.Length], newBallSpawnPos, Quaternion.identity);
        }
    }

    private IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        int randomSprite = Random.Range(0, BallPrefabs.Length);
        currentBall = Instantiate(BallPrefabs[randomSprite], new Vector3(SpawnPoint.position.x, SpawnPoint.position.y-1,-1), Quaternion.identity);

        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
        }

    }
}
