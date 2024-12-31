using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Fire : MonoBehaviour, IPointerDownHandler //script do arco mobile
{
    //variavel player 
    private Player player;

    void Start()
    {
        //player recebe o Player
        player = GameObject.FindGameObjectWithTag("Player").
        GetComponent<Player>();
    }

    //void do clique ou toque
    public void OnPointerDown(PointerEventData eventData)
    {
        //touchFirede outro script recebe True 
        player.touchFire = true;
    }

}
