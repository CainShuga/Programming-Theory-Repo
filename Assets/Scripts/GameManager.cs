using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // ENCAPSULATION

    public List<GameObject> animals;
    private float spawnRate = 5.0f;
    private float spawnRangeZ = 2.0f;

    public TextMeshProUGUI pointCount;
    public TextMeshProUGUI yourScore;
    public Button instructionsPanel;
    public Button gameOverScreen;
    private int photoPoints = 0;
    private bool isGameActive = false;

    public TextMeshProUGUI timerText;
    private float timeRemaining = 60;
    private bool timerIsRunning = false;

    public int spawnedAnimalCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        InvokeRepeating("SpawnAnimal", 2.0f, spawnRate);
        pointCount.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        instructionsPanel.gameObject.SetActive(false);
        isGameActive = true;
        timerIsRunning = true;
        
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else
            {
                GameOver();
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void UpdateScore(int animalValue)
    {
        photoPoints += animalValue;
        pointCount.text = $"Points: {photoPoints}";
    }

    void SpawnAnimal()
    {
        
        int index = Random.Range(0, animals.Count);
        Vector3 spawnPos = new Vector3(9.2f, 2.0f, Random.Range(spawnRangeZ, -spawnRangeZ));
        
       if (isGameActive && spawnedAnimalCount < 5)
        {
            Instantiate(animals[index], spawnPos, animals[index].transform.rotation);
        }
        CountSpawnedAnimals("Animal");

    }

    void GameOver()
    {
        isGameActive = false;
        yourScore.text = $"You scored {photoPoints} points!";
        gameOverScreen.gameObject.SetActive(true);
        pointCount.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("Time: {0:00}", seconds);
    }

    void CountSpawnedAnimals(string tag)
    {
        GameObject[] spawnedAnimals = GameObject.FindGameObjectsWithTag(tag);
        spawnedAnimalCount = spawnedAnimals.Length;
    }
}
