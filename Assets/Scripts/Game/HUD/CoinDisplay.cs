using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] CurrencyObject[] currencies;
    [SerializeField] TextMeshProUGUI[] coinAmountTexts;

    void Awake()
    {
        FindObjectOfType<BuildingShop>().FirstPurchaseAction += OnBuildingFirstPurchase;
    }

    void OnBuildingFirstPurchase(BuildingType buildingType)
    {
        int childIndex = (int)buildingType;
        coinAmountTexts[childIndex].transform.parent.gameObject.SetActive(true);
    }

    void Update()
    {
        // update currency amount displays
        for (int i = 0; i < coinAmountTexts.Length; i++)
        {
            coinAmountTexts[i].text = currencies[i].amount.ToString();
        }
    }
}