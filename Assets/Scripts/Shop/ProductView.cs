using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductView : MonoBehaviour
{
    public TMP_Text Name;
    public string ConditionPrefix = "LV.";
    public TMP_Text Condition;
    public GameObject LockIcon;
    public GameObject IconIsBought;
    public GameObject PriceBlock;
    public TMP_Text Cost;

    [SerializeField] private Button buttonBuy;

    public ProductModel productModel;
    [SerializeField] private ProductController productController;

    private void Start()
    {
        productController.Init(productModel);
        productModel.StateChanged += OnStateChanged;
        buttonBuy.onClick.AddListener(() => productController.OnItemBuy(productModel.ProductCost));

        Init();
    }

    private void OnStateChanged()
    {
        SetElementsState();
    }

    public void Init()
    {
        Name.text = productModel.name;
        Condition.text = ConditionPrefix + productModel.Condition.ToString();
        Cost.text = productModel.ProductCost.ToString();
        SetElementsState();
    }

    public void SetElementsState()
    {
        Condition.enabled = productModel.IsClosed;
        LockIcon.SetActive(productModel.IsClosed);
        PriceBlock.SetActive(!productModel.IsBought);
        IconIsBought.SetActive(productModel.IsBought);
        buttonBuy.interactable = !productModel.IsBought && !productModel.IsClosed;
    }
}
