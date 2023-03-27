using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Color _standartColor;
    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _underCursorColor;
    

    private CellsSelector _cellsSelector;

    private SpriteRenderer _spriteRenderer;
    private Sprite _closeSprite;
    private Sprite _openSprite;

    public int Value { get; private set; } 
    public bool _isOpen { get; private set; }


    private void Start()
    {
        _cellsSelector = FindObjectOfType<CellsSelector>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _closeSprite = _spriteRenderer.sprite;
    }

    public void SetValue(int value)
    {
        Value = value;
    }

    public void SetOpenSprite(Sprite sprite)
    {
        _openSprite = sprite;
    }

    private void OnMouseDown()
    {
        if(_isOpen == false)
        {
            _cellsSelector.TrySetSelectedCell(this);
            Debug.Log("CLICK");
            SetColor(_selectedColor);
            
        }
    }

    private void OnMouseOver()
    {
        if(_isOpen == false)
        {
            SetColor(_underCursorColor);
        }
    }

    private void OnMouseExit()
    {
        SetColor(_standartColor);
    }

    private void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    public void Open()
    {
        _isOpen = true;
        _spriteRenderer.sprite = _openSprite;
    }

    public void Close()
    {
        _isOpen = false;
        _spriteRenderer.sprite = _closeSprite;
    }
}
