using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DataManager
{
    public static string currentPlayerName = "No Name";
    private readonly static string savePath;

    public static List<PlayerScore> rankingData { get; private set; }
    private static int rankingBorder = 10;

    private static SerializedRankingData _rankingData;

    static DataManager()
    {
        _rankingData = new SerializedRankingData();
        savePath = Application.persistentDataPath + "/save.json";
        LoadRanking();
    }

    private static void SaveRanking()
    {
        _rankingData.scores = rankingData;
        string json = JsonUtility.ToJson(_rankingData);
        File.WriteAllText(savePath, json);
    }

    private static void LoadRanking()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            rankingData = JsonUtility.FromJson<SerializedRankingData>(json).scores;
        }
        else rankingData = new List<PlayerScore>();
    }

    public static void DeleteRanking()
    {
        rankingData = new List<PlayerScore>();
        SaveRanking();
    }

    public static void UpdateRanking(int score)
    {
        rankingData.Add(new PlayerScore(currentPlayerName, score));
        rankingData.Sort((data1, data2) => { return data2.score - data1.score; }); // descending order sort
        if(rankingData.Count > rankingBorder) rankingData.RemoveRange(rankingBorder, rankingData.Count - rankingBorder);
        SaveRanking();
    }

    [Serializable]
    public class PlayerScore
    {
        public string playerName;
        public int score;

        public PlayerScore(string name, int score) { playerName = name; this.score = score; }
    }

    [Serializable]
    private class SerializedRankingData
    {
        public List<PlayerScore> scores;
    }
}
