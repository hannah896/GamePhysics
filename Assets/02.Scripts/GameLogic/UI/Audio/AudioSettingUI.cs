using UnityEngine;

public class AudioSettingUI : UIPanel
{
    [SerializeField] private AudioSliderUI ALLSlider;
    [SerializeField] private AudioSliderUI BGMSlider;
    [SerializeField] private AudioSliderUI SFXSlider;

    public override void Init()
    {
        base.Init();

        //UI_Base.BindEvent(ALLSlider.gameObject, evt =>
        //{
        //    ALLSlider.SetALL(ALLSlider.Targetvalue);
        //}, Enums.UIEvent.Drag);

        //UI_Base.BindEvent(BGMSlider.gameObject, evt =>
        //{
        //    BGMSlider.SetBGM(BGMSlider.Targetvalue);
        //}, Enums.UIEvent.Drag);

        //UI_Base.BindEvent(SFXSlider.gameObject, evt =>
        //{
        //    SFXSlider.SetSFX(SFXSlider.Targetvalue);
        //}, Enums.UIEvent.Drag);

        ALLSlider.Slider.onValueChanged.AddListener((value) =>
        {
            ALLSlider.SetALL(value);
        });

        BGMSlider.Slider.onValueChanged.AddListener((value) =>
        {
            BGMSlider.SetBGM(value);
        });

        SFXSlider.Slider.onValueChanged.AddListener((value) =>
        {
            SFXSlider.SetSFX(value);
        });

        ALLSlider.SetValue(Managers.Audio.Data.ALL);
        BGMSlider.SetValue(Managers.Audio.Data.BGM);
        SFXSlider.SetValue(Managers.Audio.Data.SFX);
    }
}