using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrencyManager
{
    public static int CurrencyOwned { get; private set; } = 500;

    public static void IncreaseCurrency(int ammount)
    {
        CurrencyOwned += ammount;
    }

    public static void DecreaseCurrency(int ammount)
    {
        CurrencyOwned -= ammount;
    }
}
