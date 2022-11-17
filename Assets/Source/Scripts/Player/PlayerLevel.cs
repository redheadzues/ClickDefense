using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private int _value = 1;

    public int Value => _value;

    public void Increase()
    {
        _value++;
    }
}
