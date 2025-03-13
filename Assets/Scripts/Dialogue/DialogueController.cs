using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Dialogue
{
    public class DialogueController : MonoBehaviour
    {

        [SerializeField] private string[] mLines;
        [SerializeField] private string[] endLines;
        [SerializeField] private float timeBetweenLines;


        [SerializeField] private TMP_Text boxTxt;
        private int currentLine;


        private bool initDay = true;

        private void OnEnable()
        {
            boxTxt.text = "";
            StartCoroutine(Typing());
        }

        public void ContinueButton()
        {
            StopAllCoroutines();
            currentLine++;
            
            if (currentLine < mLines.Length)
            {
                StartCoroutine(Typing());
            }
            else
            {
                this.gameObject.SetActive(false);
                initDay = false;
                currentLine = 0;
            }
        }
        
        private IEnumerator Typing()
        {
            boxTxt.text = "";

            if (initDay)
            {
                foreach (char c in mLines[currentLine])
                {
                    boxTxt.text += c;
                    yield return new WaitForSeconds(timeBetweenLines);
                }
            }
            else
            {
                foreach (char c in endLines[currentLine])
                {
                    boxTxt.text += c;
                    yield return new WaitForSeconds(timeBetweenLines);
                }
            }

        }
        
    }
}
