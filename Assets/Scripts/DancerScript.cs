using System;
using UnityEngine;

public class DancerScript : MonoBehaviour
{
   public Sprite sprite1;
   public Sprite sprite2;
   public Sprite sprite3;
   public Sprite sprite4;
   private SpriteRenderer _spriteRenderer;

   private void Start()
   {
      _spriteRenderer = GetComponent<SpriteRenderer>();
   }

   public void OnChange()
   {
      if (_spriteRenderer.sprite.name == sprite1.name)
      {
         _spriteRenderer.sprite = sprite2;
      }
      if (_spriteRenderer.sprite.name == sprite2.name)
      {
         _spriteRenderer.sprite = sprite3;
      }
      if (_spriteRenderer.sprite.name == sprite3.name)
      {
         _spriteRenderer.sprite = sprite4;
      }
      if (_spriteRenderer.sprite.name == sprite4.name)
      {
         _spriteRenderer.sprite = sprite1;
      }
   }
}
