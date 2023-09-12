using System;
using System.Collections.Generic;
using Common.UI.Extended.Buttons;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Purchases;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Shop.UI
{
    [DisallowMultipleComponent]
    public class ShopEntry : MonoBehaviour, IShopEntry
    {
        [SerializeField] private ProductLink[] _primaryProducts;
        
        [SerializeField] private Image _image;
        [SerializeField] private ExtendedButton _buyButton;
        
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private GameObject _currencyImage;
        [SerializeField] private GameObject _adImage;
        
        private IProductLink _current;

        public IReadOnlyList<IProductLink> PrimaryProducts => _primaryProducts;
        
        public event Action<IProductLink> BuyRequested;
        
        private void OnEnable()
        {
            _buyButton.Clicked += OnBuyClicked;
        }
        
        private void OnDisable()
        {
            _buyButton.Clicked -= OnBuyClicked;
        }
        
        public async UniTask Show(IProductLink productLink)
        {
            _current = productLink;
            _image.sprite = productLink.ShopIcon;

            var description = productLink.Description != null ? productLink.Description.GetText() : string.Empty;

            _descriptionText.text = description;

            switch (productLink.PaymentMethod)
            {
                case PaymentMethod.Ad:
                    _priceText.gameObject.SetActive(false);
                    _currencyImage.SetActive(false);
                    
                    _adImage.SetActive(true);
                    break;
                case PaymentMethod.Currency:
                    _priceText.gameObject.SetActive(true);
                    _priceText.text = productLink.Price.ToString();
                    _currencyImage.SetActive(true);
                    
                    _adImage.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
            
        private void OnBuyClicked()
        {
            Debug.Log("On clicked");
            if (_current == null)
                throw new NullReferenceException("No product attached");
            
            BuyRequested?.Invoke(_current);
        }
    }
}