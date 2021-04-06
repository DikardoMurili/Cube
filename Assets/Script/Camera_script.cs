using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        transform.LookAt(player.transform.position);
        Quaternion rotate = Quaternion.Euler(0, player.transform.eulerAngles.y, 0);
        transform.position = player.transform.position + rotate * offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        //Камера крутится при выиграше
        if(player.GetComponent<Player_S>().Win)
        {
            transform.position += transform.right * 2f*Time.deltaTime;
        }
    }
}
