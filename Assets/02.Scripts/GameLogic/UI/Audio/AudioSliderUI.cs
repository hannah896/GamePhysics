using UnityEngine;
using UnityEngine.UI;

public class AudioSliderUI : UIPopup
{
    [SerializeField] private Slider slider;
    public float Targetvalue { get { return slider.value; } }
    public Slider Slider { get { return slider; } }

    public override void Init()
    {
        base.Init();
    }

    public void SetALL(float value)
    {
        Managers.Audio.SetVolume(Enums.SoundType.Master, value);
    }
    
    public void SetBGM(float value)
    {
        Managers.Audio.SetVolume(Enums.SoundType.BGM, value);
    }

    public void SetSFX(float value)
    {
        Managers.Audio.SetVolume(Enums.SoundType.SFX, value);
    }
}
