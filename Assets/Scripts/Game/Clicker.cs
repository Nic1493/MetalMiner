using System.Collections;
using UnityEngine;
using static CoroutineHelper;

public class Clicker : MonoBehaviour
{
    Camera mainCam;

    [SerializeField] CurrencyObject copperCurrency;
    [SerializeField] LayerMask clickerLayer;

    bool isClicking;

    SpriteRenderer clickerSprite;
    IEnumerator clickAnimation;
    const float AnimationDuration = 0.1f;
    const float ShrinkSize = 0.9f;

    void Awake()
    {
        mainCam = Camera.main;
        clickerSprite = GetComponentInChildren<SpriteRenderer>();
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

                if (clickAnimation != null)
                {
                    StopCoroutine(clickAnimation);
                }

                clickAnimation = Click(clickerSprite.size.x, ShrinkSize);
                StartCoroutine(clickAnimation);
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                isClicking = false;

                if (IsMouseOverClicker())
                {
                    copperCurrency.amount++;
                }

                if (clickAnimation != null)
                {
                    StopCoroutine(clickAnimation);
                }

                clickAnimation = Click(clickerSprite.size.x, 1f);
                StartCoroutine(clickAnimation);
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

    IEnumerator Click(float startScale, float endScale)
    {
        float currentLerpTime = 0f;

        while (currentLerpTime < AnimationDuration)
        {
            float lerpProgress = currentLerpTime / AnimationDuration;
            clickerSprite.size = Mathf.Lerp(startScale, endScale, lerpProgress) * Vector3.one;

            yield return EndOfFrame;
            currentLerpTime += Time.deltaTime;
        }
    }
}