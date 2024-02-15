using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI textMeshProUGUI;


    public void setData(FruitInfo fruitInfo)
    {
        image.sprite = fruitInfo.sprite;
        int count = 0;
        if (GameManager.instance.currentProgress.ContainsKey(fruitInfo.fruitType))
        {
            count = GameManager.instance.currentProgress[fruitInfo.fruitType];
        }
        textMeshProUGUI.text = count + "/" + fruitInfo.count;
    }
}
