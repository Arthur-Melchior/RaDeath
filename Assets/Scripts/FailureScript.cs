using UnityEngine;
using UnityEngine.SceneManagement;

public class FailureScript : MonoBehaviour
{
    public void OnFail()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Failure");
    }
}
