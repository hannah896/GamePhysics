using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class UILevel : UI_Button
{
    [SerializeField] private Button Easy;
    [SerializeField] private Button Normal;
    [SerializeField] private Button Hard;

    public override void Init()
    {
        if (Easy != null)
            button = Easy;
        else if (Normal != null)
            button = Normal;
        else if (Hard != null)
            button = Hard;

        targetValue = button == Easy ? 1 : button == Normal ? 2 : 3;
        base.Init();
    }

    public override void OnClickButton(int value)
    {
        base.OnClickButton();
        Managers.Game.Init((Level)value);
        Util.Log(value.ToString());
    }
}