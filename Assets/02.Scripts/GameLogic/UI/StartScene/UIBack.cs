using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIBack : UIButton
{
    [SerializeField] private Button BackUI;

    public override void Init()
    {
        button = BackUI;
        base.Init();
    }

    public override void OnClickButton()
    {
        base.OnClickButton();
        transform.parent.parent.DOMoveX(285, 0.5f).SetEase(Ease.OutExpo);
    }
}