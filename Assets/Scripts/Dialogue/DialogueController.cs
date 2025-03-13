using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Dialogue
{
    public class DialogueController : MonoBehaviour
    {

        [SerializeField] private string[] mLines;
        [SerializeField] private float timeBetweenLines;


        [SerializeField] private TMP_Text boxTxt;
        private int currentLine;

        private void Start()
        {
            boxTxt.text = "";
            StartCoroutine(Typing());
        }

        public void ContinueButton()
        {
            StopAllCoroutines();
            
            if (currentLine < mLines.Length)
            {
                StartCoroutine(Typing());
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }


        private IEnumerator Typing()
        {
            boxTxt.text = "";
            
            foreach (char c in mLines[currentLine])
            {
                boxTxt.text += c;
                yield return new WaitForSeconds(timeBetweenLines);
            }
            
            currentLine++;
        }
        
    }
}
