using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPButtonView : MonoBehaviour
{
    [SerializeField] private string postfix = "$";
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text price;

    public void OnProductFetched(Product product)
    {
        if (title != null)
        {
            title.text = product.metadata.localizedTitle;
        }

        if (price != null)
        {
            price.text = product.metadata.localizedPriceString + postfix;
        }
    }
}


