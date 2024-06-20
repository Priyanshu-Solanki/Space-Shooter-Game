using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject[] hazards1;
    public GameObject[] hazards2;
    public Vector3 spawnValues;

    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text gameOverText;
    public GameObject restartButton;

    private int score;
    private bool gameOver;
    
    void Start()
    {
        gameOver = false;
        gameOverText.text = "";
        restartButton.SetActive(false);
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves()); 
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

   void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
        
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard1 = hazards1[Random.Range(0,hazards1.Length)];
                GameObject hazard2 = hazards2[Random.Range(0, hazards2.Length)];
                Vector3 spawnPosition = new Vector3
                    (Random.Range(spawnValues.x, -spawnValues.x), spawnValues.y, spawnValues.z);

                Quaternion spawnRotation = Quaternion.identity;

                if (score < 300)
                {

                    Instantiate(hazard1, spawnPosition, spawnRotation);

                }
                else
                {
                    Instantiate(hazard2, spawnPosition, spawnRotation);
                }

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);


            if(gameOver)
            {
                restartButton.SetActive(true);
                break;
            }
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("scene0", LoadSceneMode.Single);
    }
}
