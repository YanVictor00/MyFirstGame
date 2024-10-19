using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;
    Animator anime;
    public float speed = 5;
    public float jumpForce;

    void Start()
    {
    rig = GetComponent<Rigidbody2D>();    
    anime = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        //rig.velocity = new Vector2(horizontal) * Time.deltaTime * speed; 
    }

    void Move()
    {    
        //se não pressionar nada valor é 0. Pressionar direita, valor máximo 1. Esquerda valor máximo -1.
        float movement = Input.GetAxis("Horizontal");
        Debug.Log(movement);
        // Adiciona velocidade ao corpo do personagem no eixo x e y.
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if(movement < 0)
        {
            transform.eulerAngles = new Vector3(0, 180f, 0);
        }
        if(movement > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    void Jump()
    {

    }
}
