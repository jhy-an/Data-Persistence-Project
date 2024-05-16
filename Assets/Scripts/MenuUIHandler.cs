using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private GameObject rankingScreen;

    // Start is called before the first frame update
    void Start()
    {
        nameInputField.onEndEdit.AddListener(text =>
        {
            DataManager.currentPlayerName = text;
        });
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void InitializeSave()
    {
        DataManager.DeleteRanking();
    }

    public void DisplayRanking()
    {
        rankingScreen.SetActive(true);
    }

    public void CloseRanking()
    {
        rankingScreen.SetActive(false);
    }
}
