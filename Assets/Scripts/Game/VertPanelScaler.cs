using UnityEngine;

public class VertPanelScaler : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private VertPanel _verticalPanel;

    private void Update()
    {
        float size = 0;
        foreach (var collum in _verticalPanel.Collums)
            if (collum.Size > size)
                size = collum.Size;
        _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, size);
    }
}