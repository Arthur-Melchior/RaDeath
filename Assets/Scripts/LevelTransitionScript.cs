using UnityEngine;
using UnityEngine.Events;

public class LevelTransitionScript : MonoBehaviour
{
   public UnityEvent onTransitionEnd;
   public void OnTransitionEnd()
   {
      onTransitionEnd?.Invoke();
   }
}
