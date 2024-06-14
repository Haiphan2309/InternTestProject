using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public float deltaTimeMeteoSpawn;
    public float deltaTimeEnemySpawn;
    public float deltaTimeItemSpawn;
}
