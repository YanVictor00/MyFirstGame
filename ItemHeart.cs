using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeart : MonoBehaviour
{
    //Variavel inteira publica
    public int healthValue;
// void de entrada de colisao 2D (Collisao2D collisao)
    void OnCollisionEnter2D(Collision2D collision)
    {
        //se colidir com um gameobject com a tag Player
        if(collision.gameObject.tag == "Player")
        {
            //Collisao gameobject getcomponent player incrementar valor da variavel healthValue
            collision.gameObject.GetComponent<Player>().IncreaseLife
            (healthValue);
            //destruir gameObejct
            Destroy(gameObject);
        }
    }
}
