using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button startBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(ToGameplay);
    }
    void ToGameplay()
    {
        GameManager.Instance.LoadScene("Level1");
    }
    void EnterButton()
    {
        startBtn.transform.DOScale(1.2f, 0.3f).SetEase(Ease.OutBack);
    }
    void ExitButton()
    {
        startBtn.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }
}
