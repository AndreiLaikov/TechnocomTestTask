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

        [Header("Currency")]
        private int currentCurrency;
        public string currency_key = "CurrentCurrency";
        public event Action<int> CurrencyRecieved;

        private void Start()
        {
            CalculateDaysInRow();
            GetCurrency();
        }

        public void GetCurrency()
        {
            currentCurrency = PlayerPrefs.GetInt(currency_key);
        }

        public void AddCurrency(int value)
        {
            currentCurrency += value;
            PlayerPrefs.SetInt(currency_key, currentCurrency);

            CurrencyRecieved?.Invoke(currentCurrency);
        }

        private void CalculateDaysInRow()
        {
            DateTime lastDayPlayed;
            DateTime.TryParse(PlayerPrefs.GetString(lastDayPlayed_key), DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out lastDayPlayed);

            var dateNow = WorldTime.Instance.GetWorldTime();
            var hoursSpan = (dateNow - lastDayPlayed).TotalHours;

            if (hoursSpan < 24)
                return;

            daysInRow = PlayerPrefs.GetInt(daysInRow_key);

            if (hoursSpan > 24 && hoursSpan < 48)
            {
                daysInRow++;
            }
            else if (hoursSpan > 48)
            {
                daysInRow = 0;
            }

            PlayerPrefs.SetInt(daysInRow_key, daysInRow);
            PlayerPrefs.SetString(lastDayPlayed_key, dateNow.ToString());

            dailuBonusController.ShowUI();
        }

        public int GetDaysInRow()
        {
            return daysInRow;
        }
    }
}