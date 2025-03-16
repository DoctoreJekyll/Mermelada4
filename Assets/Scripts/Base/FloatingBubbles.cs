using UnityEngine;
using UnityEngine.UI;

namespace Base
{
    public class FloatingBubbles : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float floatStrength = 100f;  // Fuerza de flotación
        [SerializeField] private float floatSpeed = 1.0f;    // Velocidad del movimiento
        [SerializeField] private float lateralMovementRange = 18f; // Rango de movimiento lateral (X)
        [SerializeField] private float lateralSpeed = 3.5f; // Velocidad lateral

        private Button button;
        private Vector3 startPos;

        private void Start()
        {
            button = GetComponent<Button>();
            startPos = transform.position; // Guardamos la posición inicial de la burbuja
            
            if (button != null)
            {
                button.onClick.AddListener(PlayBubbleSound);
            }
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

        private void PlayBubbleSound()
        {
            MusicManager musicManager = FindFirstObjectByType<MusicManager>();
            musicManager.BubblePlay();
        }
        
        private void OnDestroy()
        {
            if (button != null)
            {
                button.onClick.RemoveListener(PlayBubbleSound); // Limpiar la suscripción para evitar errores
            }
        }
    }
}
