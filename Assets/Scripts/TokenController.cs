using UnityEngine;

public class TokenController : MonoBehaviour
{
    public int puntos = 10; // Puntos que da el token

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddScore(puntos);
            GetComponent<Collider2D>().enabled = false; // Desactiva el Collider
            Destroy(gameObject);
        }
    }

}
