using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] UILoading uiLoading;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneToLoad, string sceneToUnload = null)
    {
        Debug.Log("Load scene: " + sceneToLoad);
        StartCoroutine(Cor_LoadScene(sceneToLoad, sceneToUnload));
    }
    IEnumerator Cor_LoadScene(string sceneToLoad, string sceneToUnload = null)
    {
        uiLoading.LoadNewScene();
        yield return new WaitUntil(() => uiLoading.isDoneLoading);
        
        if (sceneToUnload != null)
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(sceneToUnload);
        }
        else
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
