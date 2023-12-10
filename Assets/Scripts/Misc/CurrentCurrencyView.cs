using TechnoApp.Managers;
using TMPro;
using UnityEngine;

namespace TechnoApp.Misc
{
    public class CurrentCurrencyView : MonoBehaviour
    {
        public TMP_Text CurrencyCount;

        private void Start()
        {
            var instance = CurrencyManager.Instance;
            instance.CurrencyUpdated += CurrencyUpdated;
            CurrencyCount.text = instance.GetCurrency().ToString();
        }

        private void CurrencyUpdated(int context)
        {
            CurrencyCount.text = context.ToString();
        }
    }
}