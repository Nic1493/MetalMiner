using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyConverter : MonoBehaviour
{
    [SerializeField] Button convertButton;

    [Space]

    [SerializeField] CurrencyConverterInputField inputField;
    [SerializeField] CurrencyConverterInputField outputField;

    [Space]

    [SerializeField] CurrencyObject[] currencyObjects;

    int inputAmount;
    int outputAmount;

    // calculate amount of currency that will result from the conversion, based on input amount and selected currencies
    public void UpdateResultingInputField()
    {
        inputAmount = ParseStringToInt(inputField.field.text);
        if (inputAmount == 0) return;

        int ordersOfMagnitude = inputField.selectedIndex - outputField.selectedIndex;
        outputAmount = (int)(inputAmount * Mathf.Pow(10, ordersOfMagnitude));

        outputField.field.text = outputAmount.ToString();

        // ensure that player has enough currency to convert, and that conversion doesn't result in 0 currency
        if (inputAmount > currencyObjects[inputField.selectedIndex].amount || outputAmount == 0)
        {
            convertButton.interactable = false;
        }
        else
        {
            convertButton.interactable = true;
        }
    }

    // convert input field text to number
    int ParseStringToInt(string str)
    {
        if (int.TryParse(str, out int value))
        {
            return value;
        }

        return 0;
    }

    // called from pressing Convert button in Currency Converter section
    public void OnConvertPressed()
    {
        currencyObjects[inputField.selectedIndex].amount -= inputAmount;
        currencyObjects[outputField.selectedIndex].amount += outputAmount;
    }
}