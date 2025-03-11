using UnityEngine;

namespace Base
{
    public class DragCounter : MonoBehaviour
    {


        [SerializeField] private int counter;

        public int getCounterValue()
        {
            return counter;
        }

        public void AddCounter()
        {
            counter++;
        }



    }
}
