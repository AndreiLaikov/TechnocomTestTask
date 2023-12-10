using TechnoApp.Managers;
using UnityEngine;
using UnityEngine.Purchasing;

namespace TechnoApp.Shop
{
    public class IAPButtonController : MonoBehaviour
    {
        public void AddCurrency(Product product)
        {
            CurrencyManager.Instance.AddCurrency((int)product.definition.payout.quantity);
        }
    }
}