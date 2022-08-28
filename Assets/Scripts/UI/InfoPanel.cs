using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private Button _urlbutton;
    [SerializeField] private Text _urlbuttonText;
    [SerializeField] private Text _prohectNameText;
    [SerializeField] private string _ling = "https://web.telegram.org/k/#@kirillkird";

    private void Awake()
    {
        _urlbuttonText.text = _ling;
        _prohectNameText.text = Application.productName;
        _urlbuttonText.color = Color.blue;
    }

    public void OpenURL() => Application.OpenURL(_ling);
}