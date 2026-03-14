using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public enum InputType
{
    W,
    D,
    S,
    A,
    Space,
    MouseDown,
    MouseUp,
    Click,
}

public class InputScript : MonoBehaviour
{
    public UnityEvent onFail;
    public UnityEvent onWin;
    [SerializeField] private InputType inputType;
    [SerializeField] private float allowedTime;
    [SerializeField] private float numberOfClicks;
    private Vector2 _previousMousePosition;
    private float _mouseScore;
    private float _elapsedTime;
    private string _previousClick;
    private float _clickScore;

    private void Update()
    {
        if (_elapsedTime > allowedTime)
        {
            onFail?.Invoke();
        }

        _elapsedTime += Time.deltaTime;
    }


    public void OnKeyDown(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        var pressedKey = Keyboard.current.allKeys.First(key => key.wasPressedThisFrame);

        if (pressedKey.name == SolveInput())
        {
            onWin?.Invoke();
        }
        else
        {
            onFail?.Invoke();
        }
    }

    private string SolveInput()
    {
        switch (inputType)
        {
            case InputType.W:
                return "w";
            case InputType.D:
                return "d";
            case InputType.S:
                return "s";
            case InputType.A:
                return "a";
            case InputType.Space:
                return "space";
            default:
                return "";
        }
    }

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        if (inputType != InputType.Click)
        {
            onFail?.Invoke();
            return;
        }
        
        var clickName = ctx.control.displayName;
        
        if (clickName == "" || clickName != _previousClick)
        {
            _clickScore++;
            if (_clickScore >= numberOfClicks)
            {
                onWin?.Invoke();
            }
        }

        _previousClick = clickName;
        Debug.Log(_previousClick);
        Debug.Log(_clickScore);
    }

    public void OnMouseMove(InputAction.CallbackContext ctx)
    {
        var mousePositon = ctx.ReadValue<Vector2>();
        var difference = _previousMousePosition - mousePositon;
        _mouseScore += difference.y;
        Debug.Log(_mouseScore);
        _previousMousePosition = mousePositon;
        if (inputType == InputType.MouseUp)
        {
            if (_mouseScore < -500)
            {
                onWin?.Invoke();
            }
        }
        else if (inputType == InputType.MouseDown)
        {
            if (_mouseScore > 500)
            {
                onWin?.Invoke();
            }
        }
    }
}