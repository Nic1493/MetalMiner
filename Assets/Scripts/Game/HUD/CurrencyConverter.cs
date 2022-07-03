using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyConverter : MonoBehaviour
{
    [SerializeField] Button convertButton;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] CurrencyObject[] currencyObjects;

    // called from pressing Convert button in scene
    public void OnConvertPressed()
    {
        if (int.TryParse(inputField.text, out int inputFieldValue))
        {
            // to-do
            print(inputFieldValue);
        }
    }

    public void CheckForValidConversion()
    {
        // to-do
    }
}