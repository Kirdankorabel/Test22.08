using System;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource _player;
    [SerializeField] private List<AudioClip> _playlist;
    private int currentTrek = 0;
    private float nextClipStartTime;

    public event Action<string> songChanged;

    public AudioSource GetAudioSource => _player;

    private void Awake()
    {
        _playlist = Store.GetAllAssets<AudioClip>("musics");
    }

    private void Start()
    {
        Play();
    }

    private void Update()
    {
        if (Time.time > nextClipStartTime)
            Next();
    }

    public void Next()
    {
        _player.Stop();
        if (++currentTrek == _playlist.Count)
            currentTrek = 0;
        _player.clip = _playlist[currentTrek];
        Play();
    }

    public void Pervious()
    {
        _player.Stop();
        if (--currentTrek < 0)
            currentTrek = _playlist.Count - 1;
        _player.clip = _playlist[currentTrek];
        Play();
    }

    private void Play()
    {
        nextClipStartTime = Time.time + _playlist[currentTrek].length;
        songChanged?.Invoke(_playlist[currentTrek].name);
        _player.PlayOneShot(_playlist[currentTrek]);
    }
}