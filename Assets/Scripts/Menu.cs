using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickPlay()
    {
        Debug.Log("METAL!!!");
        SceneManager.LoadScene("Level1");
    }
    public void OnClickExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
            Debug.Log("ByeBye");
        
       
        
    }
}