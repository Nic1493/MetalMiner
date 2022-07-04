using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class CurrencyConverterInputField : MonoBehaviour
{
    public TMP_InputField field;
    public int selectedIndex;

    const int MaxCharacterLimit = 9;

    [SerializeField] Image[] currencyImages;

    // called from pressing scroll buttons in Currency Converter section
    public void OnScrollButtonPressed(int scrollDirection)
    {
        // increment/decrement selected currency index based on which scroll button was pressed
        selectedIndex = (int)Mathf.Repeat(selectedIndex + scrollDirection, currencyImages.Length);

        // enable currency image whose index is equal to selected currency index
        for (int i = 0; i < currencyImages.Length; i++)
        {
            currencyImages[i].enabled = i == selectedIndex;
        }

        SetCharacterLimit();
    }

    // set max character limit of input field based on selected currency
    // (to prevent text overflow when converting from higher to lower currencies)
    void SetCharacterLimit()
    {
        field.characterLimit = MaxCharacterLimit - selectedIndex;

        if (field.text.Length > field.characterLimit)
        {
            field.text = field.text.Substring(0, field.characterLimit);
        }
    }
}