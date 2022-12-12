using NumbersForIdle;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private IdleNumber value = new(10, 3);
    private IdleNumber value2 = new(50, 6);

    private int i = 500;
    private float f = 2000.20f;

    private void Start()
    {
        //print(value.Value);
        //print(value.Degree);

        value /= value2;

        print(value.Value);
        print(value.Degree);
    }
        
}
