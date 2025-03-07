using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject carameloNaranja; // Prefab del objeto que cae
    public float spawnRate = 1f;      // Frecuencia de generación (objetos por segundo)
    public float spawnAreaWidth = 6f; // Ancho del área de generación

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnObject()
    {
        // Posición aleatoria dentro del área de generación
        float randomX = Random.Range(-spawnAreaWidth / 2f, spawnAreaWidth / 2f);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);

        // Instancia el objeto
        Instantiate(carameloNaranja, spawnPosition, Quaternion.identity);
    }
}