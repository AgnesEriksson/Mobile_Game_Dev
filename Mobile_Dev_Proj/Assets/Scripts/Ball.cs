using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Spawner ballSpawner = FindObjectOfType<Spawner>();
        if (ballSpawner != null)
        {
            ballSpawner.SpawnBall();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
