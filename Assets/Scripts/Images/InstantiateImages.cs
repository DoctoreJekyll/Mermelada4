using System.Collections.Generic;
using System.Linq;
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


        private void InstantiateMorningOutImages(int maxElements, List<GameObject> list)
        {
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
            InstantiateMorningOutImages(elements, morningImagesOutPrefabs);
        }
        
        public void MorningInButton(int elements)
        {
            InstantiateMorningOutImages(elements, morningImagesInPrefabs);
        }
        
        public void MorningNothingToDoButton(int elements)
        {
            InstantiateMorningOutImages(elements, nothingToDoMorningPrefabs);
        }
        
        //AFTERNOON
        public void AfternoonOutButton(int elements)
        {
            InstantiateMorningOutImages(elements, afternoonImagesOutPrefabs);
        }
        
        public void AfternoonInButton(int elements)
        {
            InstantiateMorningOutImages(elements, afternoonInImagesOutPrefabs);
        }
        
        public void AfternoonNothingToDoButton(int elements)
        {
            InstantiateMorningOutImages(elements, nothingToDoAfternoonPrefabs);
        }
        
        
        //EVENING
        public void EveningOutButton(int elements)
        {
            InstantiateMorningOutImages(elements, eveningImagesOutPrefabs);
        }
        
        public void EveningInButton(int elements)
        {
            InstantiateMorningOutImages(elements, eveningInImagesOutPrefabs);
        }
        
        public void EveningNothingToDoButton(int elements)
        {
            InstantiateMorningOutImages(elements, nothingToDoEveningPrefabs);
        }
        
    }
}
