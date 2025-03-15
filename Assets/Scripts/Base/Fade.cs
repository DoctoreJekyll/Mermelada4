using System;
using UnityEngine;

namespace Base
{
    public class Fade : MonoBehaviour
    {

        public static Fade Instance;
        
        private Animator animator;

        private void Awake()
        {
            Singleton();
            
            animator = GetComponent<Animator>();

        }

        private void Singleton()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }

        public void PlayFadeIn()
        {
            animator.Play("FadeIn");
        }

        public void PlayFadeOut()
        {
            animator.Play("FadeOut");
        }
    }
}
