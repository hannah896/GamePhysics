using UnityEngine;
using UnityEngine.UI;

public class AudioSliderUI : UIPermanent
{
    [SerializeField] private Scrollbar scroll;
    public float Targetvalue { get { return scroll.value; } }

    private void Awake()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
    }

    public void SetALL(float value)
    {
        Managers.Audio.SetMasterVolume(value);
    }
    
    public void SetBGM(float value)
    {
        Managers.Audio.SetBGMVolume(value);
    }

    public void SetSFX(float value)
    {
        Managers.Audio.SetSFXVolume(value);
    }
}
