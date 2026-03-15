using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Level3Script : MonoBehaviour
{
    [SerializeField] private InputScript inputScript;
    [SerializeField] private GameObject rightArm;
    [SerializeField] private Image leftFillImage;
    [SerializeField] private Image rightFillImage;
    public UnityEvent onWin;

    private bool _mouseDownWin;
    private bool _mouseUpWin;

    public void OnMouseMove(InputAction.CallbackContext ctx)
    {
        if (inputScript.mouseScore > 1 && !_mouseDownWin)
        {
            rightFillImage.fillAmount = inputScript.mouseScore / inputScript.mouseMoveScore;
        }
        if (inputScript.mouseScore < -1 && !_mouseUpWin)
        {
            leftFillImage.fillAmount = -inputScript.mouseScore / inputScript.mouseMoveScore;
        }

        rightArm.transform.rotation = Quaternion.Euler(0, 0, inputScript.mouseScore * 2);
    }

    public void OnWin()
    {
        if (inputScript.mouseScore > 1)
        {
            _mouseDownWin = true;
            inputScript.inputType = InputType.MouseUp;
            inputScript.mouseScore = 0;
        }
        if (inputScript.mouseScore < -1)
        {
            _mouseUpWin = true;
            inputScript.inputType = InputType.MouseDown;
            inputScript.mouseScore = 0;
        }

        if (_mouseUpWin && _mouseDownWin)
        {
            onWin?.Invoke();
        }
    }
}