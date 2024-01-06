using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private List<AudioClip> _clips = new List<AudioClip>();
    private Dictionary<string, AudioClip> _audioDic = new Dictionary<string, AudioClip>();
    
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple SoundManager is running");
        Instance = this;
    }

    private void Start()
    {
        foreach (var clip in _clips)
            _audioDic.Add(clip.name, clip);
    }

    public void PlaySound(string str)
    {
        AudioPlayer audioPlayer = PoolManager.Instance.Pop("AudioPlayer") as AudioPlayer;
        if (_audioDic.TryGetValue(str, out AudioClip audio) != null)
            audioPlayer.AudioPlay(audio);
    }
    
    public void PlaySound(AudioClip clip) 
    {
        AudioPlayer audioPlayer = PoolManager.Instance.Pop("AudioPlayer") as AudioPlayer;
        audioPlayer.AudioPlay(clip);
    }
}