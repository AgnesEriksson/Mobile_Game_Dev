using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{

    public static InputManager Instance = null;

    #region Events 
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    #endregion

    private PlayerController controller;
    private Camera mainCam;
    private void Awake()
    {
        controller = new PlayerController();
        mainCam = Camera.main;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void OnDropTap()
    {
        Debug.Log("yup");
    }

    private void OnEnable()
    {
        controller.Enable();
    }

    private void OnDisable()
    {
        controller.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        controller.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnEndTouch(Utils.ScreenToWorld(mainCam, controller.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnStartTouch(Utils.ScreenToWorld(mainCam, controller.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }

    public Vector2 PrimaryPosition()
    {
        return Utils.ScreenToWorld(mainCam, controller.Touch.PrimaryPosition.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
