using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopIndicator : MonoBehaviour
{
    [SerializeField] private GameObject _menuIndicator;
    [SerializeField] private GameObject _shopIndicator;
    [SerializeField] private Menue _menue;
    //[SerializeField] private MoneyHolder _moneyHolder;
    //[SerializeField] private List<BikeUpgradeColorLoader> _collors;
    //[SerializeField] private List<BikeUpgradeLoader> _wheels;

    private List<int> _prices = new List<int>();
    private bool _canBuy = false;

    private void OnEnable()
    {
        _menue.HidedMenue += OnHide;
        //_moneyHolder.BalanceChanged += OnBalnceChanged;
    }

    private void OnDisable()
    {
        _menue.HidedMenue -= OnHide;
        //_moneyHolder.BalanceChanged -= OnBalnceChanged;
    }

    private void OnHide(bool value)
    {
        if (_canBuy == false)
            return;

        if (value == true)
        {
            _menuIndicator.SetActive(true);
            _shopIndicator.SetActive(false);
        }
        else
        {
            _menuIndicator.SetActive(false);
            _shopIndicator.SetActive(true);
        }
    }

    private void OnBalnceChanged(int value)
    {
        _prices = new List<int>();

        //foreach (var collor in _collors)
        //    if (collor.IsSell == false)
        //        _prices.Add(collor.Price);

        //foreach (var wheel in _wheels)
        //    if (wheel.IsSell == false)
        //        _prices.Add(wheel.Price);

        foreach (var price in _prices)
        {
            if (value >= price)
            {
                _canBuy = true;

                if (_menue.IsHide == true)
                    _menuIndicator.SetActive(true);
                else
                    _shopIndicator.SetActive(true);
                return;
            }
            else
            {
                _menuIndicator.SetActive(false);
                _shopIndicator.SetActive(false);
                _canBuy = false;
                return;
            }
        }

        if (_prices.Count == 0)
        {
            _menuIndicator.SetActive(false);
            _shopIndicator.SetActive(false);
            _canBuy = false;
        }
    }
}
