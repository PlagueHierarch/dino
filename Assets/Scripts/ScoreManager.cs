using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;

    void Start()
    {
        StartCoroutine(ScoreAdd());
    }

    private IEnumerator ScoreAdd()
    {
        while (!GameManager.Game_over)
        {
            score += (int)(1 * ObjectMover.speed);
            Debug.Log(ObjectMover.speed);
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
