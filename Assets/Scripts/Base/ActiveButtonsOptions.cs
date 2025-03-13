using System;
using UnityEngine;

namespace Base
{
    public class ActiveButtonsOptions : MonoBehaviour
    {
        [SerializeField] private GameObject buttonMorning;
        [SerializeField] private GameObject buttonAfternoon;
        [SerializeField] private GameObject buttonEvening;


        public void UnableAll()
        {
            buttonMorning.SetActive(false);
            buttonAfternoon.SetActive(false);
            buttonEvening.SetActive(false);
        }

        public void ButtonMorning()
        {
            UnableAll();
            buttonMorning.SetActive(true);
        }

        public void ButtonAfternoon()
        {
            UnableAll();
            buttonAfternoon.SetActive(true);
        }

        public void ButtonEvening()
        {
            UnableAll();
            buttonEvening.SetActive(true);
        }
    }
}
