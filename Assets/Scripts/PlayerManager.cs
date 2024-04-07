using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int life_p;
    public static int life;

   // public FeverManager fever;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameManager.Game_over && collision.tag =="object")
        {
            if (!FeverManager.fever_On)
            {
                life--;
                if (life == 0)
                {
                    GameManager.Game_over = true;
                    Instantiate(collision.gameObject);
                    //Debug.Log("game over(pm)");
                }

                Debug.Log("life down" + life);
            }

            else
            {
                ScoreManager.score += 100;
                collision.gameObject.GetComponent<ObjectManager>().is_fly = true;
            }
           
        }

        if(!GameManager.Game_over && collision.tag == "dfruit")
        {
            if(!FeverManager.fever_On)
                     FeverManager.fever_eat = true;
            Destroy(collision.gameObject);
        }
    }

    private void Awake()
    {
        life = life_p;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
