using UnityEngine;
using UnityEngine.UI;

public class AudioSettingUI : UIPopup
{
    [SerializeField] private AudioSliderUI ALLScrollbar;
    [SerializeField] private AudioSliderUI BGMScrollbar;
    [SerializeField] private AudioSliderUI SFXScrollbar;

    public override void Init()
    {
        base.Init();

        UIBase.BindEvent(ALLScrollbar.gameObject, evt =>
        {
            ALLScrollbar.SetALL(ALLScrollbar.Targetvalue);
        }, Enums.UIEvent.Drag);

        UIBase.BindEvent(BGMScrollbar.gameObject, evt =>
        {
            BGMScrollbar.SetBGM(BGMScrollbar.Targetvalue);
        }, Enums.UIEvent.Drag);
        
        UIBase.BindEvent(SFXScrollbar.gameObject, evt =>
        {
            SFXScrollbar.SetSFX(SFXScrollbar.Targetvalue);
        }, Enums.UIEvent.Drag);
    }
}