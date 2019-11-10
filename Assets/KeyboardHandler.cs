using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardHandler : MonoBehaviour
{
    [SerializeField] private Text _inputField;

    

    private void Awake()
    {
        _inputField.text = "";
        _inputField.color = Color.black;
        _inputField = transform.parent.GetChild(0).GetComponentInChildren<Text>();
        foreach (Transform tr in transform)
        {
            Button b = tr.GetComponent<Button>();
            if (b)
            {
                string str = b.name;
                b.onClick.RemoveAllListeners();
                b.onClick.AddListener(() =>
                {
                    switch (b.name)
                    {
                        case "Backspace":
                            string temp = _inputField.text.Substring(0, _inputField.text.Length - 1);
                            _inputField.text = temp;
                            break;
                        case "Enter":
                            Debug.Log("<color=yellow>" + _inputField.text + "</color>");
                            _inputField.text = "";
                            break;
                        case "Space":
                            _inputField.text += " ";
                            break;
                        default:
                            _inputField.text += str;
                            break;
                    }

                });
            }
        }
    }

    
}
