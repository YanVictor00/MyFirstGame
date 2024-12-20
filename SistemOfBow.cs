using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//classe
public class Bow : MonoBehaviour
{
//variáveis
    private Rigidbody2D rig;
    public float speed;
    public int damage;
    public bool isRight;
//método inicial
    void Start()
    {
        //rig recebendo GetComponent
        rig = GetComponent<Rigidbody2D>();
        //objeto se destruindo depois de 2 segundos
        Destroy(gameObject, 2f);
    }
//método fps do rigidbody
    void FixedUpdate()
    {
        //se isRight for verdadeiro
        if(isRight)
        {
            //aplicar um vector 2 para direita * velocidade
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            //se isRight for false aplicar um vector 2 para esquerda * velocidade
            rig.velocity = Vector2.left * speed;
        }
       
    }
//Método de colisão de dano da flecha
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //se o gameObject collidir com outro da tag "Enemy" 
        if(collision.gameObject.tag == "Enemy")
        {
            //atualizar o método Damage do Script EnemyGuy, recebendo damage.
            collision.GetComponent<EnemyGuy>().Damage(damage);
            //Em seguida destruindo o gameObject (a Flecha)
            Destroy(gameObject);
        }
    }
}
