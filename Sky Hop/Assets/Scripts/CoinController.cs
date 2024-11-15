using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float speed = 2f; // Скорость движения монеты

    private void Update()
    {
        // Двигаем монету вниз
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Удаляем монету, если она уходит за нижнюю границу камеры
        if (transform.position.y < Camera.main.transform.position.y - 6f)
        {
            Destroy(gameObject);
        }
    }
}
