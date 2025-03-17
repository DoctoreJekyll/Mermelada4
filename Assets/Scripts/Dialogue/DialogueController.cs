using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dialogue
{
    public class DialogueController : MonoBehaviour
    {

        [SerializeField] private string[] lines;
        [SerializeField] private float timeBetweenLines;


        [SerializeField] private TMP_Text boxTxt;
        private int currentLine;
        

        private void OnEnable()
        {
            boxTxt.text = "";
            StartCoroutine(Typing());
        }

        public void ContinueButton()
        {
            StopAllCoroutines();
            currentLine++;
            
            if (currentLine < lines.Length)
            {
                StartCoroutine(Typing());
            }
            else
            {
                this.gameObject.SetActive(false);
                currentLine = 0;
            }
        }

        public void ContinueButton2()
        {
            StopAllCoroutines();
            currentLine++;
            
            if (currentLine < lines.Length)
            {
                StartCoroutine(Typing());
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
        private IEnumerator Typing()
        {
            boxTxt.text = "";

            foreach (char c in lines[currentLine])
            {
                boxTxt.text += c;
                yield return new WaitForSeconds(timeBetweenLines);
            }
        }
        
    }
}
