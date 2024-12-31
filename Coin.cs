using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour //script das moedas
{
    //variavel inteira aonde iremos armazenar o valor do score
    public int scoreValue;

    //void para colisão de um elemento trigger
     private void OnTriggerEnter2D(Collider2D collision){
        //se houver colisão com um GameObject com a tag Player
        if(collision.gameObject.tag == "Player")
        {
            //Atualizar o UpdateScore de outro script com o scoreValue
            GameController.instance.UpdateScore(scoreValue);
            //Destruir GameObject
            Destroy(gameObject);
        }
    }



}