using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public GameObject battery;
    public Text scorePlayerText;
    public Text levelText;
    public Text restartText;
    public Text gameOverText;
    public Text batteryChargeText;
    public static int levelCount;
    public static int batteryCharge;
    public static int displayNextUpgrade;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int hazardCount;
    public int nextUpgrade;

    private bool gameOver;
    private bool restart;
    private int score;

    public void AddScore(int newScoreValue)
    {
        score = score + newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        gameOver = true;
    }

    private void Start()
    {
        restart = false;
        gameOver = false;
        restartText.text = "";
        gameOverText.text = "";

        score = 0;
        UpdateScore();

        levelCount = 0;
        UpdateLevel();

        batteryCharge = 0;
        UpdateBatteryCharge();

        displayNextUpgrade = nextUpgrade;

        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }

        UpdateBatteryCharge();
    }

    private void UpdateScore()
    {
        scorePlayerText.text = "Score: " + score;
    }

    private void UpdateLevel()
    {
        levelText.text = "Level: " + levelCount;
    }

    private void UpdateBatteryCharge()
    {
        batteryCharge = PowerUp.powerUpCount;
        if (PowerUp.gunTwo == false && PowerUp.gunThree == false)
        {
            batteryChargeText.text = (batteryCharge - 1) + " / " + nextUpgrade + " : Half-charged";
        }

        else if (PowerUp.gunTwo == true && PowerUp.gunThree == false)
        {
            batteryChargeText.text = (batteryCharge - 1) + " / " + nextUpgrade * 2 + " : Full-charged";
        }
        
        else
        {
            batteryChargeText.text = PlayerController.displaySpeed + " % : Speed";
        }
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            int firstBatterySpawn = Random.Range(0, hazardCount - 1);
            int secondBatterySpawn = Random.Range(0, hazardCount - 1);

            for (int i = 0; i < hazardCount; i++)
            {            
                if (gameOver)
                {   
                    break;
                }

                Instantiate(hazard, Random.insideUnitCircle.normalized * 15, Quaternion.identity);

                if (i == firstBatterySpawn || i == secondBatterySpawn)
                {
                    Instantiate(battery, Random.insideUnitCircle * 9, Quaternion.identity);
                }

                yield return new WaitForSeconds(spawnWait);
            }
            
            if (gameOver)
            {
                restartText.text = "Press 'R' for restart";
                restart = true;
                break;
            }

            yield return new WaitForSeconds(waveWait);

            levelCount++;
            UpdateLevel();
        }                    
    }       
}