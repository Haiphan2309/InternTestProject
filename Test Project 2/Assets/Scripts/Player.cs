using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player _instance { get; private set; }
    [SerializeField] private float speed;
    [SerializeField] private float fireRate = 0.5f;
    public int HP = 10;
    [SerializeField] private GameObject vfxHit;
    public int bulletId;
    private bool isDead=false;
    private float lastFireTime;

    [SerializeField] Animator anim;
    [SerializeField] ParticleSystem vfxFire;

    public static Player GetInstance()
    {
        if (_instance == null)
        {
            _instance = GameObject.FindAnyObjectByType<Player>();
        }
        return _instance;
    }

    private void Start()
    {
        UIManager.GetInstance().uiHpSlider.changeMaxHpEvent?.Invoke(this, 10);
        UIManager.GetInstance().uiHpSlider.changeHpEvent?.Invoke(this, HP);
        bulletId = -1;
    }

    private void Update()
    {
        Move();     
    }
    private void LateUpdate() {
        if(isDead){
           Destroy(gameObject);
        }
    }

    
    private void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        anim.SetFloat("Steering", xAxis);

        if (Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
        }

        transform.Translate(new Vector2(xAxis, yAxis) * speed * Time.deltaTime);
    }

    private void FireWeapon()
    {
        vfxFire.Play();
        anim.SetTrigger("Fire");
        float currentTime = Time.time;

        if (currentTime - lastFireTime >= fireRate)
        {
            lastFireTime = currentTime;
            AllManager.GetInstance().bulletManager.SpawnBullet(transform.position + Vector3.up * 1.2f,bulletId);
        }
    }
    public void OnHit()
    {
        ChangeHp(-1);
    }
    public void SetHp(int value)
    {
        HP = value;
        UIManager.GetInstance().uiHpSlider.changeHpEvent?.Invoke(this, HP);
    }
    void ChangeHp(int value)
    {
        HP += value;
        if (HP <= 0)
        {
            HP = 0;
            isDead = true;
            Debug.Log("Game Over");
        }

        Instantiate(vfxHit, transform.position, Quaternion.identity);
        UIManager.GetInstance().uiHpSlider.changeHpEvent?.Invoke(this, HP);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) return;

        if (other.CompareTag("Item"))
        {
            Debug.Log("Interact item");
            int id = other.gameObject.GetInstanceID();
            AllManager.GetInstance().itemManager.OnLootItem(id);
        }
        else
        {
            int id = gameObject.GetInstanceID();
            Debug.Log("Player Collision");
            AllManager.GetInstance().meteorManager.ProcessCollision(id);
        }
        
    }

    public void LootItem(ItemInfo itemInfo)
    {
        Debug.Log("loot "+itemInfo.typeId);
        bulletId = itemInfo.typeId;
    }
}