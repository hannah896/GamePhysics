using UnityEngine;
using static Enums;

public class EndingCreditScene : SceneBase
{
    public EndingCreditScene()
    {
        num = Enums.SceneNumber.EndingCredit;
    }

    public override void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Managers.Audio.Controller.PlayBGM(BGMName.EndingCredit);
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }


}
