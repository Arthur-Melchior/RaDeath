using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

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
    public UnityEvent correctAction;
    public float mouseScore;
    public InputType inputType;
    [SerializeField] private float allowedTime;
    [SerializeField] private float numberOfClicks;
    public float mouseMoveScore;
    private Vector2 _previousMousePosition;
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
            Destroy(this);
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
            _previousClick = clickName;
            correctAction?.Invoke();
            if (_clickScore >= numberOfClicks)
            {
                onWin?.Invoke();
                Destroy(this);
            }
        }

        Debug.Log(_previousClick);
        Debug.Log(_clickScore);
    }

    public void OnMouseMove(InputAction.CallbackContext ctx)
    {
        var mouseDelta = Mouse.current.delta.ReadValue();

        mouseScore += mouseDelta.y;


        if (mouseScore > mouseMoveScore)
        {
            onWin?.Invoke();
        }

        if (mouseScore < -mouseMoveScore)
        {
            onWin?.Invoke();
        }

        Debug.Log(mouseScore);
    }
}