using System;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    private readonly float _maxAmount = 100;
    private readonly float _minAmount = 0;
    private readonly float _changeValue = 1;
    private readonly float _upgradeToMediumAmount = 30;
    private readonly float _upgradeToRichAmount = 70;

    private float _currentAmount;
    private bool _isPoor;
    private bool _isMedium;
    private bool _isRich;

    public event Action PoorValueReached;
    public event Action MediumValueReached;
    public event Action RichValueReached;
    public event Action AmountChanged;
    public event Action MinimumAmountReached;

    public float CurrentAmount => _currentAmount;
    public float MinAmount => _minAmount;

    private void Awake()
    {
        _currentAmount = _minAmount;
        _isPoor = true;
        _isMedium = false;
        _isRich = false;
    }

    public void Increase()
    {
        if (_currentAmount + _changeValue <= _maxAmount)
        {
            _currentAmount += _changeValue;
            AmountChanged?.Invoke();
        }
        else
        {
            _currentAmount = _maxAmount;
            AmountChanged?.Invoke();
        }

        UpdateState();
    }

    public void Decrease()
    {
        if (_currentAmount - _changeValue >= _minAmount)
        {
            _currentAmount -= _changeValue;
            AmountChanged?.Invoke();
        }
        else
        {
            _currentAmount = _minAmount;
            AmountChanged?.Invoke();
            MinimumAmountReached?.Invoke();
        }
        
        UpdateState();
    }

    private void UpdateState()
    {
        if (_currentAmount >= _upgradeToRichAmount && !_isRich)
        {
            _isRich = true;
            _isMedium = false;
            _isPoor = false;
            RichValueReached?.Invoke();
        }
        else if (_currentAmount >= _upgradeToMediumAmount && _currentAmount < _upgradeToRichAmount && !_isMedium)
        {
            _isMedium = true;
            _isPoor = false;
            _isRich = false;
            MediumValueReached?.Invoke();
        }
        else if (_currentAmount < _upgradeToMediumAmount && !_isPoor)
        {
            _isPoor = true;
            _isMedium = false;
            _isRich = false;
            PoorValueReached?.Invoke();
        }
    }
}