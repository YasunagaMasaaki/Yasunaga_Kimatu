using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public int score = 0;
    GameObject scoreText;

    public void AddScore()
    {
        this.score += 10;
    }

    void Start()
    {
        this.scoreText = GameObject.Find("Score");
    }

    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score:" + score.ToString("D4");
        PlayerPrefs.SetInt("FinalScore", score); // �X�R�A��ۑ�
        PlayerPrefs.Save(); // �����I�ɕۑ�
    }
}
