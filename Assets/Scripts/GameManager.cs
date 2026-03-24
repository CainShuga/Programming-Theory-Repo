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
    public static GameManager Instance { get; private set; }

    public List<GameObject> animals;
    public float spawnRate = 5.0f;
    public float spawnRangeZ = 3.0f;

    public TextMeshProUGUI pointCount;
    public Button instructionsPanel;
    public int photoPoints = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        InvokeRepeating("SpawnAnimal", 3.0f, spawnRate);
        pointCount.gameObject.SetActive(true);
        instructionsPanel.gameObject.SetActive(false);
        
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
        //pointCount.text = $"Points: {photoPoints}";
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
        Instantiate(animals[index], spawnPos, animals[index].transform.rotation);
        
    }
}
