using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] IntObject[] currencies;
    [SerializeField] TextMeshProUGUI[] coinAmountTexts;

    void Update()
    {
        for (int i = 0; i < currencies.Length; i++)
        {
            coinAmountTexts[i].text = currencies[i].value.ToString();
        }
    }
}