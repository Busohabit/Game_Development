using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; set; }

    [Header("--------- Audio Sources ---------")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("--------- Music Settings ---------")]
    public AudioClip[] allSongs;
    public float minDelayBetweenSongs = 2f;
    public float maxDelayBetweenSongs = 5f;
    public bool playOnStart = true;
    public float delayToStart = 0f;
    private List<AudioClip> remainingSongs;
    private List<AudioClip> playedSongs = new List<AudioClip>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        remainingSongs = new List<AudioClip>(allSongs);

        if (playOnStart)
        {
            PlayMusicWithDelay(delayToStart);
        }
        else
        {
            Invoke("PlayNextSong", delayToStart);
        }

        sfxSource.Play();
    }

    void PlayMusicWithDelay(float delay)
    {
        Invoke("PlayNextSong", delay);
    }

    void PlayNextSong()
    {
        if (remainingSongs.Count == 0)
        {
            remainingSongs = new List<AudioClip>(allSongs);
            playedSongs.Clear();
        }

        int randomIndex = Random.Range(0, remainingSongs.Count);
        AudioClip selectedSong = remainingSongs[randomIndex];

        remainingSongs.RemoveAt(randomIndex);

        musicSource.clip = selectedSong;

        musicSource.Play();

        playedSongs.Add(selectedSong);

        Invoke("PlayNextSong", musicSource.clip.length + Random.Range(minDelayBetweenSongs, maxDelayBetweenSongs));
    }
}
