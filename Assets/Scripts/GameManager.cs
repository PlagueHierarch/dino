using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public static bool Game_over;
    private string sceneName;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else instance = this;

        Game_over = false;
    }

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {

        if(sceneName == "startScene")
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Main");
            }
        }

       if (Game_over)
        {
            //Debug.Log("game over");
            if (showScoreBoard.showed && (Input.GetMouseButton(0) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)))
            {
                SceneManager.LoadScene("startScene");
            }
        }
            
    }


}
