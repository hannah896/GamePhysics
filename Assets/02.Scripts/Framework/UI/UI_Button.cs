using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Enums;

[RequireComponent(typeof(Button))]
public abstract class UI_Button : UIPermanent
{
    protected Button button;
    protected int targetValue; 

    private void Awake()
    {
        Init();
    }

    //public override void Init()
    //{
    //    base.Init();
        
    //    button.onClick.AddListener(OnClickButton);
    //    button.onClick.AddListener(() => OnClickButton(targetValue));
    //}


    public override void Init()
    {
        base.Init();
        UI_Base.BindEvent(gameObject, evt =>
        {
            // 기존 첫 번째 기능
            OnClickButton();

            // 기존 두 번째 기능
            OnClickButton(targetValue);
        }, UIEvent.Click);
    }

    public virtual void OnClickButton()
    {
        Managers.Audio.Controller.PlaySFX(Enums.SFXName.Click);
    }

    public virtual void OnClickButton(int value)
    {
        Managers.Game.Correct();
    }
}
