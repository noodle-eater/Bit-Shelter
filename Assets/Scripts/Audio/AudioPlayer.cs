using UnityEngine;

public class AudioPlayer : MonoBehaviour, IInitOnAwake, IInitOnStart {
    
    public AudioDatabase database;
    
    private AudioSource bgmPlayer;
    private AudioSource sfxPlayer;

    public void InitOnAwake()
    {
        bgmPlayer = gameObject.AddComponent<AudioSource>();
        sfxPlayer = gameObject.AddComponent<AudioSource>();
    }

    public void InitOnStart()
    {
        bgmPlayer.playOnAwake = true;
        bgmPlayer.loop = true;
        SetVolume();
    }

    public void PlayBGM(string bgmName) {
        bgmPlayer.clip = database.GetAudio(bgmName);
        bgmPlayer.Play();
    }

    public void PlaySFX(string sfxName) {
        sfxPlayer.clip = database.GetAudio(sfxName);
        bgmPlayer.Play();
    }

    private void SetVolume()
    {
        bgmPlayer.volume = GameConfig.Instance.bgmVolume;
        sfxPlayer.volume = GameConfig.Instance.sfxVolume;
    }

}