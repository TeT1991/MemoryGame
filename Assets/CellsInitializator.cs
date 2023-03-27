using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CellsInitializator : MonoBehaviour
{
    [SerializeField]private List<Sprite> _sprites;
    
    public void InitializeCells(ref Cell[,] cells)
    {
        int sameValuesCount = 2;
        List<int> cellsValues = new List<int>();

        for (int i=0; i< sameValuesCount; i++)
        {
            cellsValues.AddRange(Enumerable.Range(0, (cells.GetLength(0) * cells.GetLength(1)) / 2).ToList());
        }

        foreach (Cell cell in cells)
        {
            int randomIndex = Random.Range(0, cellsValues.Count);
            cell.SetValue(cellsValues[randomIndex]);
            cell.SetOpenSprite(_sprites[randomIndex]);
            cellsValues.RemoveAt(randomIndex);
        }
    }
}
