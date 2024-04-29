using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using UnityEngine.UIElements;
using UnityEditor.Rendering;

public class showScoreBoard : MonoBehaviour
{
    ScoreManager scoreManager;
    public static bool showed = false;

    private List<string> scores = ScoreManager.playerScores;
    public List<Text> textList;

    public GameObject panel;
    public GameObject board;
    Color panelColor; 
    public float alpha = 5;
    public int speed;

    private void Awake()
    {
        panelColor = panel.GetComponent<Image>().color;
        panel.SetActive(false);
    }
    private void Start()
    {
        showed = false;
    }
    private void Update()
    {
        if (GameManager.Game_over && !showed)
        {
            for (int i = 0; i < 7; i++)
            {
                //Debug.Log(i + "th= " + scores[i]);
                textList[i].text = scores[i];
            }

            panel.SetActive(true);
            panelColor.a = 0;
            StartCoroutine(boardCoroutine());
            
            Debug.Log(showed);
        }
    }

    private IEnumerator boardCoroutine()
    {
        yield return StartCoroutine(showBoard());
    }
    private IEnumerator showBoard()
    {
        StartCoroutine(panelDark());
        yield return StartCoroutine(moveBoard());
        yield return new WaitForSeconds(3);
        showed = true;
    }

    private IEnumerator panelDark()
    {
        while(panelColor.a < 180)
        {
            panelColor.a += alpha;
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator moveBoard()
    {
        while(board.transform.position.x > 0)
        {
            board.transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
