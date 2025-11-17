using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class AudioController
{
    private Dictionary<BGMName, BGMData> bgmData = new();
    private Dictionary<SFXName, SFXData> sfxData = new();

    public GameObject Master { get; private set; }
    public GameObject SFX { get; private set; }
    public GameObject BGM { get; private set; }

    /// <summary>
    /// 오디오 컨트롤러 초기화
    /// 최초 1번만 해야함.. 씬 바뀔때 마다하면 난 책임 못짐
    /// </summary>
    /// <param name="data"></param>
    public void Init()
    {
        SetData();

        Managers.Audio.ApplyMasterVolume += ApplySFXVolume;
        Managers.Audio.ApplyMasterVolume += ApplyBGMVolume;
        Managers.Audio.ApplySFXVolume += ApplySFXVolume;
        Managers.Audio.ApplyBGMVolume += ApplyBGMVolume;

        Managers.Audio.ChangeScene += KillChildren;

        Master = new GameObject(nameof(Master));
        SFX = new GameObject(nameof(SFX));
        BGM = new GameObject(nameof(BGM));

        MonoBehaviour.DontDestroyOnLoad(Master);
        MonoBehaviour.DontDestroyOnLoad(SFX);
        MonoBehaviour.DontDestroyOnLoad(BGM);
    }

    /// <summary>
    /// 초기 오디오 데이터 세팅
    /// </summary>
    /// <param name="data"></param>
    public void SetData()
    {
        //for (int i = 0; i < (int)BGMName.Count; i++)
        //{
        //    bgmData.Add(
        //        (BGMName)i //브금 번호
        //        , Managers.Resource.Load<BGMData> //브금 리소스 가져오기
        //        (
                    
        //        ));
        //}

        //for (int i = 0; i < (int)SFXName.Count; i++)
        //{
        //    sfxData.Add((SFXName)i, Managers.Resource.Load<SFXData>(((SFXName)i).ToString()));
        //}
    }

    /// <summary>
    /// 사운드 타입별 볼륨세팅 메서드
    /// </summary>
    /// <param name="type"></param>
    public void SetVolume(SoundType type, float value)
    {
        switch (type)
        {
            case SoundType.Master:
                ApplyBGMVolume(value);
                ApplySFXVolume(value);
                break;
            case SoundType.BGM:
                ApplyBGMVolume(value);
                break;
            case SoundType.SFX:
                ApplySFXVolume(value);
                break;
        }
    }

    /// <summary>
    /// SFX 오디오 생성 메서드
    /// </summary>
    /// <param name="sfx"></param>
    public void CreateAudio(SFXName sfx)
    {
        Managers.Resource.Instantiate(nameof(AudioObj), go =>
        {
            go.GetComponent<AudioObj>().Init<SFXData>(sfxData[sfx]);
            go.transform.SetParent(SFX.transform);
        });
    }

    /// <summary>
    /// BGM 오디오 생성 메서드
    /// </summary>
    /// <param name="bgm"></param>
    public void CreateAudio(BGMName bgm)
    {
        Managers.Resource.Instantiate(nameof(AudioObj), go =>
        {
            go.GetComponent<AudioObj>().Init<BGMData>(bgmData[bgm], true);
            go.transform.SetParent(BGM.transform);
        });
    }

    /// <summary>
    /// BGM 볼륨 적용 메서드
    /// </summary>
    /// <param name="value"></param>
    private void ApplyBGMVolume(float value)
    {
        foreach (var key in bgmData.Keys)
        {
            bgmData[key].SetVolume(value);
        }
    }

    /// <summary>
    /// SFX 볼륨 적용 메서드
    /// </summary>
    /// <param name="value"></param>
    private void ApplySFXVolume(float value)
    {
        foreach (var key in sfxData.Keys)
        {
            sfxData[key].SetVolume(value);
        }
    }

    private void KillChildren()
    {
        foreach(Transform child in SFX.transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }
    }
}