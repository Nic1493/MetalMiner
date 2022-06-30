using UnityEngine;

public class Clicker : MonoBehaviour
{
    Camera mainCam;

    [SerializeField] IntObject currency;
    [SerializeField] LayerMask clickerLayer;

    // cache components
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
        // on LMB pressed
        if (Input.GetMouseButtonDown(0))
        {
            // check if mouse pressed clicker
            Vector3 mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.OverlapPoint(mousePosition, clickerLayer);

            if (hit != null)
            {
                currency.value++;
            }
        }
    }
}