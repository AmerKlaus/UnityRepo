using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this namespace

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int targetScore = 4; // Score to reach before changing scenes

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
