using System.Collections.Generic;
using UnityEngine;

public class UIPermanent : UIBase
{
    public override void Init()
    {
        Managers.UI.UIPermanentDIct.Add(this, gameObject);
    }

    public override void Releases()
    {
        Managers.UI.CloseStaticUI<UIPermanent>(this);
        base.Releases();
    }
}