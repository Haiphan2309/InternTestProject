using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance { get; private set; }
    public static UIManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = GameObject.FindAnyObjectByType<UIManager>();
        }
        return _instance;
    }

    public UIHpSlider uiHpSlider;
    public UIPausePanel uiPausePanel;

    [SerializeField] TMP_Text scoreText;
    public EventHandler<int> changeScoreEvent;

    private void Start()
    {
        uiHpSlider.Setup();
        changeScoreEvent += SetScore;
    }
    void SetScore(object sender , int score)
    {
        scoreText.text = "SCORE: " + score.ToString();
    }
    public void ShowPausePanel()
    {
        uiPausePanel.gameObject.SetActive(true);
    }
}
