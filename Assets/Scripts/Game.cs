using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{

    public List<GameObject> obstaclePrefabs;

    public float obstacleSpawnDelay;

    float nextSpawnTime;

    public float prefabHeightLimit, prefabHeightVariance;
    float lastPrefabHeight;

    public TMP_Text scoreDisplay;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = score.ToString();
        if(Time.time > nextSpawnTime) 
        {
            SpawnRandomPrefab();
        }
    }

    void SpawnRandomPrefab()
    {
        lastPrefabHeight = Mathf.Clamp(lastPrefabHeight + Random.Range(-prefabHeightVariance,prefabHeightVariance),-prefabHeightLimit,prefabHeightLimit);
        Instantiate(obstaclePrefabs[Random.Range(0,obstaclePrefabs.Count)], new Vector3(5,lastPrefabHeight,0),Quaternion.identity);
        nextSpawnTime = Time.time + obstacleSpawnDelay;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
