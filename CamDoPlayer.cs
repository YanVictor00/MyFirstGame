using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    //Variáveis
    private Transform player;
    public float smooth;

    //Método Inicial
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    //Método Suave
    void LateUpdate()
    {   
        //Se posição X do player for maior ou igual a -1,5 e menor ou igual 40
        if(player.position.x >= -1.5f && transform.position.x <= 40)
        {
            //Variável following recebe um novo vector3 (posição X do player e manter a Y e Z)
            Vector3 following = new Vector3(player.position.x, transform.position.y, transform.position.z);
            //transform.position recebe Vector3 mais suave entre transform.position e following, velocidade da suavidade * fps para todos
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
        }

    }
}
