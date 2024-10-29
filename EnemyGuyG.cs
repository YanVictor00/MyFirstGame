using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuy : MonoBehaviour
{
    public float speed;
    public float walkTime = 3f;

    public int health;

    float timer;
    bool walkRight;


    private Animator anim;
    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(timer >= walkTime)
        {
            //recebe o valor inverso
            walkRight = !walkRight;
            timer = 0f;
        }

        if(walkRight)
        {
            transform.eulerAngles = new Vector2(0,0);
            rig.velocity = Vector2.left * speed; 
        }
        else
        {
            transform.eulerAngles = new Vector2(0,180f);
            rig.velocity = Vector2.right * speed; 
        }
    }

    public void Damage(int dmg)
    {   
        health -= dmg;
        anim.SetTrigger("hit");
        if(health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
