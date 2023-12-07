using UnityEngine;

namespace TechnoApp.Dailybonus
{
    public class DailyBonusController : MonoBehaviour
    {
        public GameObject DailyBonusCanvas;
        [SerializeField] private DailyBonusModel[] DailyBonusModels;
        [SerializeField] private DailyBonusView Template;
        private DailyBonusView[] views;
        

        private void Start()
        {
            views = new DailyBonusView[DailyBonusModels.Length];
            CreatePanel();
        }

        private void CreatePanel()
        {
            int daysInRow = GameController.Instance.GetDaysInRow();

            for (int i = 0; i < DailyBonusModels.Length; i++)
            {
                views[i] = Instantiate(Template, transform);
                views[i].model = DailyBonusModels[i];
                views[i].controller = this;
            }

            for (int i = 0; i < views.Length; i++)
            {
                views[i].model.IsOpened = i <= daysInRow;
            }
        }

        public void ShowUI()
        {
            DailyBonusCanvas.SetActive(true);
        }

        public void CloseUI()
        {
            DailyBonusCanvas.SetActive(false);
        }

    }
}
