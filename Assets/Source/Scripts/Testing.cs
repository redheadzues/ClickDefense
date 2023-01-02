using NumbersForIdle;
using UnityEngine;
using System.Numerics;
using System;

public class Testing : MonoBehaviour
{
    private IdleNumber value = new(1, 0);
    private IdleNumber value2 = new(50, 6);

    private int i = 0;
    private float f = 2000.20f;

    private IdleNumber big = new(0);
    private IdleNumber idle = new(5);

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            idle = new(5);
            print(idle);
            idle /= big;
            print(idle);
        }
    }
}
