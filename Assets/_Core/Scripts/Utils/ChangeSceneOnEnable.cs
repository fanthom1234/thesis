using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnEnable : MonoBehaviour
{
    public string sceneName;

    private void OnEnable()
    {
        StartCoroutine(loadScene());
    }

    public void ChangeScene()
    {
        StartCoroutine(loadScene());
    }

    private IEnumerator loadScene()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(sceneName);
    }
}
