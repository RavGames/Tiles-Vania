using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameSession : MonoBehaviour
{

    [SerializeField] float totalLives = 3f;
    [SerializeField] float score = 0f;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;



    private void Start()
    {
        livesText.text = totalLives.ToString();
        scoreText.text = score.ToString();
    }


    private void Awake()
    {
        int currentScene = FindObjectsOfType<GameSession>().Length;
        if(currentScene > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void ProcessedPlayerDeath()
    {
        if(totalLives > 1)
        {
            TakeLives();
        }
        else
        {
            ResetGameSession();
        }

    }


    public void AddScore(float amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }


    private void TakeLives()
    {
        totalLives--;
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
        livesText.text = totalLives.ToString();
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene("Start");
        Destroy(gameObject);
    }


}//CLASS
