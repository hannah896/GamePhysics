using System.Collections.Generic;
using UnityEngine;

public abstract class UIPopup : UI_Base
{
    public override void Init()
    {
        var type = GetType();
        
        if (Managers.UI.UIPopupDIct.TryGetValue(type, out Stack<GameObject> stack))
        {
            stack.Push(gameObject);
        }
        else
        {
            Managers.UI.UIPopupDIct.Add(type, new Stack<GameObject>());
            Managers.UI.UIPopupDIct[type].Push(gameObject);
        }
    }

    public override void Releases()
    {
        Managers.UI.ClosePopupUI(GetType());
        base.Releases();
    }
}
