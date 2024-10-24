using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//classe geral
public class Player : MonoBehaviour
{//Variáveis
    Rigidbody2D rig;
    Animator anime;
    private bool isJumping;
    private bool doubleJump;
    public float speed = 5;
    public float jumpForce;

//método
    void Start()
    {
    rig = GetComponent<Rigidbody2D>();    
    anime = GetComponent<Animator>();
    }
//método
    void Update()
    {   //chamandoo método de movimentação e pulo.
        Move();
        Jump();
    }
//método de movimentação (sistema de movimentação)
    void Move()
    {    
        //nova variável do tipo float recebe o Input.GetAxis( Mecânica de tecla de movimentação 2D )
        float movement = Input.GetAxis("Horizontal");
        Debug.Log(movement);

        // Adiciona velocidade ao corpo do personagem no eixo x e y.
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        //se a variável movement fot menor que zero ele vira o eixo Y a 180 graus.
        if(movement < 0)
        {
            transform.eulerAngles = new Vector3(0, 180f, 0);
        }

        //se a variável movement fot maior que zero ele vira o eixo Y a 0 graus.
        if(movement > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
//método de pulo ( sistema de pulo )
    void Jump()
    {   
        //Se precionar o botão Jump(Space)
        if(Input.GetButtonDown("Jump"))
        {   
            //se isJumping == false
            if(!isJumping)
            {
                //adionar uma força eixo Y no rig com impulso
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                //se a tecla Space for pressionada
                doubleJump = true;
                //se a tecla Space for pressionada
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
