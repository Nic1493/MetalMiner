using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class CurrencyConverterInputField : MonoBehaviour
{
    TMP_InputField thisInputField;
    [SerializeField] TMP_InputField otherInputField;

    void Awake()
    {
        thisInputField = GetComponent<TMP_InputField>();

        thisInputField.characterLimit = 9;
        thisInputField.characterValidation = TMP_InputField.CharacterValidation.Integer;
    }
}