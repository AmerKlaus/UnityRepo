using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    // Write down your variables here
    float score;

    private void Awake()
    {
        score = 0;
        Instance = this;
    }

    public void IncrementScore()
    {
        score += 1;
        Debug.Log(score);
    }
}
