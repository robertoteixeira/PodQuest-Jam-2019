using System.Linq;
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
        var audioManagers = GameObject.FindGameObjectsWithTag("AudioManager");

        if(audioManagers.Count() > 1)
            Destroy(audioManagers.Last().gameObject);

        this.Reload();
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (Music != null)
            Music.Play();
    }

    public void PlayAmbient()
    {
        if (Ambient != null)
            Ambient.Play();
    }

    public void PlaySoundEffect()
    {
        if(SoundEffect != null)
            SoundEffect.Play();
    }
    
    public void StopMusic()
    {
        if (Music != null)
            Music.Stop();
    }

    public void StopAmbient()
    {
        if(Ambient != null)
            Ambient.Stop();
    }

    public void StopSoundEFfect()
    {
        if (SoundEffect != null)
            SoundEffect.Stop();
    }
}
