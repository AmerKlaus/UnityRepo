using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject Star;  // Reference to the star prefab
    public float spawnInterval = 3f; // Time interval between spawns
    public Vector3 spawnAreaMin;  // Minimum bounds of the spawn area
    public Vector3 spawnAreaMax;  // Maximum bounds of the spawn area
    public int score = 0;
    public Text scoreText;

    private void Start()
    {
        // Start the repeating spawn process
        InvokeRepeating("SpawnStar", 0f, spawnInterval);
    }

    void SpawnStar()
    {
        // Generate random position within the defined spawn area
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        // Instantiate a new star at the random position
        Instantiate(Star, randomPosition, Quaternion.identity);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            Destroy(other.gameObject);
            score += 100;
            scoreText.text = "Score : " + score;
        }
    }
}