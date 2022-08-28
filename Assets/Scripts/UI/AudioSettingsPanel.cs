using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsPanel : MonoBehaviour, IStateSaver<SettingsInfo>
{
    [SerializeField] private MusicManager _musicManager;
    [SerializeField] private AudioSource _soundManager;
    [SerializeField] private Slider _volumeMusicSlider;
    [SerializeField] private Slider _volumeSoundSlider;
    [SerializeField] private Button _nextSongButton;
    [SerializeField] private Button _previousSongButton;
    [SerializeField] private Text _songName;

    private void Awake()
    {
        StaticInfo.AudioSettingsPanel = this;
        _musicManager.songChanged += (name) => _songName.text = name;
    }

    void Start()
    {
        if (StaticInfo.date != null)
            LoadState(StaticInfo.date.AudioSettingsinfo);
        gameObject.SetActive(false);
    }

    public void SetMusicVolume() => _musicManager.GetAudioSource.volume = _volumeMusicSlider.value;
    public void SetSoundVolume() => _soundManager.volume = _volumeSoundSlider.value;

    public SettingsInfo UpdateState()
    {
        var result = new SettingsInfo();
        result.musicVolume = _volumeMusicSlider.value;
        result.soundVolume = _volumeSoundSlider.value;
        return result;
    }

    public void LoadState(SettingsInfo info)
    {
        _volumeMusicSlider.value = info.musicVolume;
        _musicManager.GetAudioSource.volume = info.musicVolume;
        _volumeSoundSlider.value = info.soundVolume;
        _soundManager.volume = info.soundVolume;
    }
}
