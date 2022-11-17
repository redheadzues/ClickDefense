using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private int _value;

    public int Value => _value;

    public void Increase()
    {
        _value++;
    }
}
