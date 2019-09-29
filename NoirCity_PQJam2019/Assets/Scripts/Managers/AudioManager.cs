using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    private AudioSource Music;
    [SerializeField]
    private AudioSource Ambient;
    [SerializeField]
    private AudioSource SoundEffect;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        Music.Play();
    }

    public void PlayAmbient()
    {
        Ambient.Play();
    }

    public void PlaySoundEffect()
    {
        SoundEffect.Play();
    }
    
    public void StopMusic()
    {
        Music.Stop();
    }

    public void StopAmbient()
    {
        Ambient.Stop();
    }

    public void StopSoundEFfect()
    {
        SoundEffect.Stop();
    }
}
