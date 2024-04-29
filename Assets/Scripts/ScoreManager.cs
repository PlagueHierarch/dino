using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ScoreData
{
    public string[] highscore;
}

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;

    public static List<string> playerScores = new List<string>();
    private string path;
    public ScoreData scoreData;
    private bool saved = false;

    private void Awake()
    {
        path = Path.Combine(Application.persistentDataPath  + "/" + "ranking.json");
    }
    void Start()
    {
        score = 0;
        saved = false;

        if(File.Exists(path))
        {
            string data = File.ReadAllText(path);
            scoreData = JsonUtility.FromJson<ScoreData>(File.ReadAllText(path));
            playerScores = scoreData.highscore.OfType<string>().ToList();
            /*for(int i = 0; i < playerScores.Count; i++)
            {
              Debug.Log(playerScores[i]);
            }*/
        }

        else
        {
            for(int i = 0; i < 7; i++)
            {
                playerScores.Add("00000");
            }
            saveScore();
        }

        StartCoroutine(ScoreAdd());
    }

    private void Update()
    {
        if (GameManager.Game_over && !saved)
        {
            AddScore(score);
            saved = true;
        }
    }

    private IEnumerator ScoreAdd()
    {
        while (!GameManager.Game_over)
        {
            score += (int)(1 * ObjectMover.speed);
            //Debug.Log(ObjectMover.speed);
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(0.1f);
        }
        
    }

    public void AddScore(int score)
    {
        playerScores.Add(score.ToString());
        playerScores.Sort((a, b) => b.CompareTo(a));

        if(playerScores.Count > 7)
        {
            playerScores.RemoveRange(7, playerScores.Count - 7);
        }

        saveScore();
        
    }

    private void saveScore()
    {
        scoreData.highscore = playerScores.ToArray();
        string jsonData = JsonUtility.ToJson(scoreData);
        Debug.Log("scoredata " + jsonData);
        File.WriteAllText(path, jsonData);
    }
}
