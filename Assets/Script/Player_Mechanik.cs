using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player_Mechanik : MonoBehaviour,IDragHandler,IBeginDragHandler
{
    public GameObject player;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindWithTag("Ninja").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!player.GetComponent<Player_S>().Win&&!player.GetComponent<Player_S>().Dead)
        {
            player.GetComponent<Player_S>().start_game = true;
            anim.SetBool("Move_go", true);
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {
                if (player.transform.rotation.y == 0)
                {
                    if (player.transform.position.x >= -3 && player.transform.position.x <= 1.9)
                    {
                        player.transform.position += new Vector3(eventData.delta.x / 300, 0, 0);
                    }
                    Move_x();
                }
                if (player.transform.rotation.y != 0)
                {
                    if (player.transform.position.z >= 22 && player.transform.position.z <= 26.9)
                    {
                        player.transform.position += new Vector3(0, 0, eventData.delta.x / 300);
                    }
                    Move_z();
                }
            }
        }
    }
    public void Move_x()
    {
        if (player.transform.position.x <= -3)
        {
            player.transform.position = new Vector3(-3, player.transform.position.y, player.transform.position.z);
        }
        if (player.transform.position.x >= 1.9)
        {
            player.transform.position = new Vector3(1.9f, player.transform.position.y, player.transform.position.z);
        }
    }
    public void Move_z()
    {
        if (player.transform.position.z <= 22)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 22);
        }
        if (player.transform.position.z >= 26.9)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 26.9f);
        }
    }
}
