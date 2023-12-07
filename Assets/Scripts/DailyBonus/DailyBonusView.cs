using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TechnoApp.Dailybonus
{
    public class DailyBonusView : MonoBehaviour
    {
        public string PeriodName = "Day";
        public string Prefix = "x";
        [SerializeField] private TextMeshProUGUI dayNumber;
        [SerializeField] private TextMeshProUGUI giftSize;
        [SerializeField] private Button dailyBonusButton;

        public DailyBonusModel model;
        public DailyBonusController controller;

        public void Start()
        {
            dayNumber.text = PeriodName + model.DayNumber.ToString();
            giftSize.text = Prefix + model.GiftSize.ToString();
            dailyBonusButton.interactable = model.IsOpened;

            dailyBonusButton.onClick.AddListener(()=>GetBonus());
        }

        private void GetBonus()
        {
            controller.CloseUI();
            controller.OnBonusRecieved(model.GiftSize);
        }
    }
}
