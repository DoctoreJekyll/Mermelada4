using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class CenterImageDetection : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private RectTransform canvas;

        [SerializeField] private GameObject lastViewedImage;
        [SerializeField] private List<GameObject> nonCenteredImages;

        private void Update()
        {
            lastViewedImage = GetCenteredImage();
            nonCenteredImages = GetNonCenteredImages();


            if (Input.GetKeyDown(KeyCode.A))
            {
                DestroyOutOffScreenImages();
            }
            
        }

        public void DestroyOutOffScreenImages()
        {
            foreach (var t in nonCenteredImages)
            {
                Destroy(t);
            }
        }

        private GameObject GetCenteredImage()
        {
            GameObject closestImage = null;
            float closestDistance = Mathf.Infinity;
            
            Vector3 centerScreenPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas, centerScreenPosition, null, out Vector3 worldCenter);

            foreach (Transform image in parent)
            {
                float distance = Vector3.Distance(image.position, worldCenter);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestImage = image.gameObject;
                }
            }

            return closestImage;
        }

        private List<GameObject> GetNonCenteredImages()
        {
            List<GameObject> list = new List<GameObject>();

            GameObject centeredImage = GetLastViewedImage();
            foreach (Transform image in parent)
            {
                if (image.gameObject != centeredImage) // Excluye la imagen centrada
                {
                    list.Add(image.gameObject);
                }
            }

            return list;
        }

        private GameObject GetLastViewedImage()
        {
            return lastViewedImage;
        }
    }
    
}
