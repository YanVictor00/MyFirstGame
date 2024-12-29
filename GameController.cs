using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //variáveis
    public Text healthText;
    //variável static
    public static GameController instance;

    public GameObject pauseObj;
    private bool isPaused = false;

    public GameObject gameOverObj;

    public int score;
    public Text scoreText;
    public int totalScore;

    //método chamado antes do Start na ordem de execução
    void Awake()
    {   
        //tornando static para acessar de outro script
        instance = this;
    }

    void Start()
    {
        totalScore = PlayerPrefs.GetInt("score");
    }

    void Update()
    {
        // Verifica se o jogador pressionou a tecla de pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();

        PlayerPrefs.SetInt("score", score + totalScore);
    }

    //método para passar o valor de vidas para o Text do Canva 
    public void UpdateLives(int value)
    {
        // "x " + o valor do texto irá receber o valor do parâmetro covertido em string
        healthText.text = "x " + value.ToString();
    }

   public void PauseGame()
    {
        isPaused = !isPaused; 
        pauseObj.SetActive(isPaused); 
        Time.timeScale = isPaused ? 0f : 1f; 
    }

    public void GameOver()
    {
        gameOverObj.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

}
