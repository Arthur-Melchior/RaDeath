using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
   [SerializeField] private string inputType;

   public UnityEvent onFail;
   public UnityEvent onSuccess;
   
   public void OnTest(InputAction.CallbackContext ctx)
   {
      if (!ctx.performed) return;

      var pressedKey = Keyboard.current.allKeys.First(key => key.wasPressedThisFrame);
      
      if (pressedKey.name == inputType.Trim().ToLower())
      {
         onSuccess?.Invoke();
      }
      else
      {
         onFail?.Invoke();
      }
   }
    
}
