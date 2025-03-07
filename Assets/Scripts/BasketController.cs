using UnityEngine;

public class BasketController : MonoBehaviour
{
    public float speed = 5f;
    private float minX, maxX;

    void Start()
    {
        // Calcula los límites de la pantalla automáticamente
        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        minX = (float)((Camera.main.ScreenToWorldPoint(Vector3.zero).x + halfWidth)/1.8);
        maxX = (float)((Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfWidth)/1.8);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);

        // Aplica los límites dinámicamente
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }
}
