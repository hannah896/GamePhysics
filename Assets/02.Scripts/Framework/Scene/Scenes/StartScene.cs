using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.XR;
using static Enums;


public class StartScene : SceneBase
{
    // 생성자에서 상속받은 필드에 값 할당
    public StartScene()
    {
        num = SceneNumber.Start;
    }

    public async override void OnEnter()
    {
        base.OnEnter();

        // UI 로드
        _ = Managers.Resource.LoadAsync<GameObject>("StartScene/StartUI", go =>
        {
            Managers.UI.path.Add(typeof(UIStart), "StartScene/StartUI");
            Managers.UI.ShowUI<UIStart>();
        });

        _ = Managers.Resource.LoadAsync<GameObject>("Common/AudioSettingUI", go =>
        {
            Managers.UI.path.Add(typeof(AudioSettingUI), "Common/AudioSettingUI");
            _ = Managers.Resource.LoadAsync<GameObject>("Common/BG", go =>
            {
                Managers.UI.path.Add(typeof(UI_BG), "Common/BG");
            });
        });

        // Audio 믹서 로드
        await Managers.Resource.LoadAsync<AudioMixer>("Sound", async mixer =>
        {
            await Managers.Resource.LoadAsync<VolumeDate>("VolumeDate", volumeData =>
            {
                Managers.Audio.Init(mixer, volumeData);
            });
        });

        // BGM, SFX 로드
        await Managers.Resource.LoadAsync<SceneBGM>("Start/StartBGM", so =>
        {
            Managers.Audio.Controller.InitBGM(so, BGMName.Dance);
        });
        await Managers.Resource.LoadAsync<SceneSFX>("Start/StartSFX", so =>
        {
            Managers.Audio.Controller.InitSFX(so);
        });
    }

    public override void OnExit()
    {
        base.OnExit();
        Managers.Audio.Controller.Clear();
    }

    public override void FixedUpdate()
    {

    }

    public override void Update()
    {

    }
}
