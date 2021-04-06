using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_S : MonoBehaviour
{
    public float speed;
    public bool onGround;
    public float Angle;
    public float Rotate_speed;
    private bool angle;
    public GameObject Cube;
    public Transform player;
    private GameObject cube_actual;
    public float count;
    public bool start_game;
    private Animator anim;
    public bool Win;
    public bool Dead;
    public GameObject Cube_efect;
    // Start is called before the first frame update
    void Start()
    {
        Dead = false;
        Win = false;
        count = 0.5f;
        angle = false;
        onGround = false;
        start_game = false;
        anim = GameObject.FindWithTag("Ninja").GetComponent<Animator>();
    }

    // Update is called once per frame
    
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f, 1, QueryTriggerInteraction.Ignore))
        {
            Dead = true;
            anim.SetBool("Dead", true);
        }
        if (angle)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, Angle, 0), Rotate_speed * Time.deltaTime);
        }
        else angle = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Turn")
        {
            angle = true;
        } 
        if(collision.gameObject.tag == "Finish")
        {
            anim.SetBool("Win", true);
            Win = true;
        }
    }
    private void FixedUpdate()
    {
        if (start_game&&!Win&&!Dead)
        {
            anim.SetBool("Move", true);
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
        }
    }
    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        //Сбор кубиков
        if (other.gameObject.tag == "CubePrefab")
        {
            if (Cube_efect)
            {
                GameObject explosion = (GameObject)Instantiate(Cube_efect, other.transform.position, other.transform.rotation);
                Destroy(explosion, explosion.GetComponent<ParticleSystem>().startLifetime);
            }
            Destroy(other.gameObject);
            Vector3 cube_spawn = transform.position + -transform.up * count;
            transform.position += transform.up * 0.5f;
            cube_actual = Instantiate(Cube, cube_spawn, transform.rotation);
            cube_actual.transform.SetParent(player);
            count += 1f;   
        }
    }
}
