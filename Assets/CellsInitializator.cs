using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CellsInitializator : MonoBehaviour
{
    [SerializeField]private List<Sprite> _sprites;
    
    private bool TryFindValuesPair(Cell[,] cells)
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                foreach(Cell cell in cells)
                {
                    if(cell != cells[i,j] && cell.Value == cells[i, j].Value)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public void InitializeCells(Cell[,] cells)
    {
        List<int> cellsValues = Enumerable.Range(0, (cells.GetLength(0) * cells.GetLength(1))).ToList();
        

        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                int value = Random.Range(0, cells.GetLength(0) * cells.GetLength(1) - 1);
                cells[i, j].SetValue(value);
                if (TryFindValuesPair(cells))
                {
                    cellsValues.Remove(value);
                }
                cells[i, j].SetOpenSprite(_sprites);
            }
        }
    }

    
}
