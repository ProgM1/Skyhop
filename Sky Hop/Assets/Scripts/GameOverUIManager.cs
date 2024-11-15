using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMPro.TMP_Text gameOverScoreText;
    public TMPro.TMP_Text gameOverCoinsText;
    public Button restartButton;
    public Button continueButton;

    private PlayerController playerController;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        playerController = FindObjectOfType<PlayerController>();
        restartButton.onClick.AddListener(RestartGame);
        continueButton.onClick.AddListener(ContinueGame);
    }

    public void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = playerController.GetScore().ToString();
        gameOverCoinsText.text = playerController.GetCoins().ToString();
        continueButton.interactable = playerController.GetCoins() > 0;

        // Останавливаем время
        Time.timeScale = 0;
    }

    private void RestartGame()
    {
        // Возвращаем нормальное время перед перезапуском
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ContinueGame()
    {
        if (playerController.UseCoinForRevive())
        {
            gameOverPanel.SetActive(false);
            playerController.RevivePlayer();

            // Возобновляем время
            Time.timeScale = 1;
        }
    }
}
