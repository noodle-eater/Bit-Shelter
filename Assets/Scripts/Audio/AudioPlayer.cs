using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour, IInitOnAwake, IInitOnStart {
    
    public AudioDatabase database;
    public List<string> playList = new List<string>();
    
    private AudioSource bgmPlayer;
    private AudioSource switchSfx;
    private AudioSource completeSfx;

    public void InitOnAwake()
    {
        bgmPlayer = gameObject.AddComponent<AudioSource>();
        switchSfx = gameObject.AddComponent<AudioSource>();
        completeSfx = gameObject.AddComponent<AudioSource>();
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
        switchSfx.clip = database.GetAudio(sfxName);
        switchSfx.Play();
    }

    public void PlaySwitch() {
        PlaySFX("switch");
    }

    public void PlayComplete() {
        completeSfx.clip = database.GetAudio("complete");
        completeSfx.Play();
    }

    public void SetVolume()
    {
        bgmPlayer.volume = GlobalConfig.BgmVolume;
        switchSfx.volume = GlobalConfig.SfxVolume;
    }

}