using System;
using UnityEngine.Audio;
using UnityEngine;
using static Enums;
using static UnityEngine.Rendering.DebugUI;

public class AudioManager
{
    private VolumeDate data;

    public AudioController Controller = new();
    public AudioMixer Mixer;
    
    public VolumeDate Data { get => data; }

    /// <summary>
    /// 오디오 매니저 초기화 메서드
    /// </summary>
    public void Init(AudioMixer mixer, VolumeDate data)
    {
        Mixer = mixer;
        this.data = data;

        SettingData();
    }

    public void SettingData()
    {
        SetVolume(SoundType.Master, data.ALL);
        SetVolume(SoundType.BGM, data.BGM);
        SetVolume(SoundType.SFX, data.SFX);
    }

    public void SetVolume(SoundType type, float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        switch (type)
        {
            case SoundType.Master:
                Mixer.SetFloat("Master", dB);
                
                Mixer.GetFloat("Master", out float val);
                Util.Log(val.ToString());
                
                data.ALL = value;
                break;
            case SoundType.BGM:
                Mixer.SetFloat("BGM", dB);

                Mixer.GetFloat("BGM", out float v);
                Util.Log(v.ToString());
                
                data.BGM = value;
                break;
            case SoundType.SFX:
                Mixer.SetFloat("SFX", dB);

                Mixer.GetFloat("SFX", out float va);
                Util.Log(va.ToString());

                data.SFX = value;
                break;
        }
    }
}