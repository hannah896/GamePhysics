using UnityEngine;
using UnityEngine.UI;

public class UIAudioOption : UI_Button
{
    [SerializeField] private Button OptionBtn;

    public override void Init()
    {
        button = OptionBtn;
        base.Init();
    }

    public override void OnClickButton()
    {
        base.OnClickButton();
        Managers.UI.ShowUI<AudioSettingUI>();
    }
}