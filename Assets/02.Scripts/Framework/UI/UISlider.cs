using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class UISlider : UIPermanent
{
    protected Scrollbar scroll;
    protected int targetValue;

    private void Awake()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        scroll.onValueChanged.AddListener(OnChangeValue);
    }

    public virtual void OnChangeValue(float value)
    {
        Managers.Audio.Controller.PlaySFX(Enums.SFXName.Click);
    }
}