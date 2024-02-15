using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public LevelInfo[] levelInfos;
    public LevelInfo currentLevel;
    public int currentLevelIndex;
    public GameObject levelObj;
    public Dictionary<FruitType, int> currentProgress = new Dictionary<FruitType, int>();
    public Transform reborn;
    public Transform player;


    bool gameOver = false;

    private void Awake()
    {
        instance = this;
        Launcher.instance.UICamera.depth = 20;
        UIManager.instance.hidemenu();


        StartGame(0);


    }

    public void StartGame(int levelIndex)
    {
        player.transform.position = reborn.transform.position;
        gameOver = false;

        if (levelObj != null)
        {
            DestroyImmediate(levelObj);
        }

        currentLevel = levelInfos[levelIndex];
        currentLevelIndex = levelIndex;
        currentProgress.Clear();

        levelObj = Instantiate(currentLevel.Level);


        UIManager.instance.showInGame();


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

        UIManager.instance.inGame.setCell();



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
                return;
            }
        }

        if (CheckIsWin())
        {
            Win();

        }

    }

    private bool CheckIsWin()
    {
        foreach (var fruitInfo in currentLevel.fruitInfos)
        {
            if (!currentProgress.ContainsKey(fruitInfo.fruitType))
            {
                return false;
            }
            if (currentProgress[fruitInfo.fruitType] < fruitInfo.count)
            {
                return false;
            }
        }
        return true;
    }

    private void Win()
    {
        gameOver = true;

        if (currentLevelIndex == levelInfos.Length - 1)
        {
            UIManager.instance.showwin();
            StartCoroutine(back());

        }
        else
        {
            UIManager.instance.showFinal();
            StartCoroutine(nextlevel());
        }

    }

    private IEnumerator nextlevel()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.hideFinal();
        StartGame(currentLevelIndex + 1);
    }

    private void GameOver()
    {
        gameOver = true;
        UIManager.instance.showfail();
        StartCoroutine(back());

    }

    private IEnumerator back()
    {
        yield return new WaitForSeconds(2f);
        UIManager.instance.hidefail();
        UIManager.instance.hidewin();

        UIManager.instance.hideingame();
        UIManager.instance.showmenu();

        Launcher.instance.UICamera.depth = -1;

        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
