using System;
using System.Globalization;
using System.Net;
using UnityEngine;

namespace TechnoApp.Dailybonus
{
    public class DailyBonusController : MonoBehaviour
    {
        private bool isShownToday;
        private int daysInRow;
        private string lastDayPlayed_key = "LastDayPlayed";
        private string daysInRow_key = "DaysInRow";

        public event Action<int> BonusRecieved;

        [Header("UiElements")]
        public GameObject DailyBonusUI;
        public GameObject WeeklyBonusUI;
        public ProgressBar progress;
        private GameObject activeUI;

        [Header("Models")]
        [SerializeField] private DailyBonusModel[] DailyBonusModels;
        [SerializeField] private DailyBonusModel WeeklyBonusModel;

        [Header("Views")]
        [SerializeField] private Transform dailyBonusesParent;
        [SerializeField] private DailyBonusView Template;
        [SerializeField] private DailyBonusView WeeklyBonusView;

        private void Start()
        {
            DaysInRowCalculate();
            PanelsCreate();
            ShowUI();
        }

        private void DaysInRowCalculate()
        {
            DateTime lastDayPlayed;
            DateTime.TryParse(PlayerPrefs.GetString(lastDayPlayed_key), DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out lastDayPlayed);

            var dateNow = GetWorldTime();
            var hoursSpan = (dateNow - lastDayPlayed).TotalHours;

            if (hoursSpan < 24)
            {
                isShownToday = true;
                return;
            }

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
        }

        private void PanelsCreate()
        {
            for (int i = 0; i < DailyBonusModels.Length; i++)
            {
                DailyBonusModels[i].IsOpened = i <= daysInRow;
                var obj = Instantiate(Template, dailyBonusesParent);
                obj.model = DailyBonusModels[i];
                obj.controller = this;
            }

            WeeklyBonusModel.IsOpened = true;
            WeeklyBonusView.model = WeeklyBonusModel;
            WeeklyBonusView.controller = this;

            progress.SetValues(daysInRow);
        }

        private void ShowUI()
        {
            if (isShownToday)
                return;

            if (daysInRow < 6)
            {
                DailyBonusUI.SetActive(true);
                activeUI = DailyBonusUI;
            }
            else
            {
                WeeklyBonusUI.SetActive(true);
                activeUI = WeeklyBonusUI;
                daysInRow = 0;
                PlayerPrefs.SetInt(daysInRow_key, daysInRow);
            }
        }

        public void OnBonusRecieved(int value)
        {
            activeUI.SetActive(false);
            BonusRecieved?.Invoke(value);
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