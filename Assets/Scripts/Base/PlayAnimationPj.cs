using System;
using UnityEngine;

namespace Base
{
    public class PlayAnimationPj : MonoBehaviour
    {
        private static readonly int Scroll = Animator.StringToHash("Scroll");

        Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void PlayAnimation()
        {
            animator.SetTrigger(Scroll);
        }
        
    }
}
