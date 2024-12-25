using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //variáveis
    public Text healthText;
    //variável static
    public static GameController instance;

    //método chamado antes do Start na ordem de execução
    void Awake()
    {   
        //tornando static para acessar de outro script
        instance = this;
    }

    void Update()
    {
        
    }

    public void UpdateScore(int value)
        {
            score += value;
            scoreText.text = score.ToString();
        }


    //método para passar o valor de vidas para o Text do Canva 
    public void UpdateLives(int value)
    {
        // "x " + o valor do texto irá receber o valor do parâmetro covertido em string
        healthText.text = "x " + value.ToString();
    }
}
