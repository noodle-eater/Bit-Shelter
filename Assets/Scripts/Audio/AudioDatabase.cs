using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioDatabase", menuName = "Bit Shelter/AudioDatabase", order = 0)]
public class AudioDatabase : ScriptableObject {
    
    [SerializeField]
    private List<ClipData> audio = new List<ClipData>();

    public Dictionary<string, ClipData> AudioClips = new Dictionary<string, ClipData>();

    private void OnEnable() {
        audio.ForEach(item => {
            AudioClips.Add(item.clip.name.ToLower(), item);
        });
    }

    public static AudioDatabase Get(string fileName) {
        return Resources.Load<AudioDatabase>(fileName);
    }

}
