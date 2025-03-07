using UnityEngine;

public class EyeMovement : MonoBehaviour
{
    public float moveAmount = 0.1f; // Cantidad de movimiento vertical
    public float moveSpeed = 0.5f;   // Velocidad de movimiento
    private Vector3 initialPosition;   // Posición inicial de los ojos
    private bool isMovingUp = true;   // Indica si los ojos se están moviendo hacia arriba

    void Start()
    {
        initialPosition = transform.position; // Guarda la posición inicial
    }

    void Update()
    {
        if (isMovingUp)
        {
            // Mover los ojos hacia arriba
            transform.position += new Vector3(0, moveAmount, 0) * moveSpeed * Time.deltaTime;

            // Si los ojos alcanzan la posición máxima, empezar a bajar
            if (transform.position.y > initialPosition.y + moveAmount)
            {
                isMovingUp = false;
            }
        }
        else
        {
            // Mover los ojos hacia abajo
            transform.position -= new Vector3(0, moveAmount, 0) * moveSpeed * Time.deltaTime;

            // Si los ojos alcanzan la posición mínima, empezar a subir
            if (transform.position.y < initialPosition.y)
            {
                isMovingUp = true;
                transform.position = initialPosition; // Asegura que vuelva a la posición inicial exacta
            }
        }
    }
}