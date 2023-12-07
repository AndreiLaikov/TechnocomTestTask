using UnityEngine;

namespace TechnoApp.Dailybonus
{
    public class DailyBonusController : MonoBehaviour
    {
        public DailyBonusModel[] DailyBonusModels;
        [SerializeField] private DailyBonusView Template;
        private DailyBonusView[] views;

        public int DaysInRow;
        public int RecievedCount;

        public void Start()
        {
            views = new DailyBonusView[DailyBonusModels.Length];

            for (int i = 0; i < DailyBonusModels.Length; i++)
            {
                views[i] = Instantiate(Template, transform);
                views[i].model = DailyBonusModels[i];
            }

            for (int i = 0; i < views.Length; i++)
            {
                views[i].model.SetIsRecieved(i < RecievedCount);
                views[i].model.SetIsOpened(i <= DaysInRow);
            }
        }
    }
}
