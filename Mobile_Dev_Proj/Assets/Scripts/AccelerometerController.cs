using UnityEngine;

public class AccelerometerController : MonoBehaviour
{
    public static bool useAccelerometer = false; // Control whether accelerometer input is active
    private float accelerometerDuration = 10f;    // Duration for accelerometer input
    private float timer = 0f;                    // Timer to track the duration
    private float moveSpeedMultiplier = 0.5f;
    private float directionX;
    private float directionY;
    public Bounds bound;

    void Update()
    {
        // If accelerometer input is enabled, apply the input to the rigidbodies
        if (useAccelerometer)
        {
            timer += Time.deltaTime;
            bound.Trigger = false;

            // Read accelerometer input
/*            Vector3 tilt = Input.acceleration;
            Vector2 movement = new Vector2(tilt.x, tilt.y);*/
            directionX = Input.acceleration.x * moveSpeedMultiplier;
            directionY = Input.acceleration.y * moveSpeedMultiplier;

            // Apply force to all rigidbodies in the scene


            // Disable accelerometer after the duration is reached
            if (timer >= accelerometerDuration)
            {
                useAccelerometer = false;
                bound.Trigger = true;
                timer = 0f; // Reset the timer for next activation
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
                if (ball.moveAllowed)
                {
                    rb.velocity = new Vector2(rb.velocity.x + directionX, rb.velocity.y + directionY);
                }
            }
        }
    }

    // Static method to activate the accelerometer for a set duration
    public static void ActivateAccelerometer()
    {
        useAccelerometer = true;
    }
}

