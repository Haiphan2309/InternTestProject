using System.Collections.Generic;
using UnityEngine;
using System;

namespace GDC.Managers
{
    [Serializable]
    public struct GameData
    {
        public bool IsSaveLoadProcessing;
        public float playerPosX, playerPosY;
        public int hp;

        public void SaveData(Vector2 playerPos, int hp)
        {
            playerPosX = playerPos.x;
            playerPosY = playerPos.y;
            this.hp = hp;
        }
    }
}
