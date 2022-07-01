using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] IntObject coins;
    [SerializeField] TextMeshProUGUI coinAmountText;

    void Update()
    {
        coinAmountText.text = coins.value.ToString();
    }
}