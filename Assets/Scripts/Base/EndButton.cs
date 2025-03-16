using System.Collections;
using UnityEngine;

namespace Base
{
    public class EndButton : MonoBehaviour
    {

        public void End()
        {
            StartCoroutine(EndCoroutine());
        }
        
        IEnumerator EndCoroutine()
        {
            Fade.Instance.PlayFadeIn();
            yield return new WaitForSeconds(2f);
        
            Application.Quit();
        }
    
    }
}
