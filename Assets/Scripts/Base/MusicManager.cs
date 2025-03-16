using System;
using System.Collections;
using UnityEngine;

namespace Base
{
    public class MusicManager : MonoBehaviour
    {
        private static MusicManager _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
        
        [SerializeField] private AudioSource alarmAudioSource; // Referencia al AudioSource de la alarma
        [SerializeField] private AudioSource bubbleAudioSource;
        [SerializeField] private float fadeDuration = 3f; // Duración del fade en segundos

        private void OnEnable()
        {
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
        {
            StartCoroutine(FadeOutAlarm());
        }

        private IEnumerator FadeOutAlarm()
        {
            alarmAudioSource.volume = 0.25f;
            alarmAudioSource.Play();

            // Empezamos a atenuar la alarma después de 3 segundos
            yield return new WaitForSeconds(2.25f); 

            float startVolume = alarmAudioSource.volume; // Guardamos el volumen inicial de la alarma

            // Hacemos el fade de la alarma
            float timeElapsed = 0f;
            while (timeElapsed < fadeDuration)
            {
                // Calculamos el volumen en función del tiempo
                alarmAudioSource.volume = Mathf.Lerp(startVolume, 0f, timeElapsed / fadeDuration);

                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // Aseguramos que el volumen quede en 0
            alarmAudioSource.volume = 0f;

            // Detenemos la alarma
            alarmAudioSource.Stop();
        }

        public void BubblePlay()
        {
            bubbleAudioSource.PlayOneShot(bubbleAudioSource.clip);
        }
    }
}

