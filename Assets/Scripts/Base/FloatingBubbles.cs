using UnityEngine;

namespace Base
{
    public class FloatingBubbles : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float floatStrength = 100f;  // Fuerza de flotación
        [SerializeField] private float floatSpeed = 1.0f;    // Velocidad del movimiento
        [SerializeField] private float lateralMovementRange = 18f; // Rango de movimiento lateral (X)
        [SerializeField] private float lateralSpeed = 3.5f; // Velocidad lateral
        
        
        private AudioSource bubbleSound;
        private Vector3 startPos;

        private void Start()
        {
            bubbleSound = GetComponent<AudioSource>();
            startPos = transform.position; // Guardamos la posición inicial de la burbuja
        }

        private void Update()
        {
            // Movimiento de flotación (en el eje Y)
            float newY = Mathf.Sin(Time.time * floatSpeed) * floatStrength;

            // Movimiento lateral (en el eje X)
            float newX = Mathf.Sin(Time.time * lateralSpeed) * lateralMovementRange;

            // Aplicamos el nuevo movimiento a la posición
            transform.position = new Vector3(startPos.x + newX, startPos.y + newY, startPos.z);
        }

        public void PlayBubbleSound()
        {
            bubbleSound.PlayOneShot(bubbleSound.clip);
        }
    }
}
