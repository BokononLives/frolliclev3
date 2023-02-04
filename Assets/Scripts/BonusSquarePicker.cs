using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusSquarePicker : MonoBehaviour
{
    public float MinWaitTime = 3f;
    public float MaxWaitTime = 15f;

    private DateTime LastPickTime = DateTime.MinValue;
    private DateTime NextPickTime = DateTime.MinValue;

    void Start()
    {
        LastPickTime = DateTime.Now;
        NextPickTime = GetNextPickTime();
    }

    void Update()
    {
        var now = DateTime.Now;
        if (now >= NextPickTime)
        {
            Debug.Log("Pick a winner");
            LastPickTime = now;
            NextPickTime = GetNextPickTime();
        }
    }

    private DateTime GetNextPickTime()
    {
        return DateTime.Now.AddSeconds(Random.Range(MinWaitTime, MaxWaitTime));
    }
}