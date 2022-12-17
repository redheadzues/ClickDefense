using NumbersForIdle;
using UnityEngine;
using System.Numerics;
using System;

public class Testing : MonoBehaviour
{
    private IdleNumber value = new(1, 0);
    private IdleNumber value2 = new(50, 6);

    private int i = 500;
    private float f = 2000.20f;

    private BigInteger big = new(5);
    private IdleNumber idle = new(5);

    private void Start()
    {
    }


    private void TestSpeed()
    {
        BigInteger result = new(1);
        var sBig = DateTime.Now;

        for (int i = 0; i < 10000; i++)
        {
            result += big;
        }
        var eBig = DateTime.Now;
        print(result);


        IdleNumber resultidle = new(1);
        var sIdle = DateTime.Now; ;

        for (int i = 0; i < 10000; i++)
        {
            resultidle += idle;
        }
        var eIdle = DateTime.Now; 


        print($"{resultidle.Value} {resultidle.Degree}");

        TimeSpan tsB = eBig - sBig;
        TimeSpan tsI = eIdle - sIdle;

        print($"Big 10000 iteration {tsB.TotalSeconds}");
        print($"Idle 10000 iteration {tsI.TotalSeconds}");
    }

}
