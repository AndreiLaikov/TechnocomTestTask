using UnityEngine;

namespace TechnoApp.Dailybonus
{
    [CreateAssetMenu(fileName = "DailyBonusData", menuName = "Bonus Data", order = 51)]
    public class DailyBonusModel : ScriptableObject
    {
        public int DayNumber;
        public int GiftSize;
        public bool IsOpened;
    }
}
