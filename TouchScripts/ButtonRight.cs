using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Right : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isRight;
    private Player player;
    public float movement;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && isRight)
        {
            movement += Time.deltaTime;
            
            if(movement > 1f)
            {
                movement = 1f;
            }

            player.movement = movement;
        }

    }


    //é chamado quando clicamos (OU TOUCH) no elemento UI
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicou.");
        isRight = true;
    }

    //É chamado quando tiramos o clique (OU TOUCH) do elemento UI
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Tirou o clique.");
        isRight = false;
        movement = 0f;
        player.movement = movement;
    }
}
