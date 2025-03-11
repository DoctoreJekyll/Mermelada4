using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Base
{
    public class VerticalSnapScroll : MonoBehaviour, IBeginDragHandler, IEndDragHandler
    {
        [Header("ScrollRect")]
        [SerializeField] private ScrollRect scrollRect;

        [Header("Snap")]
        [SerializeField] private float snapSpeed = 10f;

        [Header("Drag")]
        [SerializeField] private float dragThreshold = 50f;
        
        [Header("Components")]
        [SerializeField] private DragCounter dragCounter;

        [Header("Events")] 
        [SerializeField] private UnityEvent events;
        
        private RectTransform content;
        private float itemHeight;
        private Vector2 startDragPosition;
        private int currentIndex = 0;
        private int targetIndex = 0;
        private Coroutine snapCoroutine;
        
        void Start()
        {
            InitializeComponents();
        }
        
        private void InitializeComponents()
        {
            if (scrollRect == null)
                scrollRect = GetComponent<ScrollRect>();

            content = scrollRect.content;
            itemHeight = GetItemHeight();
        }
        
        private float GetItemHeight()
        {
            if (content.childCount > 0)
            {
                RectTransform firstItem = content.GetChild(0) as RectTransform;
                if (firstItem != null)
                    return firstItem.rect.height;
            }
            return 0;
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            CancelCurrentSnap();
            startDragPosition = content.anchoredPosition;
        }
        
        private void CancelCurrentSnap()
        {
            if (snapCoroutine != null)
            {
                StopCoroutine(snapCoroutine);
                snapCoroutine = null;
            }
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            float dragDelta = CalculateDragDelta();
            currentIndex = CalculateCurrentIndex(startDragPosition);
            
            if (currentIndex == content.childCount - 1 && dragDelta > dragThreshold)
            {
                Debug.Log("Última imagen alcanzada, no se procesa el drag.");
                return;
            }
            
            if (currentIndex == 0 && dragDelta < -dragThreshold)
            {
                Debug.Log("Primera imagen alcanzada, no se procesa el drag.");
                return;
            }
            
            
            targetIndex = CalculateTargetIndex(dragDelta, currentIndex);
            targetIndex = Mathf.Clamp(targetIndex, 0, content.childCount - 1);
            
            
            dragCounter.AddCounter();
            snapCoroutine = StartCoroutine(SnapToIndex());
        }
        
        private float CalculateDragDelta()
        {
            return content.anchoredPosition.y - startDragPosition.y;
        }
        
        private int CalculateCurrentIndex(Vector2 startPos)
        {
            return Mathf.RoundToInt(startPos.y / itemHeight);
        }

        private int CalculateTargetIndex(float dragDelta, int currentIdx)
        {
            if (dragDelta > dragThreshold)
                return currentIdx + 1;
            else if (dragDelta < -dragThreshold)
                return currentIdx - 1;
            else
                return currentIdx;
        }
        
        private IEnumerator SnapToIndex()
        {
            float targetPosY = GetTargetPositionY();
            while (!IsSnapComplete(targetPosY))
            {
                UpdateContentPosition(targetPosY);
                yield return null;
            }
            SetContentPosition(targetPosY);
            snapCoroutine = null;
        }
        
        private float GetTargetPositionY()
        {
            return targetIndex * itemHeight;
        }
        
        private bool IsSnapComplete(float targetPosY)
        {
            return Mathf.Abs(content.anchoredPosition.y - targetPosY) <= 0.1f;
        }
        
        private void UpdateContentPosition(float targetPosY)
        {
            float newY = Mathf.Lerp(content.anchoredPosition.y, targetPosY, snapSpeed * Time.deltaTime);
            content.anchoredPosition = new Vector2(content.anchoredPosition.x, newY);
        }
 
        private void SetContentPosition(float posY)
        {
            content.anchoredPosition = new Vector2(content.anchoredPosition.x, posY);
        }
    }
}

