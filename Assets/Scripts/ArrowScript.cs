using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ArrowScript : MonoBehaviour
{
    public bool isCorrect;
    public Position position;
    public UnityEvent<GameObject> onSuccess;
    public UnityEvent<GameObject> onFail;

    public void OnKeyDown(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        var pressedKey = Keyboard.current.allKeys.First(key => key.wasPressedThisFrame);

        if (pressedKey.name == "s" && position.ToString().ToLower() != "down")
        {
            isCorrect = false;
        }
        if (pressedKey.name == "d" && position.ToString().ToLower() != "right")
        {
            isCorrect = false;
        }
        if (pressedKey.name == "a" && position.ToString().ToLower() != "left")
        {
            isCorrect = false;
        }
        if (pressedKey.name == "w" && position.ToString().ToLower() != "up")
        {
            isCorrect = false;
        }

        if (isCorrect)
        {
            onSuccess?.Invoke(gameObject);
        }
        else
        {
            onFail?.Invoke(gameObject);
        }
    }
}