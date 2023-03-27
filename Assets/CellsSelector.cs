using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CellsSelector : MonoBehaviour
{
    public UnityEvent CellSelected;

    private List<Cell> _selectedCells = new List<Cell>();
    private bool _selectionIsAviable = true;

    public int GetSelectedCellsCount()
    {
        return _selectedCells.Count;
    }

    public Cell GetSelectedCell(int index)
    {
        Debug.Log("GetSelectedCell " + _selectedCells.Count);
        return _selectedCells[index];
    }

    public void TrySetSelectedCell(Cell cell)
    {
        if (cell._isOpen == false && _selectedCells.Contains(cell) == false) 
        {
            _selectedCells.Add(cell);
            CellSelected.Invoke();
        }
    }

    public void ClearSelection()
    {
        _selectedCells.Clear(); 
    }

    public void SetSelectionIsAviable()
    {
        _selectionIsAviable = true;   
    }

    public void SetSelectionIsNotAviable()
    {
        _selectionIsAviable = false;
    }
}
