using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

public class StartScene : SceneBase
{

    public async override void OnEnter()
    {
        var t1 = Managers.Resource.LoadAsync<AudioClip>("Assets/99.Resources/Audios/Resources/DanceMusic.wav");
        var t2 = Managers.Resource.LoadAsync<AudioMixer>("Assets/08.SO/Audio/Sound.mixer");
        var t3 = Managers.Resource.LoadAsync<AudioClip>("Assets/03.Prefabs/Map/Correct");

        await UniTask.WhenAll(t1, t2, t3);
        Managers.Resource.Instantiate("Assets/99.Resources/Audios/Resources/DanceMusic.wav", Managers.);
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
