using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private ScoreManager scoreManager;
    private SceneSwitcher sceneSwitcher;
    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if (rb.velocity.y > 0)
            {
                Debug.Log($"{other.name} passed through from below.");
                scoreManager.CheckHighScore();
                sceneSwitcher.LoadNextScene();
                
            }
        }
    }

    private IEnumerator endGameWait()
    {
        yield return new WaitForSeconds(3f);

    }
}
