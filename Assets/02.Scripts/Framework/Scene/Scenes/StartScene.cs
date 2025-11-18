using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;


public class StartScene : SceneBase
{

    public async override void OnEnter()
    {
        base.OnEnter();

        // TODO : UI 프리펩 로드 & 생성 & 이벤트 시스템 생성
        var t1 = Managers.Resource.LoadAsync<GameObject>("StartScene/StartUI", go =>
        {
            Util.Log(go.name);
            Managers.UI.path.Add(go.name, "StartScene/StartUI");
            Util.Log(Managers.UI.path[go.name]);
            Managers.UI.ShowUI(go.name);
        });

        // TODO : BGM 로드 & 생성
        var t2 = Managers.Resource.LoadAsync<AudioMixer>("Assets/08.SO/Audio/Sound.mixer");
        var t3 = Managers.Resource.LoadAsync<AudioClip>("Assets/99.Resources/Audios/Resources/DanceMusic.wav");
        // TODO : SFX 로드
        //var t4 = Managers.Resource.LoadAsync<AudioClip>("Assets/03.Prefabs/Map/Correct");
        //await UniTask.WhenAll(t1/*, t2, t3*/);

        //// TODO : 배경 재생

    }


    public override void OnExit()
    {
        base.OnExit();
    }

    public override void FixedUpdate()
    {

    }

    public override void Update()
    {

    }
}
