using System.Collections.Generic;
using UnityEngine;

public class CollumInstantiator : MonoBehaviour
{
    [SerializeField] private Item _itemPrefab;
    [SerializeField] private float _vOffset;
    private RectTransform _imageRectTransforn;
    private AudioClip _sound; 
    private List<Item> _items;

    public float Offset => _vOffset;

    private void Awake()
    {
        _imageRectTransforn = _itemPrefab.GetComponent<RectTransform>();
        _vOffset = (_vOffset + _imageRectTransforn.sizeDelta.y) * StaticInfo.ScaleFactor;
        _sound = Store.GetAsset<AudioClip>("sounds", "sound1");
    }

    public CollumInfo InstantiateItems(List<Sprite> sprites)
    {
        if (_items != null)
            DeleteItems(_items);

        var sizeDelta = _imageRectTransforn.sizeDelta * StaticInfo.ScaleFactor;
        var collumInfo = new CollumInfo();
        var items = new List<Item>();
        Item pervious = null;
        collumInfo.ItemInfos = new List<ItemInfo>();

        for (var i = 0; i < sprites.Count; i++)
        {
            var item = Instantiate(_itemPrefab, transform);
            item.SetSprite(sprites[i]);
            item.SetAudioClip(_sound);
            item.transform.localPosition = new Vector3(0, -_vOffset * (i + 1), 0);
            item.Iteminfo = new ItemInfo(sprites[i].name);
            item.GetComponent<RectTransform>().sizeDelta = sizeDelta;

            if (i > 0)
                item.Pervious = pervious;

            pervious = item;
            items.Add(item);
            collumInfo.ItemInfos.Add(item.Iteminfo);
            item.Destroyed += (value) => collumInfo.ItemInfos.Remove(item.Iteminfo);
        }

        _items = items;
        return collumInfo;
    }

    private void DeleteItems(List<Item> items)
    {
        foreach (var item in items)
            if (item != null)
                Destroy(item.gameObject);
    }
}