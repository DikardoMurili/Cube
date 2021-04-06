using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_player : MonoBehaviour
{
    public GameObject Figure_arow;
    public Text Count_gold;
    private int gold_count;
    public GameObject menu;
    public GameObject Gold;
    public Text End;
    public GameObject Gold_boom;
    // Start is called before the first frame update
    void Start()
    {
        Gold.SetActive(false);
        menu.SetActive(false) ;
        Count_gold.text = "0";
        gold_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Player").GetComponent<Player_S>().start_game == true)
        {
            Gold.SetActive(true);
            Figure_arow.SetActive(false);
        }
        if(GameObject.FindWithTag("Player").GetComponent<Player_S>().Win)
        {
            menu.SetActive(true);
            End.text = "You win !!!\n" + "Your score:" + Count_gold.text; 
        }
        if (GameObject.FindWithTag("Player").GetComponent<Player_S>().Dead)
        {
            menu.SetActive(true);
            End.text = "You dead\n Such a simple game XD ";
        }
    }
    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        //Сбор монеток
        if(other.gameObject.tag == "Gold")
        {
            if (Gold_boom)
            {
                GameObject explosion = (GameObject)Instantiate(Gold_boom, other.transform.position, other.transform.rotation);
                Destroy(explosion, explosion.GetComponent<ParticleSystem>().startLifetime);
            }
            Destroy(other.gameObject);
            gold_count++;
            Count_gold.text = gold_count.ToString();
        }
    }
    public void LevelRestart()
    {
        SceneManager.LoadScene("lvl_1");
    }
}
