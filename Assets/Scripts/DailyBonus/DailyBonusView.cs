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

        public DailyBonusModel Model;
        public DailyBonusController Controller;

        private void Start()
        {
            dayNumber.text = PeriodName + Model.DayNumber.ToString();
            giftSize.text = Prefix + Model.GiftSize.ToString();
            CheckStatus();

            dailyBonusButton.onClick.AddListener(()=>GetBonus());
        }

        public void CheckStatus()
        {
            isRecieved.enabled = Model.IsRecieved;
            dailyBonusButton.interactable = Model.IsOpened && !Model.IsRecieved;
        }

        private void GetBonus()
        {
            Controller.OnBonusRecieved(Model.GiftSize);
            Model.IsRecieved = true;
            CheckStatus();
        }
    }
}
