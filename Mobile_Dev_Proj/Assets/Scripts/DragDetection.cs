using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragDetection : MonoBehaviour
{
    private InputManager inputManager;
    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;
    private float directionThreshold = 0.9f; //must stay between 0 and 1

    [SerializeField]
    private UnityEvent<Vector2> DragEndEvent = new UnityEvent<Vector2>();

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += DragStart;
        inputManager.OnEndTouch += DragEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= DragStart;
        inputManager.OnEndTouch -= DragEnd;
    }

    private void DragStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }

    private void DragEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectDrag();
        DragEndEvent?.Invoke(endPosition);
    }

    private void DetectDrag()
    {
        Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
        Vector3 direction = endPosition - startPosition;
        Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
        DragDirection(direction2D);
    }

    private void DragDirection(Vector2 direction)
    {
        /*      if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
              {

              }       
              if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
              {

              }  */
        if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            Debug.Log("Left");
        }
        if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            Debug.Log("Right");
        }
    }
}
