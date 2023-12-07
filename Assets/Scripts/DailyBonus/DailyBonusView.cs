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
        [SerializeField] private Image RecievedCheckmark;

        public DailyBonusModel model;

        public void Start()
        {
            dayNumber.text = PeriodName + model.DayNumber.ToString();
            giftSize.text = Prefix + model.GiftSize.ToString();

            ModelIsOpening();
            ModelIsSetRecieving();

            //dailyBonusButton.onClick.AddListener(()=>GetBonus());
        }

        private void ModelIsOpening()
        {
            dailyBonusButton.interactable = model.IsOpened;
        }

        private void ModelIsSetRecieving()
        {
            RecievedCheckmark.enabled = model.IsRecieved;
            dailyBonusButton.interactable = !model.IsRecieved;
        }

    }
}
