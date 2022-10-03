using System.Globalization;
using UnityEngine;
using TMPro;

public class UIGameScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI diamondText;

    private void Start()
    {
        OnMoneyValueChanged(GameManager.Instance.Money);
        OnDiamondValueChanged(GameManager.Instance.Diamond);
        GameManager.Instance.OnMoneyValueChange += OnMoneyValueChanged;
        GameManager.Instance.OnDiamondValueChange += OnDiamondValueChanged;
    }

    private void OnMoneyValueChanged(float value)
    {
        moneyText.text = FormatNums.FormatNum(value);
    }
    
    private void OnDiamondValueChanged(float value)
    {
        diamondText.text = FormatNums.FormatNum(value);
    }
}
