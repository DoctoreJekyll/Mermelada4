using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Images
{
    public class InstantiateImages : MonoBehaviour
    {
        [Header("Morning Lists")]
        [SerializeField] private List<GameObject> morningImagesOutPrefabs;
        [SerializeField] private List<GameObject> workImagesPrefab;
        [SerializeField] private List<GameObject> coffeeOrElsePrefabs;
        
        [Header("Afternoon Lists")]
        [SerializeField] private List<GameObject> afternoonImagesOutPrefabs;
        [SerializeField] private List<GameObject> afternoonElseImagesOutPrefabs;
        
        [Header("Evening Lists")]
        [SerializeField] private List<GameObject> eveningImagesOutPrefabs;
        [SerializeField] private List<GameObject> eveningElseImagesOutPrefabs;


        [SerializeField] private Transform parent;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                InstantiateMorningOutImages(6);
            }
        }

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


        private void InstantiateMorningOutImages(int maxElements)
        {
            List<GameObject> shuffled = Shuffle(morningImagesOutPrefabs);

            if (maxElements <= shuffled.Count())
            {
                for (int i = 0; i < maxElements; i++)
                {
                    Instantiate(shuffled[i], parent);
                }
            }
        }
        
    }
}
