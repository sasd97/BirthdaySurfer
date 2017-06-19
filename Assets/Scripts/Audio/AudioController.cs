using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("Audio/Playlist Controller")]
public class AudioController: MonoBehaviour
{
    private int _playingIndex;
    private AudioSource _audioSource;

    [Header("Playlist Attributes")]
    [SerializeField] private AudioClip[] _clipsCollection;
    [SerializeField] private float _maxVolumeLevel = 0.7f;
    [SerializeField] private float _minVolumeLevel = 0.2f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _maxVolumeLevel;

        Messenger.AddListener(EventsConfig.OnStopSong, Stop);
    }

    void Update()
    {
        bool isGameStarted = StateManager.GetInstance().StateNot(StateManager.States.AWAITING_START);
        if (!_audioSource.isPlaying && isGameStarted) PlayNext();
    }

    public void PlayNext() {
        if (_clipsCollection.Length == 0) return;
		_playingIndex = Random.Range(0, _clipsCollection.Length);
		_audioSource.clip = _clipsCollection[_playingIndex];
        Messenger<string>.Broadcast(EventsConfig.OnNextSong, GetCurrentSongName());
		_audioSource.Play();
	}

    public AudioClip GetCurrent() {
        return _clipsCollection[_playingIndex];
    }

    public void SetVolumeToMax() {
        SetVolumeTo(_maxVolumeLevel);
    }

    public void SetVolumeToMin() {
        SetVolumeTo(_minVolumeLevel);
    }

    public void Stop() {
        _audioSource.Stop();
    }

    private string GetCurrentSongName() {
        return GetCurrent().name;
    }

    private void SetVolumeTo(float value) {
        _audioSource.volume = value;
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(EventsConfig.OnStopSong, Stop);
    }
}
