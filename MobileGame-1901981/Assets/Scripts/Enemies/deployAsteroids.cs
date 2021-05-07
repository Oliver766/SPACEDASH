using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployAsteroids : MonoBehaviour
{
    #region variables
    /// <summary>
    /// array of astroids
    /// </summary>
    public GameObject[] asteroidPrefab;
    /// <summary>
    /// respawn time of asteroids
    /// </summary>
    public float respawnTime = 1.0f;
    /// <summary>
    /// screen bounds
    /// </summary>
    private Vector2 screenBounds;
    #endregion
    #region start
    // Use this for initialization
    void Start()
    {
        // sets screen bounds of asteroids
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // start coroutine of asteroid waves
        StartCoroutine(asteroidWave());

    }
    #endregion
    #region spawn enemy
    /// <summary>
    /// function that spawns asteroids randomly from aray and keeps them spawned in random points
    /// </summary>
    private void spawnEnemy()
    {
        int objectIndex = Random.Range(0, asteroidPrefab.Length); //spawn array
        //GameObject a = Instantiate(asteroidPrefab) as GameObject;
        Instantiate(asteroidPrefab[objectIndex]); // instatiate
        Debug.Log(asteroidPrefab); 
        asteroidPrefab[objectIndex].transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y)); // keep them within screen bound
    }
    #endregion
    #region asteroid waves
    /// <summary>
    /// spawns asteroids  with respawn time
    /// </summary>
    /// <returns></returns>
    IEnumerator asteroidWave()
    {

        while (true)
        {
            yield return new WaitForSeconds(respawnTime); // spawn time
            spawnEnemy();
        }
    }
    #endregion
}
