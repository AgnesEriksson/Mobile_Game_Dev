using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isDropped = false;    // To track if the ball has been dropped
    private bool hasCollided = false;  // To track if the ball has already collided
    private Vector3 offset;
    private float zCoord;
    private Camera cachedCamera;
    public float smoothSpeed = 10f;
    private float minX = -8f;  // Minimum X boundary (adjust to your screen width)
    private float maxX = 8f;   // Maximum X boundary (adjust to your screen width)
    private Spawner ballSpawner;  // Reference to the spawner


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDropped)
        {
            HandleTouch();
        }
    }

    void HandleTouch()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    zCoord = cachedCamera.WorldToScreenPoint(gameObject.transform.position).z;
                    offset = gameObject.transform.position - GetTouchWorldPosition(touch.position);
                    break;

                case TouchPhase.Moved:
                    Vector3 targetPosition = GetTouchWorldPosition(touch.position) + offset;
                    transform.position = new Vector2(Mathf.Clamp(targetPosition.x, minX, maxX), transform.position.y);
                    break;

                case TouchPhase.Ended:
                    DropBall();
                    break;
            }
        }
    }

    private Vector3 GetTouchWorldPosition(Vector2 touchPosition)
    {
        Vector3 touchPoint = new Vector3(touchPosition.x, touchPosition.y, zCoord);
        return cachedCamera.ScreenToWorldPoint(touchPoint);
    }

    void DropBall()
    {
        if (rb != null)
        {
            rb.gravityScale = 1f;  
            isDropped = true;      

            if (ballSpawner != null)
            {
                ballSpawner.SpawnBall();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasCollided)
        {
            hasCollided = true;

            Spawner ballSpawner = FindObjectOfType<Spawner>();
            if (ballSpawner != null)
            {
                ballSpawner.SpawnBall();
            }
        }
    }
}
