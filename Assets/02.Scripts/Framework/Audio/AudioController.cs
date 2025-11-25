using System;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class AudioController
{
    private Dictionary<BGMName, AudioClip> bgmData = new();
    private Dictionary<SFXName, AudioClip> sfxData = new();

    private AudioSource bgmAudioSource;
    private List<AudioSource> sfxAudioSources = new();

    public void InitBGM(SceneBGM so, BGMName startBGM)
    {
        // 딕셔너리에 싹다 등록
        foreach (var bgm in so.audioClips)
        {
            bgmData.Add(bgm._name, bgm._audioClip);
        }
        PlayBGM(startBGM);
        Managers.Audio.SettingData();
    }


    public void InitSFX(SceneSFX so)
    {
        // 딕셔너리에 싹다 등록
        foreach (var sfx in so.audioClips)
        {
            sfxData.Add(sfx._name, sfx._audioClip);
        }
    }

    /// <summary>
    /// BGM 재생
    /// </summary>
    /// <param name="bgmName"></param>
    public void PlayBGM(BGMName bgmName)
    {
        if (!bgmData.TryGetValue(bgmName, out AudioClip bgm))
        {
            Util.LogError("그딴 BGM 로드 안해놨다.");
            return;
        }

        Managers.Resource.Instantiate("BGMObj", go =>
        {
            var audio = go.GetComponent<AudioObj>();
            bgmAudioSource = audio.audioSource;

            audio.Init(bgm);
            audio.audioSource.loop = true;
            bgmAudioSource.Play();
            Managers.Audio.SettingData();
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

    /// <summary>
    /// 새로운 씬 로드 시 오디오 데이터 클리어 할라고 만든 메서드 
    /// </summary>
    public void Clear()
    {
        bgmAudioSource.Stop();
        bgmData.Clear();
        sfxData.Clear();
    }
}