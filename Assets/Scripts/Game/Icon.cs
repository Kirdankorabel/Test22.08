using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private RectTransform rectTransform;

    public float PositionX => rectTransform.anchoredPosition.x;

    public void SetSprite(Sprite sprite)
        => image.sprite = sprite;
}