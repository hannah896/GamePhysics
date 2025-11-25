using System.Collections.Generic;
using UnityEngine;

public class UIPanel : UIPopup
{
    public override void Init()
    {
        base.Init();
        Managers.UI.ShowUI<UI_BG>(false, go =>
        {
            transform.SetParent(go.transform, false);
            Util.Log(transform.parent.ToString());
            Util.Log("BG 생성되나요");
            go.GetComponent<UI_BG>().child = GetType();
        });
    }

    public override void Releases()
    {
        base.Releases();
    }
}
