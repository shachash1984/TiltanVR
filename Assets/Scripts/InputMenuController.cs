using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputMenuController : MonoBehaviour
{

    [SerializeField] private Button _touchButton;
    [SerializeField] private Button _joystickButton;

    private void OnEnable()
    {
        _touchButton.onClick.AddListener(() =>
        {
            InputManager.S.SetInputType(InputManager.InputType.Touch);
            SceneManager.LoadScene(1);
        });
        _joystickButton.onClick.AddListener(() =>
        {
            InputManager.S.SetInputType(InputManager.InputType.Joystick);
            SceneManager.LoadScene(1);
        });
    }

    private void OnDisable()
    {
        _touchButton.onClick.RemoveAllListeners();
        _joystickButton.onClick.RemoveAllListeners();
    }
}
