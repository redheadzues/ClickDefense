using UnityEngine;

public class RendererColorSwitcher : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;


    private void OnMouseOver()
    {
        _renderer.color = Color.red;
    }

    private void OnMouseExit()
    {
        _renderer.color = Color.green;
    }
}
