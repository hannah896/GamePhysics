using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class UI_BG : UI_Button
{
    [SerializeField] private Button BG;
    public System.Type child;

    public override void Init()
    {
        base.Init();
        UI_Base.BindEvent(gameObject, evt =>
        {
            OnClickButton();
        }, UIEvent.Click);
    }

    public override void OnClickButton()
    {
        base.OnClickButton();
        Managers.UI.CloseStaticUI(GetType(), gameObject);
        Managers.UI.ClosePopupUI(child);
    }
}
