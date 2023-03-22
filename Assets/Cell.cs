using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Sprite _closeSprite;
    private Sprite _openSprite;

    public int Value { get; private set; }  
    private bool _isOpen;


    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _closeSprite = _spriteRenderer.sprite;
    }

    public void SetValue(int value)
    {
        Value = value;
        Debug.Log("!!!!");
    }

    public void SetOpenSprite(List<Sprite> sprites)
    {
        _openSprite = sprites[Value];
    }

    private void OnMouseDown()
    {
        Debug.Log(Value);
    }
}
