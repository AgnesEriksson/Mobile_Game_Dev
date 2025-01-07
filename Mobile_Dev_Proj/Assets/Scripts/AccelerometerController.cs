using UnityEngine;

public class AccelerometerController : MonoBehaviour
{
    public static bool useAccelerometer = false; // Control whether accelerometer input is active
    private float accelerometerDuration = 10f;    // Duration for accelerometer input
    private float timer = 0f;                    // Timer to track the duration

    void Update()
    {
        // If accelerometer input is enabled, apply the input to the rigidbodies
        if (useAccelerometer)
        {
            timer += Time.deltaTime;

            // Read accelerometer input
            Vector3 tilt = Input.acceleration;
            Vector2 movement = new Vector2(tilt.x, tilt.y);

            // Apply force to all rigidbodies in the scene
            Rigidbody2D[] rigidbodies = FindObjectsOfType<Rigidbody2D>();
            foreach (var rb in rigidbodies)
            {
                rb.AddForce(movement * 5f); // Adjust force multiplier as needed
            }

            // Disable accelerometer after the duration is reached
            if (timer >= accelerometerDuration)
            {
                useAccelerometer = false;
                timer = 0f; // Reset the timer for next activation
            }
        }
    }

    // Static method to activate the accelerometer for a set duration
    public static void ActivateAccelerometer()
    {
        useAccelerometer = true;
    }
}

