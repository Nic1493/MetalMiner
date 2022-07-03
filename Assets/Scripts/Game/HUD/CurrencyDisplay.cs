using UnityEngine;
using TMPro;

public class CurrencyDisplay : MonoBehaviour
{
    [SerializeField] CurrencyObject currencyObject;
    TextMeshProUGUI currencyAmountText;

    void Awake()
    {
        currencyAmountText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        // update currency amount display
        currencyAmountText.text = ((int)currencyObject.amount).ToString();
    }
}