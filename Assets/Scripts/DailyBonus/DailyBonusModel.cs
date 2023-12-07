using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DailyBonusData", menuName = "Bonus Data", order = 51)]
public class DailyBonusModel : ScriptableObject
{
    public int DayNumber;
    public int GiftSize;
    public bool IsRecieved;
    public bool IsOpened;

    public event Action IsSetRecieving;
    public event Action IsOpening;

    public void SetIsRecieved(bool value)
    {
        IsRecieved = value;
        IsSetRecieving?.Invoke();
    }

    public void SetIsOpened(bool value)
    {
        IsOpened = value;
        IsOpening?.Invoke();
    }
}
