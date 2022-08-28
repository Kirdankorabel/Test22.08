using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        StaticInfo.SoundManager = this;
    }

    public void PlayAudioClip(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}