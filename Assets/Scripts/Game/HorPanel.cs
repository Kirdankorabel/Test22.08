using System.Collections.Generic;
using UnityEngine;

public class HorPanel : MonoBehaviour
{
    [SerializeField] private GUIContent content;
    [SerializeField] private Icon _iconPrefab;
    private List<Icon> _icons;
    private List<Sprite> _images;
    private RectTransform _iconRectTransforn;
    private Vector3 _offset;
    private Vector3 _lastPos;
    private Vector3 _firstPos;
    private Vector2 _sizeDelta;
    private int _last = 0;
    private int _first = 0;
    private int _count = 3;

    public float GetItemPosition
    {
        get
        {
            float result = 0;
            foreach (var item in _icons)
                result += item.PositionX;
            return result/_count;
        }
    }

    private void Awake()
    {
        _offset = new Vector3(Screen.width / 2f, 0, 0);
        _images = Store.GetAllAssets<Sprite>("icons");
    }

    void Start()
    {
        _icons = new List<Icon>();
           _iconRectTransforn = _iconPrefab.GetComponent<RectTransform>();
        _sizeDelta = _iconRectTransforn.sizeDelta * StaticInfo.ScaleFactor;

        for (var i = 0; i < _count; i++)
        {
            var item = Instantiate(_iconPrefab, transform);
            item.SetSprite(_images[i]);
            item.GetComponent<RectTransform>().sizeDelta = _sizeDelta;
            _icons.Add(item);
        }

        _firstPos = Vector3.zero;
        for (var i = 1; i < _count; i++)
            MoveNext();
    }

    private void Update()
    {
        if (_lastPos.x + transform.localPosition.x > _offset.x + _iconRectTransforn.sizeDelta.x)
            MoveToStart();
        if (_firstPos.x + transform.localPosition.x < -_offset.x + _iconRectTransforn.sizeDelta.x)
            MoveToEnd();
    }

    private void MoveNext()
    {
        _lastPos = _icons[_last].transform.position;
        _last = (_last + 1) % _count;
        _icons[_last].transform.position = _lastPos + _offset;
    }

    private void MoveToStart()
    {
        _icons[_last].transform.position = _icons[_first].transform.position - _offset;
        _first = _last;
        _firstPos = _icons[_first].transform.localPosition;
        _last =(_last + _count - 1) % _count;
        _lastPos = _icons[_last].transform.localPosition;
    }

    private void MoveToEnd()
    {
        _icons[_first].transform.position = _icons[_last].transform.position + _offset;
        _last = _first;
        _lastPos = _icons[_last].transform.localPosition;
        _first = (_last + 1) % _count;
        _firstPos = _icons[_first].transform.localPosition;
    }
}