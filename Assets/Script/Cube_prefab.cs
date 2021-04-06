using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_prefab : MonoBehaviour
{
    public GameObject Boom;
    private GameObject player;
    private bool M_cube;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        M_cube = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f, 1, QueryTriggerInteraction.Ignore))
        {
            transform.parent = null;
            if (i == 0)
            {
                M_cube = true;
            }
        }
        if(M_cube&& player.GetComponent<Player_S>().Dead==false)
        {
            if (Boom)
            {
                GameObject explosion = (GameObject)Instantiate(Boom, transform.position, transform.rotation);
                Destroy(explosion, explosion.GetComponent<ParticleSystem>().startLifetime);
            }
            i++;
            player.GetComponent<Player_S>().count -= 1f;
            M_cube = false;
            Destroy(gameObject);
        }
    }
}
