using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameView : MonoBehaviour
{

    public GameObject cell;
    public List<Cell> cells;
    private void Awake()
    {
        cells = new List<Cell>();
    }
    public void onShow()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            DestroyImmediate(cells[i].gameObject);
        }

        cells.Clear();


        var curr = GameManager.instance.currentLevel.fruitInfos;
        for (int i = 0; i < curr.Length; i++)
        {
            cells.Add(Instantiate(cell, cell.transform.parent).GetComponent<Cell>());
        }

        cell.SetActive(false);

        setCell();
    }

    public void setCell()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].gameObject.SetActive(true);
            cells[i].setData(GameManager.instance.currentLevel.fruitInfos[i]);
        }
    }
}
