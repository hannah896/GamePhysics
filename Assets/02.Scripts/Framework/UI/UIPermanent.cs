using System.Collections.Generic;
using UnityEngine;

public class UIPermanent : UI_Base
{
    public override void Init()
    {
        if (!Managers.UI.UIPermanentDIct.TryGetValue(GetType(), out List<GameObject> list))
        {
            Managers.UI.UIPermanentDIct.Add(GetType(), new List<GameObject>());
            list = Managers.UI.UIPermanentDIct[GetType()];
        }
        list.Add(gameObject);
    }

    public override void Releases()
    {
        Managers.UI.CloseStaticUI(GetType(), gameObject);
        base.Releases();
    }
}