using System;
using UnityEngine.Audio;
using UnityEngine;
using static Enums;

public class NewAudioManager
{
    private AudioController controller = new();
    public AudioMixer Mixer;

    /// <summary>
    /// 오디오 매니저 초기화 메서드
    /// </summary>
    public void Init()
    {
        Mixer = Resources.Load<AudioMixer>("Assets/08.SO/Audio/Sound.mixer");
    }

    /// <summary>
    /// 마스터 볼륨 세팅 메서드
    /// </summary>
    /// <param name="value"></param>
    public void SetMasterVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        Mixer.SetFloat("Master", dB);
    }

    /// <summary>
    /// BGM 볼륨 세팅 메서드
    /// </summary>
    /// <param name="value"></param>
    public void SetBGMVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        Mixer.SetFloat("BGM", dB);
    }

    /// <summary>
    /// SFX 볼륨 세팅 메서드
    /// </summary>
    /// <param name="value"></param>
    public void SetSFXVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        Mixer.SetFloat("SFX", dB);
    }
}