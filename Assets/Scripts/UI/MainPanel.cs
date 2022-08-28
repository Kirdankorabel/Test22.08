using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _openInfoButton;
    [SerializeField] private InfoPanel _infoPanel;

    void Awake()
    {
        _closeButton.onClick.AddListener(() => this.gameObject.SetActive(false));
        _openInfoButton.onClick.AddListener(() => _infoPanel.gameObject.SetActive(true));
    }
}