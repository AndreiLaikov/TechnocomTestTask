using System;
using System.Globalization;
using System.Net;
using TechnoApp.Managers;
using UnityEngine;

namespace TechnoApp.Dailybonus
{
    public class DailyBonusController : MonoBehaviour
    {
        private const int daysInWeek = 7;
        private int daysInRow;
        private int recivedCount;
        private string lastDayPlayed_key = "LastDayPlayed";
        private string daysInRow_key = "DaysInRow";
        private string recivedCount_key = "RecivedCount";

        [Header("UiElements")]
        public GameObject DailyBonusUI;
        public GameObject WeeklyBonusUI;
        public ProgressBar progress;
        private GameObject activeUI;

        [Header("Models")]
        [SerializeField] private DailyBonusModel[] DailyBonusModels;

        [Header("Views")]
        [SerializeField] private DailyBonusView[] DailyBonusViews;

        private void Start()
        {
            DaysInRowCalculate();
            UpdateValues();
        }

        private void DaysInRowCalculate()
        {
            DateTime lastDayPlayed;
            DateTime.TryParse(PlayerPrefs.GetString(lastDayPlayed_key), DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out lastDayPlayed);

            var dateNow = GetWorldTime();
            var hoursSpan = (dateNow - lastDayPlayed).TotalHours;
            daysInRow = PlayerPrefs.GetInt(daysInRow_key);
            recivedCount = PlayerPrefs.GetInt(recivedCount_key, -1);

            if (hoursSpan < 24)
            {
                return;
            }

            if (hoursSpan > 24 && hoursSpan < 48)
            {
                daysInRow++;
                if (daysInRow >= daysInWeek)
                {
                    ResetValues();
                }
            }
            else if (hoursSpan > 48)
            {
                ResetValues();
            }

            PlayerPrefs.SetInt(daysInRow_key, daysInRow);
            PlayerPrefs.SetInt(recivedCount_key, recivedCount);
            PlayerPrefs.SetString(lastDayPlayed_key, dateNow.ToString());
            PlayerPrefs.Save();
            ShowActiveUI();
        }

        private void UpdateValues()
        {
            for (int i = 0; i < DailyBonusViews.Length; i++)
            {
                DailyBonusModels[i].IsOpened = i <= daysInRow;
                DailyBonusModels[i].IsRecieved = i <= recivedCount;
                DailyBonusViews[i].model = DailyBonusModels[i];
                DailyBonusViews[i].controller = this;
                DailyBonusViews[i].CheckStatus();
            }

            progress.SetValues(daysInRow);
        }

        private void ResetValues()
        {
            daysInRow = 0;
            recivedCount = -1;
            ResetModels();
        }

        private void ResetModels()
        {
            foreach (var model in DailyBonusModels)
            {
                model.IsOpened = false;
                model.IsRecieved = false;
            }
        }

        public void ShowActiveUI()
        {
           if (daysInRow < daysInWeek - 1)
            {
                activeUI = DailyBonusUI;
            }
            else
            {
                activeUI = WeeklyBonusUI;
            }

            activeUI.SetActive(true);
        }

        public void OnBonusRecieved(int value)
        {
            recivedCount++;
            PlayerPrefs.SetInt(recivedCount_key, recivedCount);
            PlayerPrefs.Save();
            activeUI.SetActive(false);
            CurrencyManager.Instance.AddCurrency(value);
        }

        private DateTime GetWorldTime()
        {
            try
            {
                var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.google.com");
                var response = myHttpWebRequest.GetResponse();
                string todaysDates = response.Headers["date"];
                return DateTime.ParseExact(todaysDates,
                                           "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                                           CultureInfo.InvariantCulture.DateTimeFormat,
                                           DateTimeStyles.AssumeUniversal);
            }
            catch
            {
                Debug.LogWarning("No internet connection");
                return DateTime.Now;//todo change to show pop-up "No internet" or don't show DailyBonus View
            }
        }
    }
}