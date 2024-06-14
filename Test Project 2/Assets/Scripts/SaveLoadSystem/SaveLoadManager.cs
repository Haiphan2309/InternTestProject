using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GDC.Managers
{
    public class SaveLoadManager : MonoBehaviour
    {
        static public SaveLoadManager Instance { get; private set; }
        public GameData GameData;

        //[SerializeField] SO_Item so_defaultArmor, so_defaultShoe;

        //public SaveLoadSystem saveLoadSystem;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public void Save()
        {
            GameData.SaveData(Player.GetInstance().transform.position, Player.GetInstance().HP);
            SaveLoadSystem.SaveData(GameData);
            
            Debug.Log("SAVE");
        }
        public void Load()
        {
            SaveLoadSystem.LoadData();
            Debug.Log("Load");
            SetupData();
        }
        void SetupData()
        {
            Player.GetInstance().transform.position = new Vector2(GameData.playerPosX, GameData.playerPosY);
            Player.GetInstance().SetHp(GameData.hp);
        }
    }
}
