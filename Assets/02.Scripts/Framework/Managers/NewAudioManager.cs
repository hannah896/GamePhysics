using System;
using UnityEngine.Audio;
using UnityEngine;
using static Enums;

public class NewAudioManager
{
    public AudioController Controller = new();
    public AudioMixer Mixer;

    /// <summary>
    /// 오디오 매니저 초기화 메서드
    /// </summary>
    public void Init(AudioMixer mixer)
    {
        Mixer = mixer;
    }

    public void SetVolume(SoundType type, float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        switch (type)
        {
            case SoundType.Master:
                Mixer.SetFloat("Master", dB);
                break;
            case SoundType.BGM:
                Mixer.SetFloat("BGM", dB);
                break;
            case SoundType.SFX:
                Mixer.SetFloat("SFX", dB);
                break;
        }
    }
}