using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private FieldCreator _fieldCreator;
    [SerializeField] private CellsInitializator _cellsInitializator;
    [SerializeField] private CellsSelector _cellsSelector;
    [SerializeField] private CellsFliper _cellsFliper;
    [SerializeField] private float _showPicturesTime;
    private Cell[,] _cells;

    private void Start()
    {
        _cells = _fieldCreator.CreateField();
        _cellsInitializator.InitializeCells(ref _cells);
        _cellsSelector.CellSelected.AddListener(StartFlipping);
        _cellsSelector.CellSelected.AddListener(TryFindCellPair);   
    }

    private void StartFlipping()
    {
        List<Cell> cells = new List<Cell>();
        int cellsCount = _cellsSelector.GetSelectedCellsCount();
        Debug.Log("STARTFLIPPING " + _cellsSelector.GetSelectedCellsCount());
        //cells.Add(_cellsSelector.GetSelectedCell(cellsCount - 1));
        _cellsFliper.FlipCells(cells);
    }

    private void Update()
    {
        Debug.Log(_cellsSelector.GetSelectedCellsCount());
    }

    private void TryFindCellPair()
    {
        StartCoroutine(ShowPicturesTime());
    }

    private IEnumerator ShowPicturesTime()
    {
        yield return new WaitForSeconds(_showPicturesTime);

        _cellsSelector.ClearSelection();
        StartFlipping();
    }


    //Переделать СтартФлиппинг на что-то типа Старт Опенинг. Сделать Старт Клозинг.
}
