using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickupBarView : MonoBehaviour
{
    private readonly string PoorText = "Бедный";
    private readonly string MediumText = "Состоятельный";
    private readonly string RichText = "Богатый";

    [SerializeField] private TMP_Text _text;
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fillAreaImage;
    [SerializeField] private Color _poorColor;
    [SerializeField] private Color _mediumColor;
    [SerializeField] private Color _richColor;
    [SerializeField] private PlayerProgress _playerProgress;

    private Coroutine _coroutine;
    private float _increaseSpeed = 10f;

    private void Awake()
    {
        _text.text = PoorText;
        _slider.value = _playerProgress.MinAmount;
    }

    private void OnEnable()
    {
        _playerProgress.PoorValueReached += ChangeToPoorState;
        _playerProgress.MediumValueReached += ChangeToMediumState;
        _playerProgress.RichValueReached += ChangeToRichState;
        _playerProgress.AmountChanged += StartValueChange;
    }

    private void OnDisable()
    {
        _playerProgress.PoorValueReached -= ChangeToPoorState;
        _playerProgress.MediumValueReached -= ChangeToMediumState;
        _playerProgress.RichValueReached -= ChangeToRichState;
        _playerProgress.AmountChanged -= StartValueChange;
    }

    private void ChangeToMediumState()
    {
        _fillAreaImage.color = _mediumColor;
        _text.text = MediumText;
        _text.color = _mediumColor;
    }

    private void ChangeToRichState()
    {
        _fillAreaImage.color = _richColor;
        _text.text = RichText;
        _text.color = _richColor;
    }

    private void ChangeToPoorState()
    {
        _fillAreaImage.color = _poorColor;
        _text.text = PoorText;
        _text.color = _poorColor;
    }

    private void StartValueChange()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeSliderValue());
    }

    private IEnumerator ChangeSliderValue()
    {
        while (_slider.value != _playerProgress.CurrentAmount)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _playerProgress.CurrentAmount, _increaseSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
