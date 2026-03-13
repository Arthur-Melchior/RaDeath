using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public void OnTransition(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }


    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("LevelComplete");

        var duration = transition.GetCurrentAnimatorStateInfo(0).length;
        
        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene(levelIndex);
    }
}