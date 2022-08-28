using System.Collections;
using UnityEngine;

public class HorPanelMover : MonoBehaviour
{
    [SerializeField] private HorPanel _horisontalPanel;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float _speed;
    private Vector2 _target;
    private bool _ReadyToMove = true;

    private void FixedUpdate()
    {
        if (!Input.GetMouseButton(0) && !_ReadyToMove)
        {
            _target = new Vector2(-_horisontalPanel.GetItemPosition, _rectTransform.anchoredPosition.y);
            _ReadyToMove = true;
            StartCoroutine(MoveToIconCorutine());
        }
        else if (Input.GetMouseButton(0))
        {
            _ReadyToMove = false;
            StopCoroutine(MoveToIconCorutine());
        }
    }

    private IEnumerator MoveToIconCorutine()
    {
        while (Vector3.Distance(transform.localPosition, _target) > 0.1 || Input.GetMouseButton(0))
        {
            _rectTransform.anchoredPosition = Vector2.MoveTowards(_rectTransform.anchoredPosition, _target, 3 * _speed * Time.deltaTime);
            yield return null;
        }
        yield return StartCoroutine(MoveCorutine());
    }

    private IEnumerator MoveCorutine()
    {
        yield return new WaitForSeconds(1.5f);
        while (!Input.GetMouseButton(0))
        {
            _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x + _speed * Time.deltaTime, _rectTransform.anchoredPosition.y);
            yield return null;
        }
        yield return null;
    }
}