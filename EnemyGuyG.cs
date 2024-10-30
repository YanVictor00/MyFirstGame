using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuy : MonoBehaviour
{
    //Variáveis
    public float speed;
    public float walkTime = 3f;

    public int health;

    float timer;

    bool walkRight;

    private Animator anim;
    private Rigidbody2D rig;
//Método inicial
    void Start()
    {
        //GetComponents
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
//Método de frame por  frame do Rigidbody2D
    void FixedUpdate()
    {
        //frames por segundos dependendo do dispositivo
        timer += Time.deltaTime;
        //se o tempo for maior que o walkTime
        if(timer >= walkTime)
        {
            //walkRight recebe o valor inverso
            walkRight = !walkRight;
            // tempo zera
            timer = 0f;
        }
        //se walkRight for True
        if(walkRight)
        {
            // transform eulerAngles recebe X 0 e Y 0
            transform.eulerAngles = new Vector2(0,0);
            // se move no eixo -X * velocidade
            rig.velocity = Vector2.left * speed; 
        }
        //se não
        else
        {
            // transform eulerAngles recebe X 0 e Y 180f
            transform.eulerAngles = new Vector2(0,180f);
            // se move no eixo +X * velocidade
            rig.velocity = Vector2.right * speed; 
        }
    }
    //método de dano
    public void Damage(int dmg)
    {   
        //health recebe decrescido do dmg
        health -= dmg;
        //animação de hit
        anim.SetTrigger("hit");
        //se health for menor ou igual a zero
        if(health <= 0)
        {
            //destrui o inimigo
            Destroy(gameObject);
        }

    }
}
