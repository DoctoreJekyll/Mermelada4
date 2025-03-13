using System;
using TMPro;
using UnityEngine;

namespace Base
{
    public class DragCounter : MonoBehaviour
    {
        [SerializeField] private int counter;
        [SerializeField] private int clockValue;
        
        [SerializeField] private TMP_Text countText;

        private string clockFormat;
        private ActiveButtonsOptions activeButtonsOptions;

        private void Start()
        {
            activeButtonsOptions = GetComponentInChildren<ActiveButtonsOptions>();
            
            clockValue = 8;
            clockFormat = clockValue.ToString("D2");

            countText.text = clockFormat + ":00";
            
            SetActiveButtonsOptions();
        }

        public int GetCounterValue()
        {
            return counter;
        }

        public void AddCounter()
        {
            if (clockValue >= 24)
            {
                Debug.Log("End of day");
                clockValue -= 24;
                return;
            }
            
            SetClockValue();
            SetActiveButtonsOptions();
        }

        private void SetClockValue()
        {
            counter++;
            clockValue++;
            clockFormat = clockValue.ToString("D2");
            countText.text = clockFormat + ":00";
        }

        private void SetActiveButtonsOptions()
        {
            switch (clockValue)
            {
                case 8:
                    activeButtonsOptions.ButtonMorning();
                    break;
                case 15:
                    activeButtonsOptions.ButtonAfternoon();
                    break;
                case 22:
                    activeButtonsOptions.ButtonEvening();
                    break;
                default:
                    break;
            }
        }
        
    }
}
