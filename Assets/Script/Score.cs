using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class Score : MonoBehaviour
{
    public Text scoreText;

    private string filepath;
    private GameSaveData saveData;

    private void Awake()
    {
        filepath = Path.Combine(Application.dataPath, "data.json");
        LoadData();
    }

    private void LoadData()
    {
        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            saveData = JsonUtility.FromJson<GameSaveData>(json);
        }
        else
        {
            saveData = new GameSaveData();
        }
    }

    private void SaveData()
    {
        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(filepath, json);
    }

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0); // スコアを取得
        scoreText.text = "Score: " + finalScore; // UIに表示
        saveData.save1 = finalScore;
        SaveData();
        Debug.Log("data saved1");
    }

    [System.Serializable]
    public class GameSaveData
    {
        public int save1 = 0;
    }
}
