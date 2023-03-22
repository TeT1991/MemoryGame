using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private FieldCreator _fieldCreator;
    [SerializeField] private CellsInitializator _cellsInitializator;
    private Cell[,] _cells;

    private void Start()
    {
        _cells = _fieldCreator.CreateField();
        _cellsInitializator.InitializeCells(_cells);
    }
}
