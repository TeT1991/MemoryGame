using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCreator : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;


    [SerializeField] private int _size = 8;
    private int _dimensionSize;
    [SerializeField] private float spacing;

    public Cell[,] CreateField()
    {
        Cell[,] cells = new Cell[_dimensionSize,_dimensionSize];

        for (int i = 0; i < _dimensionSize; i++)
        {
            for (int j = 0; j < _dimensionSize; j++)
            {
                Vector2 cellPosition = new Vector2(transform.position.x + spacing + i, transform.position.y + spacing + j);
                Cell cell = Instantiate(_cellPrefab, transform);
                cells[i, j] = cell;
                cell.transform.position = cellPosition;
            }
        }

        return cells;
    }

    private void Start()
    {
        _dimensionSize = _size / 2;
        SetFieldPosition(); 
    }

    private void SetFieldPosition()
    {
        int xPosition = (_size / 2) / 2;
        int yPosition = (_size / 2) / 2;
        float offset = 0;
        if (_dimensionSize % 2 == 0)
        {
            offset = _cellPrefab.transform.localScale.x / 2;
        }
        transform.position = new Vector2(-xPosition + offset, -yPosition + offset);
    }
}
