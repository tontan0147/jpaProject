using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldHandler : MonoBehaviour
{
    public TMP_InputField tmpInputField;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                RectTransform inputRect = tmpInputField.GetComponent<RectTransform>();
                Vector2 touchPos = touch.position;

                if (RectTransformUtility.RectangleContainsScreenPoint(inputRect, touchPos))
                {
                    // Set the TMP_InputField as focused
                    tmpInputField.ActivateInputField();

                    // Show the on-screen keyboard
                    TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
                    Debug.Log("show keyboard");
                }
            }
        }
    }
}
