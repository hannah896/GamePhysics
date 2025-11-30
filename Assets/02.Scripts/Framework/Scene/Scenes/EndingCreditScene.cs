using static Enums;

public class EndingCreditScene : SceneBase
{
    public EndingCreditScene()
    {
        num = Enums.SceneNumber.EndingCredit;
    }

    public override void FixedUpdate()
    {
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
    }
}
