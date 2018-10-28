using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    [SerializeField] float delayInSeconds = 5f;
    int currentSceneIndex;

    public void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0) StartCoroutine(WaitAndLoadNextScene());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSeconds(delayInSeconds);
        LoadNextScene();
    }
}
