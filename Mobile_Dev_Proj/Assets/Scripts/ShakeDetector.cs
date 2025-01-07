using UnityEngine;

public class ShakeDetector : MonoBehaviour
{
    public static bool shakingEnabled = false; // Controls whether shaking detection is active
    public float shakeThreshold = 2.0f;       // Threshold for shake detection
    private float shakeDuration = 3f;         // Duration for which shake detection remains active
    private float timer = 0f;                 // Timer to track shake duration

    void Update()
    {
        if (shakingEnabled)
        {
            // Increment the timer
            timer += Time.deltaTime;

            // Check for shaking
            Vector3 acceleration = Input.acceleration;
            if (acceleration.sqrMagnitude > shakeThreshold * shakeThreshold)
            {
                Debug.Log("Shake detected!");
                // Add your custom shake logic here
            }

            // Disable shaking detection after the duration
            if (timer >= shakeDuration)
            {
                shakingEnabled = false;
                timer = 0f; // Reset timer for the next activation
                Debug.Log("Shake detection turned off.");
            }
        }
    }

    // Method to enable shake detection and reset the timer if already active
    public static void EnableShakeDetection()
    {
        shakingEnabled = true;
        Debug.Log("Shake detection enabled or timer reset.");

        // Reset the timer
        ShakeDetector instance = FindObjectOfType<ShakeDetector>();
        if (instance != null)
        {
            instance.timer = 0f; // Reset the timer to restart the countdown
        }
    }
}

