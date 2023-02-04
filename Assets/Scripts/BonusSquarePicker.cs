using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusSquarePicker : MonoBehaviour
{
    public GameObject BonusSquare;
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
            Instantiate(BonusSquare, new Vector3(0.5f, 0.5f, -0.1f), Quaternion.identity);
            LastPickTime = now;
            NextPickTime = GetNextPickTime();
        }
    }

    private DateTime GetNextPickTime()
    {
        return DateTime.Now.AddSeconds(Random.Range(MinWaitTime, MaxWaitTime));
    }
}