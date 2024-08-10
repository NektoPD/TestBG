using TMPro;
using UnityEngine;

public class PlayerProgressView : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentAmount;
    [SerializeField] private PlayerProgress _playerProgress;

    private void Start()
    {
        UpgradeValue();
    }

    private void OnEnable()
    {
        _playerProgress.AmountChanged += UpgradeValue;
    }

    private void OnDisable()
    {
        _playerProgress.AmountChanged -= UpgradeValue;
    }

    private void UpgradeValue()
    {
        _currentAmount.text = _playerProgress.CurrentAmount.ToString();
    }
}
