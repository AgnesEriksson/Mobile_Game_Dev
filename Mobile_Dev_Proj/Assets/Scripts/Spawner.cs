using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] BallPrefabs;
    public Transform spawnPoint;
    public float delay = 1f;
    public float Xmin = -2.5f; //bounds to be fixed to screen and not coords this is temp
    public float Xmax = 2.5f;
    public GameObject currentBall;
    private bool isDropped = false;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
/*        if (currentBall != null && !isDropped)
        {
            HandleTouch();
        }*/

        if (currentBall == null && !isDropped)
        {
            SpawnBall();
        }

    }

    public void SpawnBall()
    {
        int randomSprite = Random.Range(0, BallPrefabs.Length);
        currentBall = Instantiate(BallPrefabs[randomSprite], spawnPoint.position, Quaternion.identity);

        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        if (rb != null){
            rb.gravityScale = 0f;
        }

        /*isDropped = false;*/
    }

/*    void HandleTouch(){
        if (Input.touchCount > 0)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            
            float clampX = Mathf.Clamp(touchPos.x, Xmin, Xmax);

            currentBall.transform.position = new Vector3(clampX, spawnPoint.position.y, 0);
        }

        if (Input.touchCount == 0 && !isDropped)
        {
            DropBall();
        }
    }

    void DropBall()
    {
        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 1f;
        }

        isDropped = true;
    }*/

}
