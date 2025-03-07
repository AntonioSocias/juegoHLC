using UnityEngine;

public class PumpkinBreath : MonoBehaviour
{
    public float scaleAmount = 0.02f; // Cantidad de escalado
    public float scaleSpeed = 1f;    // Velocidad de escalado
    private Vector3 initialScale;      // Escala inicial de la calabaza
    private bool isScalingUp = true;  // Indica si la calabaza se est� inflando

    void Start()
    {
        initialScale = transform.localScale; // Guarda la escala inicial
    }

    void Update()
    {
        if (isScalingUp)
        {
            // Inflar la calabaza
            transform.localScale += new Vector3(scaleAmount, scaleAmount, 0) * scaleSpeed * Time.deltaTime;

            // Si la calabaza alcanza el tama�o m�ximo, empezar a desinflar
            if (transform.localScale.x > initialScale.x + scaleAmount * 2)
            {
                isScalingUp = false;
            }
        }
        else
        {
            // Desinflar la calabaza
            transform.localScale -= new Vector3(scaleAmount, scaleAmount, 0) * scaleSpeed * Time.deltaTime;

            // Si la calabaza alcanza el tama�o m�nimo, empezar a inflar
            if (transform.localScale.x < initialScale.x)
            {
                isScalingUp = true;
                transform.localScale = initialScale; // Asegura que vuelva a la escala inicial exacta
            }
        }
    }
}