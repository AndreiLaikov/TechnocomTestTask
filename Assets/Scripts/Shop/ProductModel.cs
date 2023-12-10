using System;
using UnityEngine;

namespace TechnoApp.Shop
{
    [CreateAssetMenu(fileName = "ProductData", menuName = "Product Data", order = 51)]
    public class ProductModel : ScriptableObject
    {
        public string ProductName;
        public int ProductCost;
        public TypeOfProduct ProductType;
        public int Condition;
        public bool IsClosed;
        public bool IsBought;

        public event Action StateChanged;

        public enum TypeOfProduct
        {
            Skin,
            Location
        }

        public void ChangeIsClosed(bool value)
        {
            IsClosed = value;
            StateChanged?.Invoke();
        }

        public void ChangeIsBought(bool value)
        {
            IsBought = value;
            StateChanged?.Invoke();
        }
    }
}