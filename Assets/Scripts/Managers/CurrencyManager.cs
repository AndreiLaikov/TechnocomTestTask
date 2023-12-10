using System;
using UnityEngine;

namespace TechnoApp.Managers
{
    public class CurrencyManager : Singleton<CurrencyManager>
    {
        [SerializeField] private int currentCurrency;
        public event Action<int> CurrencyUpdated;

        private void Start()
        {
            currentCurrency = GetCurrency();
        }

        public int GetCurrency()
        {
            return PlayerPrefs.GetInt(StaticStrings.Currency_key);
        }

        public void AddCurrency(int value)
        {
            currentCurrency += value;
            PlayerPrefs.SetInt(StaticStrings.Currency_key, currentCurrency);

            CurrencyUpdated?.Invoke(currentCurrency);
        }
    }
}
