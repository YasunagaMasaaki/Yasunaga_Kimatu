using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0); // �X�R�A���擾
        scoreText.text = "Score: " + finalScore; // UI�ɕ\��
    }
}
