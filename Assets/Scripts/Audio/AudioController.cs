using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioController: MonoBehaviour
{
    private int currentIndex = 0;
    [SerializeField] private AudioClip[] clips;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        Messenger.AddListener(EventsConfig.StopSong, Stop);
    }

    void Start()
	{
        PlayNext();
	}

    void Update()
    {
        if (!source.isPlaying) PlayNext();
    }

    private void PlayNext() {
		currentIndex = Random.Range(0, clips.Length);
		source.clip = clips[currentIndex];
		source.Play();
        Messenger<string>.Broadcast(EventsConfig.NextSong, clips[currentIndex].name);
	}

    public void UpVolume() {
        source.volume = 1.0f;
    }

    public void LowVolume() {
        source.volume = 0.2f;
    }

    void Pause() {
        
    }

    void Stop() {
        source.Stop();
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(EventsConfig.StopSong, Stop);
    }
}
