using System;
using UnityEngine;
using UnityEngine.Events;

public class Level4Script : MonoBehaviour
{
    public float requiredSuccess;
    public float maxFailure;
    public DancerScript dancerScript;
    public UnityEvent onWin;
    public UnityEvent onFail;
    private float _successCount;
    private float _failureCount;
    
    public void OnSuccess(GameObject go)
    {
        _successCount++;
        dancerScript.OnChange();
        Destroy(go);
        if (_successCount > requiredSuccess)
        {
            onWin?.Invoke();
        }
    }

    public void OnFail(GameObject go)
    {
        _failureCount++;
        dancerScript.OnChange();
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
