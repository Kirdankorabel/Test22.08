using UnityEngine;

public class HorPanelScaler : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;

    void Start()
    {
        _rectTransform.anchoredPosition = _rectTransform.anchoredPosition * StaticInfo.ScaleFactor;
        _rectTransform.sizeDelta = _rectTransform.sizeDelta * StaticInfo.ScaleFactor;
    }
}