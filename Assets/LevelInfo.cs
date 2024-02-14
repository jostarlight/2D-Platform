using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newLevelInfo", menuName = "Data/new Level Info")]

public class LevelInfo : ScriptableObject
{
    public GameObject Level;
    public FruitInfo[] fruitInfos;
}

[Serializable]
public class FruitInfo
{
    public FruitType fruitType;
    public int count;
}