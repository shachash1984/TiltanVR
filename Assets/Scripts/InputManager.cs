using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour {

    public static InputManager S;
    public PlayerControl _player;
    public TextMeshPro logText;
    string[] _joystickNames;
    bool currentTouchDetected;
    float timer;
    float maxDelay = 0.2f;

    public delegate void TouchAction();

    public event TouchAction OnTouchBeganEvent;
    public event TouchAction OnSingleTapEvent;
    public event TouchAction OnLongTouchEvent;
    public event TouchAction OnTouchEndedEvent;

    public delegate void JoystickAxisAction(float x, float y);
    public event JoystickAxisAction OnJoystickAxisInputEvent;

    public delegate void JoystickTriggerButton();
    public event JoystickTriggerButton OnJoystickTriggerInput;

    public enum InputType
    {
        Touch,
        Joystick
    }
    [SerializeField] private InputType _inputType;

    private void Awake()
    {
        if (S != null)
            Destroy(gameObject);
        S = this;
        _player = FindObjectOfType<PlayerControl>();
        //_joystickNames = Input.GetJoystickNames();
        //logText = GetComponentInChildren<TextMeshPro>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    _player.canWalk = !_player.canWalk;
        //}
        GetInput();

    }

    void GetInput()
    {
        if (_inputType == InputType.Joystick)
            GetJoystickInput();
        else
            GetTouchInput();
    }

    void GetTouchInput()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            TouchPhase phase = touch.phase;

            switch (phase)
            {
                case TouchPhase.Began:
                    if (OnTouchBeganEvent != null)
                        OnTouchBeganEvent();
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if(!currentTouchDetected)
                    {
                        timer += Time.deltaTime;
                        if(timer >= maxDelay)
                        {
                            if (OnLongTouchEvent != null)
                                OnLongTouchEvent();
                            currentTouchDetected = true;
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    if (OnTouchEndedEvent != null)
                        OnTouchEndedEvent();
                    if(timer < maxDelay)
                    {
                        if (OnSingleTapEvent != null)
                            OnSingleTapEvent();
                    }

                    timer = 0;
                    currentTouchDetected = false;
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    break;
            }
        }
    }

    void GetJoystickInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if(h != 0 || v != 0)
        {
            if (OnJoystickAxisInputEvent != null)
                OnJoystickAxisInputEvent(h, v);
        }
        if(Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (OnJoystickTriggerInput != null)
                OnJoystickTriggerInput();
        }
        
    }

    public void SetInputType(InputType t)
    {
        _inputType = t;
    }
}
