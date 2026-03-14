using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Level1Script : MonoBehaviour
{
    [SerializeField] private Sprite firstSprite;
    [SerializeField] private Sprite secondSprite;
    [SerializeField] private Sprite thirdSprite;
    [SerializeField] private AudioManager manager;
    [SerializeField] private AudioClip punch;
    [SerializeField] private Animator transition;

    private SpriteRenderer _spriteRenderer;
    private int _spriteIndex;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnSuccess()
    {
        _spriteIndex++;
        if (_spriteIndex == 0)
        {
            _spriteRenderer.sprite = secondSprite;
            manager.PlaySound(punch);
        }
        else if (_spriteIndex == 1)
        {
            _spriteRenderer.sprite = thirdSprite;
            manager.PlaySound(punch);
            _spriteIndex = -1;
        }
    }
}