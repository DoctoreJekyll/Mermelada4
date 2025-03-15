

using UnityEngine;

namespace Base
{
    public class MusicManager : MonoBehaviour
    {
        public static MusicManager Instance;  // Instancia única del MusicManager

        [Header("Audio Sources")]
        public AudioSource musicAudioSource;
        public AudioSource alarmAudioSource;

        [Header("Audio Settings")]
        public float alarmDuration = 1.0f;
        public float musicFadeOutSpeed = 2.0f;
        public float musicFadeInSpeed = 2.0f;

        private bool isAlarmPlaying = false;

        private void Awake()
        {
            // Verificar si ya existe una instancia
            if (Instance == null)
            {
                Instance = this;  // Asignar la instancia
                DontDestroyOnLoad(gameObject);  // No destruir este objeto entre escenas
            }
            else
            {
                Destroy(gameObject);  // Destruir el objeto duplicado
            }
        }

        private void Start()
        {
            musicAudioSource.Play();
        }

        public void PlayAlarmAndPauseMusic()
        {
            if (isAlarmPlaying) return;

            StartCoroutine(FadeOutMusic());
            alarmAudioSource.Play();
            Invoke("EndAlarm", alarmDuration);
        }

        private void EndAlarm()
        {
            alarmAudioSource.Stop();
            StartCoroutine(FadeInMusic());
        }

        private System.Collections.IEnumerator FadeOutMusic()
        {
            float startVolume = musicAudioSource.volume;
            while (musicAudioSource.volume > 0)
            {
                musicAudioSource.volume -= startVolume * Time.deltaTime / musicFadeOutSpeed;
                yield return null;
            }
            musicAudioSource.volume = 0;
        }

        private System.Collections.IEnumerator FadeInMusic()
        {
            float targetVolume = 1.0f;
            while (musicAudioSource.volume < targetVolume)
            {
                musicAudioSource.volume += Time.deltaTime / musicFadeInSpeed;
                yield return null;
            }
            musicAudioSource.volume = targetVolume;
        }
    }
}

