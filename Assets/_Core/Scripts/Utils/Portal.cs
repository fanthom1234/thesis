using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneName;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(loadScene());
        }
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
