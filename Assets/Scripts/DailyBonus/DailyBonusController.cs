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

        [Header("UiElements")]
        public GameObject DailyBonusUI;
        public GameObject WeeklyBonusUI;
        public ProgressBar progress;
        private GameObject activeUI;

        [Header("Models")]
        [SerializeField] private DailyBonusModel[] dailyBonusModels;

        [Header("Views")]
        [SerializeField] private DailyBonusView[] dailyBonusViews;

        private void Start()
        {
            DaysInRowCalculate();
            UpdateValues();
        }

        private void DaysInRowCalculate()
        {
            DateTime lastDayPlayed;
            DateTime.TryParse(PlayerPrefs.GetString(StaticStrings.LastDayPlayed_key), DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out lastDayPlayed);
            
            var dateNow = GetWorldTime();
            var hoursSpan = (dateNow - lastDayPlayed).TotalHours;
            
            daysInRow = PlayerPrefs.GetInt(StaticStrings.DaysInRow_key);
            recivedCount = PlayerPrefs.GetInt(StaticStrings.RecivedCount_key, -1);

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

            PlayerPrefs.SetInt(StaticStrings.DaysInRow_key, daysInRow);
            PlayerPrefs.SetInt(StaticStrings.RecivedCount_key, recivedCount);
            PlayerPrefs.SetString(StaticStrings.LastDayPlayed_key, dateNow.ToString());
            PlayerPrefs.Save();
            ShowActiveUI();
        }

        private void UpdateValues()
        {
            for (int i = 0; i < dailyBonusViews.Length; i++)
            {
                dailyBonusModels[i].IsOpened = i <= daysInRow;
                dailyBonusModels[i].IsRecieved = i <= recivedCount;
                dailyBonusViews[i].Model = dailyBonusModels[i];
                dailyBonusViews[i].Controller = this;
                dailyBonusViews[i].CheckStatus();
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
            foreach (var model in dailyBonusModels)
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
            PlayerPrefs.SetInt(StaticStrings.RecivedCount_key, recivedCount);
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
                response.Close();

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