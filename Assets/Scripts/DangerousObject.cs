using UnityEngine;

public class DangerousObject : MonoBehaviour
{
    public float fallSpeed = 2f; // Velocidad de caída

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("¡Trigger detectado!");

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("¡Boca tocó al jugador! Llamando a GameOver...");

            // Llama al GameManager para gestionar el sonido y el reinicio
            GameManager.instance.GameOver();

            // ⚠️ No destruyas el objeto inmediatamente, deja que GameOver maneje todo
        }
    }
}
