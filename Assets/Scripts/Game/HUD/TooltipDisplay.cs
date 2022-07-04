using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TooltipDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tooltipText;

    [Space]

    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] Image currencyDisplay;
    [SerializeField] Sprite[] currencySprites;

    void Start()
    {
        SetTooltipTextVisibility(false);
        SetCostTextVisibility(false);
    }

    public void OnPointerOverCurrency(AutoMiner autoMiner)
    {
        SetTooltipTextVisibility(true);
        SetCostTextVisibility(false);

        int currencyPerSecond = Mathf.RoundToInt(autoMiner.CurrencyPerSecond);
        string currencyType = autoMiner.currencyObject.currencyType.ToString();
        tooltipText.text = $"Mining {currencyPerSecond} {currencyType} per second.";
    }

    public void OnPointerOverUpgradeLevel(BuildingObject buildingObject)
    {
        SetTooltipTextVisibility(true);
        SetCostTextVisibility(true);

        string buildingName = buildingObject.building.buildingType.ToString();
        int currentLevel = buildingObject.building.level;

        tooltipText.text = $"Upgrade the {buildingName} from Lv. {currentLevel} to Lv. {currentLevel + 1}.";
        currencyDisplay.sprite = currencySprites[(int)buildingObject.building.costCurrencyType];
        costText.text = ((int)buildingObject.building.upgradeCosts[UpgradeType.LevelUp]).ToString();
    }

    public void OnPointerOverUpgradeSpeed(BuildingObject buildingObject)
    {
        SetTooltipTextVisibility(true);
        SetCostTextVisibility(true);

        string buildingName = buildingObject.building.buildingType.ToString();
        float currentSpeed = buildingObject.building.speedMultiplier;

        tooltipText.text = $"Increase the production speed of {buildingName} from {currentSpeed:f1}x to {currentSpeed + 0.1:f1}x.";
        currencyDisplay.sprite = currencySprites[(int)buildingObject.building.costCurrencyType];
        costText.text = ((int)buildingObject.building.upgradeCosts[UpgradeType.SpeedUp]).ToString();
    }

    public void OnPointerExit()
    {
        SetTooltipTextVisibility(false);
        SetCostTextVisibility(false);
    }

    void SetTooltipTextVisibility(bool visible)
    {
        tooltipText.enabled = visible;
    }

    void SetCostTextVisibility(bool visible)
    {
        costText.enabled = visible;
        currencyDisplay.enabled = visible;
    }
}