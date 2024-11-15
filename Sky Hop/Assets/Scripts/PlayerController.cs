using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text coinText;

    private int score = 0;
    private int coins = 0;
    private float fallThreshold = -6f;

    private void Start()
    {
        Time.timeScale = 1;

        UpdateUI();
    }

    private void Update()
    {
        // Движение влево и вправо
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        // Проверка на падение ниже порога
        if (transform.position.y < fallThreshold)
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Обнаружено столкновение с: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Coin"))
        {
            coins++; // Увеличиваем счётчик монет
            UpdateUI(); // Обновляем UI, если необходимо
            Debug.Log("Монетка собрана! Всего монет: " + coins);
            Destroy(collision.gameObject); // Удаляем монету из сцены
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SpikePlatform"))
        {
            GameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "OneTimePlatform")
        {
            score++;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        scoreText.text = score.ToString();
        coinText.text = coins.ToString();
    }

    public bool UseCoinForRevive()
    {
        if (coins > 10)
        {
            coins-=10;
            UpdateUI();
            return true;
        }
        return false;
    }

    public int GetScore() => score;
    public int GetCoins() => coins;

    public void RevivePlayer()
    {
        transform.position = new Vector3(0, Camera.main.transform.position.y, 0);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        FindObjectOfType<GameOverUIManager>().ShowGameOverUI();
    }
}
