using System;
using UnityEngine;
using UnityEngine.Events;

public class WInScript : MonoBehaviour
{
   public UnityEvent onWin;
   public void OnWin()
   {
      Debug.Log("won");
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      onWin?.Invoke();
   }
}
