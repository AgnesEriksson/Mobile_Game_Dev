using UnityEngine;

public class AccelerometerController : MonoBehaviour
{
    public static bool useAccelerometer = false;
    private float accelerometerDuration = 5f;
    private float timer = 0f;
    private float moveSpeedMultiplier = 0.5f;
    private float directionX;
    private float directionY;
    public Bounds bound;

    void Update()
    {
        if (useAccelerometer)
        {
            if (timer == 0f)
            {
                AudioManager.Instance.StopBG();
                AudioManager.Instance.PlayRock();
            }
            timer += Time.deltaTime;
            bound.Trigger = false;

            directionX = Input.acceleration.x * moveSpeedMultiplier;
            directionY = Input.acceleration.y * moveSpeedMultiplier;

            if (timer >= accelerometerDuration)
            {
                useAccelerometer = false;
                bound.Trigger = true;
                timer = 0f;
                AudioManager.Instance.StopRock();
                AudioManager.Instance.PlayBG();
            }
        }
    }

    private void FixedUpdate()
    {
        if (useAccelerometer)
        {
            Rigidbody2D[] rigidbodies = FindObjectsOfType<Rigidbody2D>();
            foreach (var rb in rigidbodies)
            {
                Ball ball = rb.GetComponent<Ball>();
                if (ball != null)
                {
                    if (ball.moveAllowed)
                    {
                        rb.velocity = new Vector2(rb.velocity.x + directionX, rb.velocity.y + directionY);
                    }
                }
/*                if (ball.moveAllowed)
                {
                    rb.velocity = new Vector2(rb.velocity.x + directionX, rb.velocity.y + directionY);
                }*/
            }
        }
    }
    public static void ActivateAccelerometer()
    {
        useAccelerometer = true;
    }
}

