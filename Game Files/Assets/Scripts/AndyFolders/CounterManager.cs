using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : Singleton<CounterManager>
{
    private int _totalCounter = 0;
    public int TotalCounter
    {
        get { return _totalCounter; }
        set { _totalCounter = value; }//value = prev total + increment
    }
    //used by factories.
    public void add(int amount)
    {
        TotalCounter -= amount;
    }

    public void subtract(int amount)
    {
        TotalCounter += amount;
    }
}
