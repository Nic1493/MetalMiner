using UnityEngine;
using TMPro;

public class BuildingButton : MonoBehaviour
{
    [SerializeField] BuildingObject buildingObject;

    [Space]

    [SerializeField] TextMeshProUGUI buildingNameText;
    [SerializeField] TextMeshProUGUI buildingCostText;
    [SerializeField] TextMeshProUGUI buildingCountText;
    [SerializeField] TextMeshProUGUI buildingLevelText;

    void Awake()
    {
        GetComponentInParent<BuildingPurchaseShop>().PurchaseAction += UpdateTexts;
        FindObjectOfType<BuildingUpgradeShop>().LevelUpAction += UpdateTexts;
    }

    void Start()
    {
        buildingNameText.text = buildingObject.name;
        UpdateTexts(buildingObject);
    }

    void UpdateTexts(BuildingObject _)
    {
        buildingCostText.text = ((int)buildingObject.building.purchaseCost).ToString();
        buildingCountText.text = $"{buildingObject.building.count}x";
        buildingLevelText.text = buildingObject.building.level.ToString();
    }
}