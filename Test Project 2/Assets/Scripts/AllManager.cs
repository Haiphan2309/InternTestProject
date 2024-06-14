using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AllManager : MonoBehaviour
{
    public static AllManager _instance { get; private set; }

    public BulletManager bulletManager;
    public MeteorManager meteorManager;
    public ItemManager itemManager;
    [SerializeField] private BulletConfig basicBulletConfig;
    [SerializeField] private MeteorConfig meteorConfig;
    public ItemConfig itemBeamConfig, itemBurstConfig;
    public BulletConfig burstConfig;
    public BulletConfig beamConfig;
    public GameObject vfxHit;

    [SerializeField] LevelConfig levelConfig;

    public int score = 0;

    public static AllManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = GameObject.FindAnyObjectByType<AllManager>();
        }
        return _instance;
    }

    private void Start()
    {
        bulletManager = new BulletManager();
        bulletManager.basicBulletConfig = basicBulletConfig;
        bulletManager.beamBulletConfig = beamConfig;
        bulletManager.burstBulletConfig = burstConfig;
        meteorManager = new MeteorManager();
        itemManager = new ItemManager();
        itemManager.itemBeamConfig = itemBeamConfig;
        itemManager.itemBurstConfig = itemBurstConfig;
        
        meteorManager.Setup(meteorConfig._meteorPrefab.transform,meteorConfig.enemyPrefab.transform);
        SetupLevel(levelConfig);

        UIManager.GetInstance().changeScoreEvent?.Invoke(this, 0);
    }
    void SetupLevel(LevelConfig config)
    {
        StartCoroutine(Cor_SpawnMeteo(config.deltaTimeMeteoSpawn));
        StartCoroutine(Cor_SpawnEnemy(config.deltaTimeEnemySpawn));
        StartCoroutine(Cor_SpawnItem(config.deltaTimeItemSpawn));
    }

    private void Update()
    {
        bulletManager.MyUpdate();
        meteorManager.MyUpdate();
        itemManager.MyUpdate();
        // bulletManager.LateUpdate();

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    void LateUpdate()
    {
        bulletManager.LateUpdate();
        meteorManager.LateUpdate();
        itemManager.LateUpdate();
    }
    IEnumerator Cor_SpawnMeteo(float sec)
    {
        yield return new WaitForSeconds(sec);
        meteorManager.SawpnMeteo();
        StartCoroutine(Cor_SpawnMeteo(sec));
    }
    IEnumerator Cor_SpawnEnemy(float sec)
    {
        yield return new WaitForSeconds(sec);
        meteorManager.SpawnEnemy();
        StartCoroutine(Cor_SpawnEnemy(sec));
    }
    
    IEnumerator Cor_SpawnItem(float sec)
    {
        yield return new WaitForSeconds(sec);
        itemManager.SpawnItem();
        StartCoroutine(Cor_SpawnItem(sec));
    }

    public void PauseGame()
    {
        UIManager.GetInstance().ShowPausePanel();
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
