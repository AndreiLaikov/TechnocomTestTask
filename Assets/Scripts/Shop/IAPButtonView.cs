using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPButtonView : MonoBehaviour
{
    [SerializeField] private string pricePostfix = "$";
    [SerializeField] private string quantityPrefix = "x";
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text price;
    [SerializeField] private TMP_Text quantity;

    public void OnProductFetched(Product product)
    {
        if (title != null)
        {
            title.text = product.metadata.localizedTitle;
        }

        if (price != null)
        {
            price.text = product.metadata.localizedPriceString + pricePostfix;
        }

        if (quantity != null)
        {
            quantity.text = quantityPrefix + product.definition.payout.quantity.ToString();
        }
    }
}


