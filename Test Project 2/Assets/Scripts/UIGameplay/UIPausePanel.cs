using GDC.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPausePanel : MonoBehaviour
{
    [SerializeField] Button resumeBtn, saveBtn, loadBtn, nextLevelBtn;
    // Start is called before the first frame update
    void Start()
    {
        resumeBtn.onClick.AddListener(Resume);
        saveBtn.onClick.AddListener(Save);
        loadBtn.onClick.AddListener(Load); 
        nextLevelBtn.onClick.AddListener(NextLevel);
    }

    void Resume()
    {
        gameObject.SetActive(false);
        AllManager.GetInstance().ResumeGame();
    }

    void Save()
    {
        SaveLoadManager.Instance.Save();
    }
    void Load()
    {
        SaveLoadManager.Instance.Load();
        Resume();
    }
    void NextLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            GameManager.Instance.LoadScene("Level2");
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            GameManager.Instance.LoadScene("Level3");
        }
        Resume();
    }
}
