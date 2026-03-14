using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SurferScript : MonoBehaviour
{
    public UnityEvent onLost;
    private void OnCollisionEnter2D(Collision2D other)
    {
        onLost?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        GetComponent<Animator>().SetTrigger("jump");
    }
}
