using TechnoApp.Managers;
using UnityEngine;

public class ProductController : MonoBehaviour
{
    private CurrencyManager manager;
    private ProductModel productModel;

    public void Init(ProductModel model)
    {
        productModel = model;
        manager = CurrencyManager.Instance;
    }

    public void OnItemBuy(int cost)
    {
        if (manager.GetCurrency() < cost)
        {
            Debug.Log("No enough money");//todo show popup "No money"
        }
        else
        {
            manager.AddCurrency(-cost);
            productModel.ChangeIsBought(true);
        }
    }
}
