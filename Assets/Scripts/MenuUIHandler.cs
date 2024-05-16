using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;

    // Start is called before the first frame update
    void Start()
    {
        nameInputField.onEndEdit.AddListener(text =>
        {
            DataManager.CurrentPlayerName = text;
        });
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }
}
