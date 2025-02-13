using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;


public class Score : MonoBehaviour
{
    public Text scoreText;

    private string filepath;
    private GameSaveData saveData;

    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<BsonDocument> collection;

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

        client = new MongoClient("mongodb+srv://YasunagaMasaaki:Tcjplg1983!!@cluster0.kgkgk.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
        database = client.GetDatabase("unity_test");
        collection = database.GetCollection<BsonDocument>("unity_test0");

        var filter = Builders<BsonDocument>.Filter.Eq("playerid", 0);
        var update = Builders<BsonDocument>.Update.Set("score", finalScore);
        collection.UpdateOne(filter, update);
    }

    [System.Serializable]
    public class GameSaveData
    {
        public int save1 = 0;
    }
}
