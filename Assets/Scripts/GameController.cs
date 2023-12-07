using System;
using UnityEngine;

namespace TechnoApp
{
    public class GameController : MonoBehaviour
    {
        [Header("Currency")]
        [SerializeField]private int currentCurrency;
        public string currency_key = "CurrentCurrency";
        //public event Action<int> CurrencyUpdated;
        public Dailybonus.DailyBonusController controller;

        private void Start()
        {
            GetCurrency();
            controller.BonusRecieved += AddCurrency;
        }

        [ContextMenu("Read")]
        public void GetCurrency()
        {
            currentCurrency = PlayerPrefs.GetInt(currency_key);
            Debug.Log(currentCurrency);
        }

        public void AddCurrency(int value)
        {
            currentCurrency += value;
            PlayerPrefs.SetInt(currency_key, currentCurrency);
            Debug.Log("Currency add "+ value);
           // CurrencyUpdated?.Invoke(currentCurrency);
        }

    }
}