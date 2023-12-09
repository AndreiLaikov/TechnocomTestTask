using System;
using UnityEngine;

namespace TechnoApp.Managers
{
    public class CurrencyManager : Singleton<CurrencyManager>
    {
        [SerializeField] private int currentCurrency;
        public string currency_key = "CurrentCurrency";
        public event Action<int> CurrencyUpdated;

        private void Start()
        {
            currentCurrency = GetCurrency();
        }

        public int GetCurrency()
        {
            return PlayerPrefs.GetInt(currency_key);
        }

        public void AddCurrency(int value)
        {
            currentCurrency += value;
            PlayerPrefs.SetInt(currency_key, currentCurrency);
            Debug.Log("Currency add " + value);

            CurrencyUpdated?.Invoke(currentCurrency);
        }
    }
}
