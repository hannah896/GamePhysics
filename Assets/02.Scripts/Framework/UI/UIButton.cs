using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class UIButton : UIPermanent
{
    protected Button button;
    protected int targetValue;

    private void Awake()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        button.onClick.AddListener(OnClickButton);
        button.onClick.AddListener(() => OnClickButton(targetValue));
    }

    public virtual void OnClickButton()
    {
        Managers.Audio.Controller.PlaySFX(Enums.SFXName.Click);
    }

    public virtual void OnClickButton(int value)
    {

    }
}
