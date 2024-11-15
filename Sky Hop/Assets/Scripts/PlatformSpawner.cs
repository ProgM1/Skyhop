using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject oneTimePlatformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject coinPrefab;
    public float spawnInterval = 2f;
    private float timer;
    private Vector3 lastSpawnPosition;

    private void Start()
    {
        lastSpawnPosition = transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPlatform();
            timer = 0;
        }
    }

    void SpawnPlatform()
    {

        Vector3 spawnPosition = new Vector3(Random.Range(-2f, 2f), Camera.main.transform.position.y + 6f, 0);

        float randomValue = Random.value;
        GameObject platformToSpawn;


        if (randomValue < 0.15f)
        {
            platformToSpawn = spikePlatformPrefab;
            Instantiate(platformToSpawn, spawnPosition, Quaternion.identity);


            Vector3 leftPosition = spawnPosition + new Vector3(4f, 1, 0);
            Vector3 rightPosition = spawnPosition + new Vector3(3.5f, 0, 0);

            Instantiate(platformPrefab, leftPosition, Quaternion.identity);
            Instantiate(platformPrefab, rightPosition, Quaternion.identity);
        }
        else
        {
            // Случайная платформа (обычная или одноразовая)
            platformToSpawn = (randomValue < 0.6f) ? platformPrefab : oneTimePlatformPrefab;
            Instantiate(platformToSpawn, spawnPosition, Quaternion.identity);
        }

        // Спавн монетки на платформе (если не спайковая платформа)
        if (Random.value > 0.2f && platformToSpawn != spikePlatformPrefab)
        {   Vector3 coinPosition = spawnPosition + new Vector3(0, 1f, 0);
            Instantiate(coinPrefab, coinPosition, Quaternion.identity);
        }

        // Обновляем последнее положение спавна
        lastSpawnPosition = spawnPosition;
    }
}
