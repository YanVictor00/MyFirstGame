using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    //variáveis
    public Text healthText;
    //variável static
    public static GameController instance;

    void Start()
    {   
        //tornando static para outro script
        instance = this;
    }

    void Update()
    {
        
    }
    //método para passar o valor de vidas para o Text do Canva 
    public void UpdateLives(int value)
    {
        // "x " + o valor do texto irá receber o valor do parâmetro covertido em string
        healthText.text = "x " + value.ToString();
    }
}
