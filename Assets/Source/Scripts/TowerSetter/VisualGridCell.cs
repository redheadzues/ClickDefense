using System;
using UnityEngine;

public class VisualGridCell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [HideInInspector] public Vector2Int PositionOnGrid;

    public event Action<Vector2Int> CellSelected; 

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    private void OnMouseDown()
    {
        CellSelected?.Invoke(PositionOnGrid);
    }
}
