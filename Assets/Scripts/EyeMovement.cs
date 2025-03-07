using UnityEngine;

public class EyeMovement : MonoBehaviour
{
    public float moveAmount = 0.1f; // Cantidad de movimiento vertical
    public float moveSpeed = 0.5f;   // Velocidad de movimiento
    private Vector3 initialPosition;   // Posici�n inicial de los ojos
    private bool isMovingUp = true;   // Indica si los ojos se est�n moviendo hacia arriba

    void Start()
    {
        initialPosition = transform.position; // Guarda la posici�n inicial
    }

    void Update()
    {
        if (isMovingUp)
        {
            // Mover los ojos hacia arriba
            transform.position += new Vector3(0, moveAmount, 0) * moveSpeed * Time.deltaTime;

            // Si los ojos alcanzan la posici�n m�xima, empezar a bajar
            if (transform.position.y > initialPosition.y + moveAmount)
            {
                isMovingUp = false;
            }
        }
        else
        {
            // Mover los ojos hacia abajo
            transform.position -= new Vector3(0, moveAmount, 0) * moveSpeed * Time.deltaTime;

            // Si los ojos alcanzan la posici�n m�nima, empezar a subir
            if (transform.position.y < initialPosition.y)
            {
                isMovingUp = true;
                transform.position = initialPosition; // Asegura que vuelva a la posici�n inicial exacta
            }
        }
    }
}