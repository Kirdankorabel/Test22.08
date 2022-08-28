using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertPanelInstantiator : MonoBehaviour
{
    [SerializeField] private Collum _collumPrefab;
    [SerializeField] private int _spritesCount;
    private List<Sprite> _sprites;

    public void InstantiateCollums(Collum[] collums, int collumCount)
    {
        _sprites = Store.GetAllAssets<Sprite>("images");
        var images = new List<Sprite>[collumCount];
        var counter = 0;
        var lenght = _sprites.Count;

        for (var i = 0; i < collumCount; i++)
            images[i] = new List<Sprite>();
        while (counter < _spritesCount)
        {
            for (var i = 0; i < collumCount; i++)
                images[i].Add(_sprites[counter % lenght]);
            counter++;
        }
        for (var i = 0; i < collumCount; i++)
            collums[i].SetSprites(images[i]);
    }

    public Collum[] InitCollums(int collumCount)
    {
        var offset = Screen.width / (collumCount + 1);
        var collums = new Collum[collumCount];
        for (var i = 0; i < collumCount; i++)
        {
            collums[i] = Instantiate(_collumPrefab, transform);
            RectTransform rectTransform = collums[i].gameObject.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(offset * (i + 1), 0, 0);
            collums[i].SetPosition(i);
        }
        return collums;
    }
}