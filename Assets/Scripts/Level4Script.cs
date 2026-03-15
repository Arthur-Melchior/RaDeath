using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level4Script : MonoBehaviour
{
    public float requiredSuccess;
    public float maxFailure;
    public UnityEvent onWin;
    public UnityEvent onFail;
    private float _successCount;
    private float _failureCount;
    public Score score;

    public List<Sprite> sprites;
    public SpriteRenderer spriteRenderer;

    private int index = 0;

    public void OnChange()
    {
        index = (index + 1) % sprites.Count;
        spriteRenderer.sprite = sprites[index];
    }
    
    public void OnSuccess(GameObject go)
    {
        _successCount++;
        OnChange();
        Destroy(go);
        if (_successCount > requiredSuccess)
        {
            onWin?.Invoke();
        }
    }

    private void Start()
    {
        requiredSuccess += MathF.Round(score.score / 10f);
    }

    public void OnFail(GameObject go)
    {
        _failureCount++;
        OnChange();
        Destroy(go);
        if (_failureCount > maxFailure)
        {
            onFail?.Invoke();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var script = other.GetComponent<ArrowScript>();
        script.isCorrect = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        var script = other.GetComponent<ArrowScript>();
        script.isCorrect = false;
    }
}
