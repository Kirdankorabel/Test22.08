using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Camera _main;
    private void Awake()
    {
        _rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        _main.orthographicSize = Screen.height / 2;
    }
}
