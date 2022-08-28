using UnityEngine;

public class VertScroleScaler : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform.offsetMax = _rectTransform.offsetMax * StaticInfo.ScaleFactor;
    }
}