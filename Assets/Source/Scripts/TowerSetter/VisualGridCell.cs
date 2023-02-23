using System;
using UnityEngine;

public class VisualGridCell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [HideInInspector] public Vector2Int PositionOnGrid;

    private bool _isMouseOver;

    public bool IsMouseOver => _isMouseOver;
    public event Action<VisualGridCell> CellSelected;

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    private void OnMouseDown()
    {
        CellSelected?.Invoke(this);
    }

    private void OnMouseOver()
    {
        _isMouseOver = true;
        _spriteRenderer.color = Color.red;
    }

    private void OnMouseExit()
    {
        _isMouseOver = false;
        _spriteRenderer.color = Color.green;
    }
}
