using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingText : MonoBehaviour
{
    private TextMeshProUGUI rankingText;

    private void Awake()
    {
        rankingText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        string output = string.Empty;
        if (DataManager.rankingData.Count > 0)
        {
            int rank = 1;
            foreach (DataManager.PlayerScore score in DataManager.rankingData) output += rank++ + ". " + score.playerName + " : " + score.score + "\n";
        }
        else output += "There is no score.";
        rankingText.text = output;
    }
}
