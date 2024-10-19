using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;
    Animator anime;
    private bool isJumping;
    private bool doubleJump;
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
        Jump();
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
        if(Input.GetButtonDown("Jump"))
        {   
            //isJumping == false
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                isJumping = true;
            }
            else
            {
                if(doubleJump)
                {
                    rig.AddForce(new Vector2(0, jumpForce * 2), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }
}
