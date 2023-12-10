using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TechnoApp.Dailybonus
{
    public class DailyBonusView : MonoBehaviour
    {
        public string PeriodName = "DAY";
        public string Prefix = "x";
        [SerializeField] private TMP_Text dayNumber;
        [SerializeField] private TMP_Text giftSize;
        [SerializeField] private Button dailyBonusButton;
        [SerializeField] private Image isRecieved;

        public DailyBonusModel model;
        public DailyBonusController controller;

        private void Start()
        {
            dayNumber.text = PeriodName + model.DayNumber.ToString();
            giftSize.text = Prefix + model.GiftSize.ToString();
            CheckStatus();

            dailyBonusButton.onClick.AddListener(()=>GetBonus());
        }

        public void CheckStatus()
        {
            isRecieved.enabled = model.IsRecieved;
            dailyBonusButton.interactable = model.IsOpened && !model.IsRecieved;
        }

        private void GetBonus()
        {
            controller.OnBonusRecieved(model.GiftSize);
            model.IsRecieved = true;
            CheckStatus();
        }
    }
}
