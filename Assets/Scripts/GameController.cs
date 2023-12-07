using System;
using System.Globalization;
using UnityEngine;
using TechnoApp.Dailybonus;

namespace TechnoApp
{
    public class GameController : Singleton<GameController>
    {
        [Header("DailyBonus")]
        private int daysInRow;
        [SerializeField] private DailyBonusController dailuBonusController;
        public string lastDayPlayed_key = "LastDayPlayed";
        public string daysInRow_key = "DaysInRow";

        private int currentCurrency;

        private void Start()
        {
            CalculateDaysInRow();
        }

        private void CalculateDaysInRow()
        {
            DateTime lastDayPlayed;
            DateTime.TryParse(PlayerPrefs.GetString(lastDayPlayed_key), DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out lastDayPlayed);

            var now = WorldTime.Instance.GetWorldTime();
            var hoursSpan = (now - lastDayPlayed).TotalHours;
            Debug.Log("span " + hoursSpan);
            if (hoursSpan < 24)
                return;

            int.TryParse(PlayerPrefs.GetString(daysInRow_key), out daysInRow);

            Debug.Log("days in prefs " + daysInRow);
            if (hoursSpan > 24 && hoursSpan < 48)
            {
                daysInRow++;
            }
            else if (hoursSpan > 48)
            {
                daysInRow = 0;
            }

            dailuBonusController.ShowUI();
            Debug.Log("after calculate " + daysInRow);
            PlayerPrefs.SetString(daysInRow_key, daysInRow.ToString());
            PlayerPrefs.SetString(lastDayPlayed_key, now.ToString());
        }

        public int GetDaysInRow()
        {
            return daysInRow;
        }
    }
}