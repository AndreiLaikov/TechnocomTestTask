using TechnoApp.Managers;
using TMPro;
using UnityEngine;

public class CurrentCurrencyView : MonoBehaviour
{
    public TMP_Text currencyCount;

    private void Start()
    {
        var instance = CurrencyManager.Instance;
        instance.CurrencyUpdated += CurrencyUpdated;
        currencyCount.text = instance.GetCurrency().ToString();
    }

    private void CurrencyUpdated(int context)
    {
        currencyCount.text = context.ToString();
    }
}
