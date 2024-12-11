using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] BallPrefabs;
    public GameObject[] MatchedBallPrefabs;
    public Transform spawnPoint;
    public GameObject currentBall;
    private float minX = -4f;  // temp bounds will be replaced with proper screen space logic
    private float maxX = 4f;
    private Vector3 matchPos = new Vector3();
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
 /*       spawnPoint.position = new Vector3(Mathf.Clamp(matchPos.x, minX, maxX), spawnPoint.position.y, -1);*/

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

/*    public void MoveSpawnPoint(Vector2 touchPosition)
    {
        Vector3 worldTouchPos = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 0));
        spawnPoint.position = new Vector3(Mathf.Clamp(worldTouchPos.x, minX, maxX), spawnPoint.position.y, -1);
    }*/

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
        currentBall = Instantiate(BallPrefabs[randomSprite], new Vector3(spawnPoint.position.x, spawnPoint.position.y,-1), Quaternion.identity);

        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
        }

    }
/*    public void OnDragFinish(Vector2 pos)
    {
        matchPos = pos;
        Debug.Log("pos");
    }*/
}
