using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class AudioController
{
    private Dictionary<BGMName, AudioClip> bgmData = new();
    private Dictionary<SFXName, AudioClip> sfxData = new();

    private AudioSource bgmAudioSource;
    private List<AudioSource> sfxAudioSources = new();

    public void InitBGM(BGMData so, BGMName startBGM)
    {
        // 딕셔너리에 싹다 등록
        foreach (var bgm in so.audioClips)
        {
            if (!bgmData.ContainsKey(bgm._name))
                bgmData.Add(bgm._name, bgm._audioClip);
        }
        Managers.Audio.SettingData();
        PlayBGM(startBGM);
    }


    public void InitSFX(SFXData so)
    {
        // 딕셔너리에 싹다 등록
        foreach (var sfx in so.audioClips)
        {
            if (!sfxData.ContainsKey(sfx._name))
                sfxData.Add(sfx._name, sfx._audioClip);
        }
    }

    /// <summary>
    /// BGM 재생
    /// </summary>
    /// <param name="bgmName"></param>
    public async void PlayBGM(BGMName bgmName)
    {
        if (!bgmData.TryGetValue(bgmName, out AudioClip bgm))
        {
            Util.LogError("그딴 BGM 로드 안해놨다.");
            return;
        }

        Util.Log("BGM을 틀어보께~");
        Managers.Resource.Instantiate("BGMObj", go =>
        {
            var audio = go.GetComponent<AudioObj>();
            bgmAudioSource = audio.audioSource;

            audio.Init(bgm);
            bgmAudioSource.outputAudioMixerGroup = Managers.Audio.Mixer.FindMatchingGroups("BGM")[0];
            audio.audioSource.loop = true;

            Util.Log("BGM 재생되나요");
            bgmAudioSource.Play();
        });
    }

    /// <summary>
    /// SFX 재생
    /// </summary>
    /// <param name="sfxName"></param>
    public void PlaySFX(SFXName sfxName)
    {
        if (!sfxData.TryGetValue(sfxName, out AudioClip sfx))
        {
            Util.LogError("그딴 SFX 로드 안해놨다.");
            return;
        }

        Util.Log("재생버튼은 눌렸음!!!!!!");
        Managers.Resource.Instantiate("SFXObj", go =>
        {
            Util.Log("오디오 오브젝트 생성 완료!!!!!!");
            var audio = go.GetComponent<AudioObj>();
            audio.Init(sfx);
            sfxAudioSources.Add(audio.audioSource);
            audio.SFXPlay();
        });
    }
}