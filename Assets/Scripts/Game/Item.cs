using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IReleaser
{
    [SerializeField] private ParticleSystemRenderer _particleSystemRenderer;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _speed;
    private IReleaser _pervious;
    private Vector3 _targetPosition;
    private ItemInfo _itemModel;
    private bool _isMove;

    public event Action<Vector3> CellReleased;
    public event Action<IReleaser> Destroyed;

    public IReleaser Pervious 
    {
        get => _pervious;
        set
        {
            _pervious = value;
            if (_pervious == null)
                return;
            _pervious.Destroyed += (desteoyedPerviuos) => Pervious = desteoyedPerviuos;
            _pervious.CellReleased += (position) => Move(position);
        }
    }

    public ItemInfo Iteminfo
    {
        get => _itemModel;
        set
        {
            _itemModel = value;
        }
    }

    void Start()
    {
        _button.onClick.AddListener(() => DestroyThisItem());
        _particleSystemRenderer.material.mainTexture = Store.GetAsset<Texture2D>("textures", _image.sprite.name);
        _targetPosition = transform.localPosition;
    }

    public AudioClip SetAudioClip(AudioClip audioClip)
        => _audioClip = audioClip;
    public void SetSprite(Sprite sprite)
        => _image.sprite = sprite;

    private void DestroyThisItem()
    {
        if (Vector3.Distance(transform.localPosition, _targetPosition) > 0.02f)
            return;
        _particleSystem.Play();
        Destroyed?.Invoke(_pervious);
        if (_targetPosition == Vector3.zero)
            CellReleased?.Invoke(transform.localPosition);
        else
            CellReleased?.Invoke(_targetPosition);
        StaticInfo.SoundManager.PlayAudioClip(_audioClip);
        WaiteCorutine(() => Destroy(this.gameObject), 1);
        _image.enabled = false;
    }

    private void Move(Vector3 position)
    {
        if (position == _targetPosition)
            return;
        if (_targetPosition == Vector3.zero)
            CellReleased?.Invoke(transform.localPosition);
        else
            CellReleased?.Invoke(_targetPosition);
        _targetPosition = position;
        if (_isMove)
            return;
        _isMove = true;
        StartCoroutine(MoveCorutine());
    }

    private IEnumerator MoveCorutine()
    {
        while (Vector3.Distance(transform.localPosition, _targetPosition) > 0.01f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _targetPosition, _speed);
            yield return null;
        }
        _isMove = false;
        yield return null;
    }

    private IEnumerator WaiteCorutine(Action funk, float time)
    {
        yield return new WaitForSeconds(time);
        funk.Invoke();
        yield return null;
    }
}