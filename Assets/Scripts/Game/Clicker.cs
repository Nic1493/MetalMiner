using UnityEngine;

public class Clicker : MonoBehaviour
{
    Camera mainCam;

    [SerializeField] CurrencyObject copperCurrency;
    [SerializeField] LayerMask clickerLayer;

    bool isClicking;

    void Awake()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        GetMouseInput();
    }

    void GetMouseInput()
    {
        if (!isClicking)
        {
            if (Input.GetMouseButtonDown(0) && IsMouseOverClicker())
            {
                isClicking = true;
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0) && IsMouseOverClicker())
            {
                isClicking = false;
                copperCurrency.amount++;
            }
        }
    }

    // check if mouse's position is within clicker object's area
    bool IsMouseOverClicker()
    {
        Vector3 mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mousePosition, clickerLayer);

        return hit != null;
    }
}