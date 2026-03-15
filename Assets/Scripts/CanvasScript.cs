using System;
using TMPro;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public Score score;
    public TMP_Text text;

    private void Start()
    {
        text.text = score.score.ToString();
    }
}
