using System.Collections.Generic;
using UnityEngine;

public class Collum : MonoBehaviour, IStateSaver<CollumInfo>
{
    [SerializeField] private CollumInstantiator collumInstantiator;
    private List<Sprite> _loadedSprites;
    private List<Sprite> _sprites;
    private CollumInfo _collumInfo;
    private Vector2 _sizeDeltaDefault;

    public float Size => _collumInfo.ItemInfos.Count * collumInstantiator.Offset / 2;

    private void Awake()
    {
        _collumInfo = new CollumInfo();
    }

    void Start()
    {
        if (_sprites != null)
            _collumInfo = collumInstantiator.InstantiateItems(_sprites);
        else
            _collumInfo = collumInstantiator.InstantiateItems(_loadedSprites);
    }

    public void SetSprites(List<Sprite> sprites)
        => _loadedSprites = sprites;

    public void InstCollum()
        => _collumInfo = collumInstantiator.InstantiateItems(_loadedSprites);

    public int SetPosition(int position)
        => _collumInfo.Position = position;

    public CollumInfo UpdateState()
        =>_collumInfo;

    public void LoadState(CollumInfo info)
    {
        _sprites = new List<Sprite>();
        _collumInfo = new CollumInfo();
        _collumInfo.ItemInfos = info.ItemInfos;

        if (info != null)
            foreach (var item in info.ItemInfos)
                _sprites.Add(Store.GetAsset<Sprite>("images", item.ImageName));
    }
}