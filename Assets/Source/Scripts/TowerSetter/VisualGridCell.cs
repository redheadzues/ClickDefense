using UnityEngine;

public class VisualGridCell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [HideInInspector] public Vector2 PositionOnGrid;


    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}
