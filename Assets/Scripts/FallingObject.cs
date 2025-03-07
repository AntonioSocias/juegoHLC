using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 2f; // Velocidad de caída
    public int points = 1;       // Puntos que otorga este objeto
    public AudioClip sonidoRecoger; // Sonido al ser atrapado por la cesta

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Destruye el objeto si sale de la pantalla
        if (transform.position.y < -5f) // Ajusta el valor según el tamaño de tu pantalla
        {
            Destroy(gameObject);
        }
    }

    // Se llama cuando este objeto colisiona con otro
    void OnTriggerEnter2D(Collider2D other)
    {
        BasketController basket = other.gameObject.GetComponent<BasketController>();
        if (basket != null) // Comprueba si el colisionador tiene el script BasketController
        {
            // Reproducir sonido en el AudioSource de la cesta
            AudioSource audioSource = basket.GetComponent<AudioSource>();
            if (audioSource != null && sonidoRecoger != null)
            {
                audioSource.PlayOneShot(sonidoRecoger);
            }

            // La cesta atrapó el objeto
            GameManager.instance.AddScore(points); // Suma puntos
            Destroy(gameObject); // Destruye el objeto
        }
    }
}
