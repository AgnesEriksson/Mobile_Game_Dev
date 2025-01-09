using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public ScoreManager scoreManager;
    public bool Trigger;
    private Collider2D coll;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        Trigger = true;
        coll = GetComponent <Collider2D>();
        sprite = GetComponent <SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Trigger)
        {
            coll.isTrigger = false;
            sprite.enabled = true;
        }
        else
        {
            coll.isTrigger = true;
            sprite.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if (rb.velocity.y > 0)
            {
                Debug.Log($"{other.name} passed through from below.");
                GameManager.Instance.GameOver();
            }
        }
    }

    private IEnumerator endGameWait()
    {
        yield return new WaitForSeconds(3f);

    }
}
