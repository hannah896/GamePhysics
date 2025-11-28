using UnityEngine;
using static Enums;

public class EndingCreditScene : SceneBase
{
    public EndingCreditScene()
    {
        num = SceneNumber.EndingCredit;
    }

    public async override void OnEnter()
    {
        base.OnEnter();
        // BGM 재생.
        Managers.Audio.Controller.PlayBGM(BGMName.EndingCredit);
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