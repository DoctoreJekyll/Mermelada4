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

        private void Start()
        {
            clockValue = 8;
            clockFormat = clockValue.ToString("D2");

            countText.text = clockFormat + ":00";
        }

        public int GetCounterValue()
        {
            return counter;
        }

        public void AddCounter()
        {
            counter++;
            clockValue++;
            clockFormat = clockValue.ToString("D2");
            countText.text = clockFormat + ":00";
        }



    }
}
