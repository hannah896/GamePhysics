using System.Collections.Generic;
using UnityEngine;

public abstract class UIPopup : UIBase
{
    public override void Init()
    {
        if (Managers.UI.UIPopupDIct.TryGetValue(this, out Stack<GameObject> stack))
        {
            stack.Push(gameObject);
        }
        else
        {
            Managers.UI.UIPopupDIct.Add(this, new Stack<GameObject>());
            Managers.UI.UIPopupDIct[this].Push(gameObject);
        }
    }

    public override void Releases()
    {
        Managers.UI.ClosePopupUI<UIPopup>(this);
        base.Releases();
    }
}
