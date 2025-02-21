using System;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource soundSource;
    public static AudioManager instance;
    public string trackToPlay;

    // Smooth looping workaround
    private AudioSource[] musicSources;
    private int currentMusicSource = 0;
    private double nextTime = 0.0;

    [Serializable]
    public struct Sound {
        public string name;
        public AudioClip sound;
        public float volumeChangeRelative;
    }
    public Sound[] sounds;
    public Sound[] tracks;

    void Awake()
    {
        instance = this;
        /*if (instance == null){
            instance = this;
            //DontDestroyOnLoad(gameObject);
        } else{
            Destroy(gameObject);
        }*/
        PlayMusic(trackToPlay);
    }

    void Update() {
        if (trackToPlay != "Library") {
            return;
        }
        if (AudioSettings.dspTime + 1.0f > nextTime) {
            currentMusicSource = 1 - currentMusicSource;
            musicSources[currentMusicSource].PlayScheduled(nextTime);
            nextTime += 60.0f * 128.0f / 132.0f;
        }
    }

    public void PlaySound(string name) {
        Sound s = Array.Find(sounds, x => x.name == name);
        if (s.name == "") {
            Debug.Log("Sound " + name + "not found");
        } else {
            Debug.Log("playing sound");
            soundSource.clip = s.sound;
            soundSource.enabled = true;
            soundSource.Play();
            //PlayClipAtPoint(s.sound, Camera.main.transform.position, 1 + s.volumeChangeRelative).spatialBlend = 0;
        }
    }

    public void PlayMusic(string track) {
        Sound s = Array.Find(tracks, x => x.name == track);
        if (s.name == "") {
            Debug.Log("Track " + track + "not found");
        } else {
            musicSource.clip = s.sound;
            if (track != "Library") {
                musicSource.Play();
            } else { // Smooth looping
                musicSource.loop = false;
                musicSources = new AudioSource[2];
                musicSources[0] = musicSource;
                musicSources[1] = gameObject.AddComponent<AudioSource>();
                musicSources[1].clip = s.sound;
                musicSources[1].volume = musicSource.volume;
                nextTime = AudioSettings.dspTime + 1.0f;
            }
        }
    }

	public static AudioSource PlayClipAtPoint(AudioClip clip, Vector3 position, float volume)
	{
		GameObject gameObject = new GameObject("One shot audio");
		gameObject.transform.position = position;
		AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		audioSource.clip = clip;
		audioSource.spatialBlend = 1f;
		audioSource.volume = volume;
		audioSource.Play();
		Destroy(gameObject, clip.length * ((Time.timeScale < 0.01f) ? 0.01f : Time.timeScale));
        return audioSource;
	}
}
