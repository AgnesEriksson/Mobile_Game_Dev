using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Drag : MonoBehaviour
{
    private bool isDragging = false;
    public Spawner Spawn;
    public Camera cam;
    public bool drop;

    void Update()
    {
        if (GameManager.Instance.playing)
        {
            {

            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Vector3 touchPosition = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));

                if (touch.phase == TouchPhase.Began)
                {
                    isDragging = true;
                    transform.position = new Vector3(Mathf.Clamp(touchPosition.x, -1.8f, 1.8f), transform.position.y, transform.position.z);
                }
                else if (touch.phase == TouchPhase.Moved && isDragging)
                {
                    transform.position = new Vector3(Mathf.Clamp(touchPosition.x, -1.8f, 1.8f), transform.position.y, transform.position.z);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    isDragging = false;
                    if (Spawn.currentBall != null)
                    {
                        Spawn.DropCurrent();
                    }
                }
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
                transform.position = new Vector3(Mathf.Clamp(mousePosition.x, -1.8f, 1.8f), transform.position.y, transform.position.z);
            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    if (Spawn.currentBall != null)
                    {
                        drop = true;
                    }
                }
            }
        }
    }
}