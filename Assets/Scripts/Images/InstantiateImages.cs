using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Images
{
    public class InstantiateImages : MonoBehaviour
    {
        [Header("Morning Lists")]
        [SerializeField] private List<GameObject> morningImagesOutPrefabs;
        [SerializeField] private List<GameObject> morningImagesInPrefabs;
        [SerializeField] private List<GameObject> nothingToDoMorningPrefabs;
        
        [Header("Afternoon Lists")]
        [SerializeField] private List<GameObject> afternoonImagesOutPrefabs;
        [SerializeField] private List<GameObject> afternoonInImagesOutPrefabs;
        [SerializeField] private List<GameObject> nothingToDoAfternoonPrefabs;
        
        [Header("Evening Lists")]
        [SerializeField] private List<GameObject> eveningImagesOutPrefabs;
        [SerializeField] private List<GameObject> eveningInImagesOutPrefabs;
        [SerializeField] private List<GameObject> nothingToDoEveningPrefabs;


        [SerializeField] private Transform parent;
        

        private List<GameObject> Shuffle(List<GameObject> list)
        {
            List<GameObject> shuffled = new List<GameObject>(list);
            
            for (int i = 0; i < shuffled.Count; i++)
            {
                GameObject temp = shuffled[i];
                int randomIndex = Random.Range(i, list.Count);
                shuffled[i] = shuffled[randomIndex];
                shuffled[randomIndex] = temp;
            }
            
            return shuffled;
        }


        private IEnumerator InstantiateMorningOutImages(int maxElements, List<GameObject> list)
        {
            Fade.Instance.PlayFadeIn();
            yield return new WaitForSeconds(0.25f);
            CenterImageDetection centerImageDetection = FindFirstObjectByType<CenterImageDetection>();
            centerImageDetection.DestroyOutOffScreenImages();
            
            yield return new WaitForSeconds(0.5f);
            Fade.Instance.PlayFadeOut();
            
            List<GameObject> shuffled = Shuffle(list);

            if (maxElements <= shuffled.Count())
            {
                for (int i = 0; i < maxElements; i++)
                {
                    Instantiate(shuffled[i], parent);
                }
            }
        }
        
        
        //MORNING
        public void MorningOutButton(int elements)
        {
            StartCoroutine(InstantiateMorningOutImages(elements, morningImagesOutPrefabs));
        }
        
        public void MorningInButton(int elements)
        {
            StartCoroutine(InstantiateMorningOutImages(elements, morningImagesInPrefabs));
        }
        
        public void MorningNothingToDoButton(int elements)
        {
            StartCoroutine(InstantiateMorningOutImages(elements, nothingToDoMorningPrefabs));
        }
        
        //AFTERNOON
        public void AfternoonOutButton(int elements)
        {
            StartCoroutine(InstantiateMorningOutImages(elements, afternoonImagesOutPrefabs));
        }
        
        public void AfternoonInButton(int elements)
        {
            StartCoroutine(InstantiateMorningOutImages(elements, afternoonInImagesOutPrefabs));
        }
        
        public void AfternoonNothingToDoButton(int elements)
        {
            StartCoroutine(InstantiateMorningOutImages(elements, nothingToDoAfternoonPrefabs));
        }
        
        
        //EVENING
        public void EveningOutButton(int elements)
        {
            StartCoroutine(InstantiateMorningOutImages(elements, eveningImagesOutPrefabs));
        }
        
        public void EveningInButton(int elements)
        {
            StartCoroutine(InstantiateMorningOutImages(elements, eveningInImagesOutPrefabs));
        }
        
        public void EveningNothingToDoButton(int elements)
        {
            StartCoroutine(InstantiateMorningOutImages(elements, nothingToDoEveningPrefabs));
        }
        
    }
}
