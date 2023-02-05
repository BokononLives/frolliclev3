using Frollicle.Core;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusSquarePicker : MonoBehaviour
{
    public GameObject BonusSquare;
    public float MinWaitTime = 3f;
    public float MaxWaitTime = 8f;

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
            DestroyBonusSquares();

            Instantiate(BonusSquare, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), -0.1f), Quaternion.identity);
            LastPickTime = now;
            NextPickTime = GetNextPickTime();
        }
    }

    private DateTime GetNextPickTime()
    {
        return DateTime.Now.AddSeconds(Random.Range(MinWaitTime, MaxWaitTime));
    }

    public void DestroyBonusSquares()
    {
        foreach (var bonusSquare in GetBonusSquares())
        {
            Destroy(bonusSquare);
        }
    }

    private GameObject[] GetBonusSquares()
    {
        return GameObject.FindGameObjectsWithTag(CustomTag.BonusSquare.ToString());
    }
}