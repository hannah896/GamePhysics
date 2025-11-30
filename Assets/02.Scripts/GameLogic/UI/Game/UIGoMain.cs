public class UIGoMain : UI_Button
{
    public override void Init()
    {
        base.Init();
    }

    public override void OnClickButton()
    {
        base.OnClickButton();
        Managers.Scene.ChangeState(Managers.Scene.StartScene);
    }

    public override void OnClickButton(int value)
    {
        base.OnClickButton(value);
    }
}
