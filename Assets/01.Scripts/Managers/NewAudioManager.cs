using System;
using static Enums;

public class NewAudioManager
{
    private AudioController controller = new();

    public Action<float> ApplyMasterVolume;
    public Action<float> ApplyBGMVolume;
    public Action<float> ApplySFXVolume;
    public Action ChangeScene;

    /// <summary>
    /// 오디오 매니저 초기화 메서드
    /// 게임 실행 최초1번만 실행해야함.
    /// </summary>
    public void Init()
    {
        controller.Init();
    }

    /// <summary>
    /// 단일 사운드 조절
    /// </summary>
    /// <param name="type"></param>
    /// <param name="volume"></param>
    public void SetVolume(SoundType type, float volume)
    {
        switch (type)
        {
            case SoundType.Master:
                ApplyMasterVolume?.Invoke(volume);
                break;
            case SoundType.BGM:
                ApplyBGMVolume?.Invoke(volume);
                break;
            case SoundType.SFX:
                ApplySFXVolume?.Invoke(volume);
                break;
        }
    }

    /// <summary>
    /// BGM 재생 메서드
    /// </summary>
    /// <param name="bgm"></param>
    public void PlayBGM(BGMName bgm)
    {
        controller.CreateAudio(bgm);
    }

    /// <summary>
    /// SFX 재생 메서드
    /// </summary>
    /// <param name="sfx"></param>
    public void PlaySFX(SFXName sfx)
    {
        controller.CreateAudio(sfx);
    }
}