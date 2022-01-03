using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScaler : MonoBehaviour
{
    public static UIScaler instance;
    private void Awake()
    {
        instance = this;
        ScreenResolutionArranger();
    }
    void ScreenResolutionArranger()
    {
        float screenRatio = ((float)Screen.height / (float)Screen.width);
        if (screenRatio < 1.35f)
        {
            GetComponent<CanvasScaler>().referenceResolution = new Vector2(2048, 2732);
        }
        else if (screenRatio < 1.62f)
        {
            GetComponent<CanvasScaler>().referenceResolution = new Vector2(1920, 3072);
        }
        else if (screenRatio < 1.8f)
        {
            GetComponent<CanvasScaler>().referenceResolution = new Vector2(1404, 2496);
        }
        else if (screenRatio < 2.20f)
        {
            GetComponent<CanvasScaler>().referenceResolution = new Vector2(1242, 2688);
        }
    }
}
