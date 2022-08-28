using UnityEngine;
using UnityEngine.UI;

public class CircleScroleBar : MonoBehaviour
{
    [SerializeField] private Image circle;
    [SerializeField] private Text text;

    public void UpdateImage(float percent)
    {
        text.text = percent + "%";
        circle.fillAmount = percent / 100f;
    }
}
