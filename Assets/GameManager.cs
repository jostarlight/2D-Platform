using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public LevelInfo[] levelInfos;

    public LevelInfo currentLevel;

    public Dictionary<FruitType, int> currentProgress = new Dictionary<FruitType, int>();


    bool gameOver = false;

    private void Awake()
    {
        instance = this;
        StartGame(0);
    }

    public void StartGame(int levelIndex)
    {
        currentLevel = levelInfos[levelIndex];
        currentProgress.Clear();
    }

    public void GetFruit(FruitType fruitType)
    {
        if (currentProgress.ContainsKey(fruitType))
        {
            currentProgress[fruitType]++;

        }
        else
        {
            currentProgress[fruitType] = 1;

        }
    }

    private void Update()
    {
        if (gameOver)
        {
            return;
        }


        foreach (var progress in currentProgress)
        {
            int target = 0;
            foreach (var fruitInfo in currentLevel.fruitInfos)
            {
                if (fruitInfo.fruitType == progress.Key)
                {
                    target = fruitInfo.count;
                    break;
                }
            }

            if (target < progress.Value)
            {
                GameOver();
                break;
            }
        }
    }

    private void GameOver()
    {
        gameOver = true;
        Debug.Log("over");
    }
}
