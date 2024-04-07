using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(PlayerManager.life)
        {
            case 2:
                heart1.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                break;
            case 1:
                heart2.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                break;
            case 0:
                heart3.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                break;
        }


    }
}
