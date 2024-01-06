using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    private void Awake()
    {
        _currentScoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString();
        _bestScoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }

    public void SceneChange(int value)
    {
        SceneManager.LoadScene(value);
    }
}
