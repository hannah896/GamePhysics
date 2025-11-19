using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.XR;
using static Enums;


public class StartScene : SceneBase
{

    public async override void OnEnter()
    {
        base.OnEnter();

        //UI 로드
        Managers.Resource.LoadAsync<GameObject>("StartScene/StartUI", go =>
        {
            Managers.UI.path.Add(go.name, "StartScene/StartUI");
            Managers.UI.ShowUI(go.name);
        });

        //Audio 믹서 로드
        Managers.Resource.LoadAsync<AudioMixer>("Sound", mixer =>
        {
            Managers.Audio.Init(mixer);
        });

        //BGM, SFX 로드
        Managers.Resource.LoadAsync<SceneBGM>("Start/StartBGM", so =>
        {
            Managers.Audio.Controller.InitBGM(so, BGMName.Dance);
        });
        Managers.Resource.LoadAsync<SceneSFX>("Start/StartSFX", so =>
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
