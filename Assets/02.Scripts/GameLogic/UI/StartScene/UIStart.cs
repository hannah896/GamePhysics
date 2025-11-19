using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIStart : UIButton
{
    [SerializeField] private Button StartUI;

    public override void Init()
    {
        button = StartUI;
        base.Init();
    }

    public override void OnClickButton()
    {
        base.OnClickButton();
        transform.parent.parent.DOMoveX(-1635, 0.5f).SetEase(Ease.OutExpo);
    }
}