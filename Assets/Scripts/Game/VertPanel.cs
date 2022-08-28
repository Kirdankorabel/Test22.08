using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VertPanel : MonoBehaviour, IStateSaver<VertPanelInfo>
{
    [SerializeField] private VertPanelInstantiator verticalPanelInstantiator;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Button _resetButton;
    [Range(2, 10)] [SerializeField] private int _collumCount = 3;
    private Collum[] _collums;
    private VertPanelInfo _panelInfo;

    public Collum[] Collums => _collums;

    private void Start()
    {
        StaticInfo.VerticalPanel = this;
        LoadState(StaticInfo.date.VerticalPanelInfo);
        verticalPanelInstantiator.InstantiateCollums(_collums, _collumCount);
        _resetButton.onClick.AddListener(() => ResetItems());
    }

    private void ResetItems()
    {
        foreach (var item in _collums)
            item.InstCollum();
    }

    public VertPanelInfo UpdateState()
    {
        _panelInfo = new VertPanelInfo();
        CollumInfo[] collumInfos = new CollumInfo[_collumCount];
        for (var i = 0; i < _collumCount; i++)
            collumInfos[i] = _collums[i].UpdateState();
        _panelInfo.collumInfos = collumInfos;
        return _panelInfo;
    }

    public void LoadState(VertPanelInfo info)
    {
        try
        {
            var collumInfos = info.collumInfos;
            _collumCount = collumInfos.Length;
            _collums = verticalPanelInstantiator.InitCollums(_collumCount);
            for (var i = 0; i < _collumCount; i++)
                _collums[i].LoadState(collumInfos[i]);
        }
        catch
        {
            _collums = verticalPanelInstantiator.InitCollums(_collumCount);
        }
    }
}