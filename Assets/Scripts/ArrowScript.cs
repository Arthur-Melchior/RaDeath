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

        switch (pressedKey.name)
        {
            case "s" when position.ToString().ToLower() != "down":
            case "d" when position.ToString().ToLower() != "right":
            case "a" when position.ToString().ToLower() != "left":
            case "w" when position.ToString().ToLower() != "up":
                isCorrect = false;
                break;
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