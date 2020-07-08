using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour, IInitOnAwake, IInitOnStart {
    
    public AudioDatabase database;
    public List<string> playList = new List<string>();
    
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
        
        foreach(var item in playList) {
            if(database.AudioClips.ContainsKey(item)) {
                var data = database.AudioClips[item];
                if(data.type == GameAudioType.BGM) {
                    PlayBGM(item);
                }
            }
        }
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