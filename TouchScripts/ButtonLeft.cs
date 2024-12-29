using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Left : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isLeft;
    private Player player;
    public float movement;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && isLeft)
        {
            movement -= Time.deltaTime;

            if(movement < -1f)
            {
                movement = -1f;
            }

            player.movement = movement;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Aba");
        isLeft = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isLeft = false;
        movement = 0f;
        player.movement = movement;
    }
}
