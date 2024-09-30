using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int maxScore = 4;
    public static GameManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void IncrementScore()
    {
        ++score;
        Debug.Log("Score : " + score);
        if (score >= maxScore)
        {
            LoadNewScene();
        }
    }
    public void LoadNewScene()
    {
        SceneManager.LoadScene("VictoryScene");
    }

}
