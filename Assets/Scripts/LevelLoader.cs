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

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int randomIndex;

        do
        {
            randomIndex = Random.Range(1, 5);
        } while (randomIndex == currentSceneIndex);

        StartCoroutine(LoadLevel(randomIndex));
    }


    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("LevelComplete");

        var duration = transition.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene(levelIndex);
    }
}