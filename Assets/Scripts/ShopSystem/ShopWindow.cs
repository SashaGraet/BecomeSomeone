using System;
using System.Collections.Generic;
using InputSystem;
using ServiceLocatorSystem;
using UnityEngine;

namespace ShopSystem
{
    public class ShopWindow : MonoBehaviour, IService
    {
        [SerializeField] private List<ProductData> products;
        [SerializeField] private GameObject productPrefab;
        [SerializeField] private Transform productsPlace;
        
        private void Awake()
        {
            foreach (var product in products)
            {
                Instantiate(productPrefab, productsPlace).GetComponent<Product>().Initialize(product);
            }
            
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);   
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}