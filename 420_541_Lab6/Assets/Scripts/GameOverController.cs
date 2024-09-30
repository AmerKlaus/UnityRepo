using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Make sure to include the TextMeshPro namespace


public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(true);
        if (GameManager.Instance)
        {
            scoreText.text = "Score: " + GameManager.Instance.score.ToString();
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restart button clicked");
        SceneManager.LoadScene(0);
    }
}