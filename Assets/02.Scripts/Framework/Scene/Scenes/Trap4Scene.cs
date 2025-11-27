using UnityEngine;
using static Enums;

public class Trap4Scene : SceneBase
{
    public Trap4Scene()
    {
        num = SceneNumber.Trap4;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        // esc UI 로드
        //_ = Managers.Resource.LoadAsync<GameObject>("GameScene/GameScene", go =>
        //{
        //    Managers.UI.path.Add(typeof(UIStart), "StartScene/StartUI");
        //    Managers.UI.ShowUI<UIStart>();
        //});

        // BGM 재생.
        Managers.Audio.Controller.PlayBGM(BGMName.Game);
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
