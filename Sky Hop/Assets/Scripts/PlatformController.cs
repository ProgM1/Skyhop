using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 2f;
    public float jumpForce = 10f; // Сила прыжка для игрока

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < Camera.main.transform.position.y - 6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, является ли объект игроком
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Применяем силу прыжка к игроку
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
}
