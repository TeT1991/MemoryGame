using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsFliper : MonoBehaviour
{
    public void FlipCells(List<Cell> cells)
    {
        Debug.Log("FlipCell");
        int openedeCellsCount = 0;

        foreach (Cell cell in cells)
        {
            if (cell._isOpen == false)
            {
                cell.Open();
                openedeCellsCount++;
            }
            else
            {
                openedeCellsCount++;
            }
        }

        //if (openedeCellsCount == cells.Count)
        //{
        //    foreach (Cell cell in cells)
        //    {
        //        cell.Close();
        //    }
        //}
    }
}
