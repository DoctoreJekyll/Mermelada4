using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base
{
    public class IntroScene : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(LoadScene());
        }

        IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(2f);
            Fade.Instance.PlayFadeIn();
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
