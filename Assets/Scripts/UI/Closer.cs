using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Closer : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _closeButton;
    [Range(0, 10)] [SerializeField] private float _speed = 1;
    private float _transparency = 1;

    private void Awake()
    {
        _closeButton.onClick.AddListener(() => StartCoroutine(ColseCorutine()));
    }

    private void OnEnable()
    {
        StartCoroutine(OpenCorutine());
        _closeButton.interactable = true;
    }

    private IEnumerator ColseCorutine()
    {
        while(_transparency > 0)
        {
            _transparency -= Time.deltaTime / _speed;
            _canvasGroup.alpha = _transparency;
            yield return null;
        }
        this.gameObject.SetActive(false);
    }

    private IEnumerator OpenCorutine()
    {
        while (_transparency < 1)
        {
            _transparency += Time.deltaTime / _speed;
            _canvasGroup.alpha = _transparency;
            yield return null;
        }
    }
}