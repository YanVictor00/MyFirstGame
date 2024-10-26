using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//classe geral
public class Player : MonoBehaviour
{//Variáveis
    Rigidbody2D rig;
    Animator anime;
    private float movement;
    public GameObject bow;
    public Transform firePoint;
    private bool isJumping;
    private bool doubleJump;
    private bool isFire;
    public float speed = 5;
    public float jumpForce;

//método inicial
    void Start()
    {
    rig = GetComponent<Rigidbody2D>();    
    anime = GetComponent<Animator>();
    }
//método frame por frame
    void Update()
    {   //chamandoo métodos.
        Move();
        Jump();
        BowFire();
    }

//método de movimentação (sistema de movimentação)
    void Move()
    {    
        //variável recebe o Input.GetAxis( Mecânica de tecla de movimentação 2D )
        movement = Input.GetAxis("Horizontal");
        Debug.Log(movement);

        // Adiciona velocidade ao corpo do personagem no eixo x e y.
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        //se a variável movement fot menor que zero ele vira o eixo Y a 180 graus.
        if(movement < 0)
        {
            //se isJumping for falso animar o player correndo
            if(!isJumping)
            {
                anime.SetInteger("transition", 1);
            }

            transform.eulerAngles = new Vector3(0, 180f, 0);
        }

        //se a variável movement for maior que zero ele vira o eixo Y a 0 graus.
        if(movement > 0)
        {   
            //se isJumping for falso animar o player correndo
            if(!isJumping)
            {
                anime.SetInteger("transition", 1);
            }

            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        //se movement for igual a ZERO e isJumping for falso animar player pulando.
        if(movement == 0 && !isJumping && !isFire)
        {
            anime.SetInteger("transition", 0);
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
                //animação de pulo
                anime.SetInteger("transition", 2);
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
                    anime.SetInteger("transition", 2);
                    rig.AddForce(new Vector2(0, jumpForce * 1.2f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

     //Método da habilade do ArcoFogo
    void BowFire()
    {
        //chamando a corrotina
       StartCoroutine(Fire());
    }

    //corrotina
    private IEnumerator Fire()
    {   
        //se a tecla E for pressionado
         if(Input.GetKeyDown(KeyCode.E))
        {   
            //isFire recebe True
            isFire = true;
            //animação 3 do transition é ativada
            anime.SetInteger("transition", 3);
            //instanciando uma váriavel local da flecha na posição e rotação do GameObject firePoint
            GameObject Bow = Instantiate(bow, firePoint.position, firePoint.rotation);

            if(transform.rotation.y == 0)
            {
                Bow.GetComponent<Bow>().isRight = true;
            }

            if(transform.rotation.y == 180)
            {
                Bow.GetComponent<Bow>().isRight = false;
            }

            //depois de 1 segundo
            yield return new WaitForSeconds(0.2f);
            //voltar para animação 0 do transition (que é o "iddle")
            anime.SetInteger("transition", 0);
        }
    }

    //método de colisão com a camada Ground( Chão )
    void OnCollisionEnter2D(Collision2D coll)
    {   
        //se gabeObject collidir com a camada 8
        if(coll.gameObject.layer == 8)
        {
            //isJumping recebe false
            isJumping = false;
        }
    }
}
