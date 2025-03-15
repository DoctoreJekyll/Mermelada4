using System;
using UnityEngine;

namespace Base
{
    public class Rotation : MonoBehaviour
    {

        [SerializeField] private float rotateSpeed;

        private void Update()
        {
            float targetRotation = transform.eulerAngles.z +  rotateSpeed;
            float smoothRotation = Mathf.LerpAngle(transform.eulerAngles.z, targetRotation, Time.deltaTime);
            
            transform.rotation = Quaternion.Euler(0, 0, smoothRotation);
        }
    }
}
