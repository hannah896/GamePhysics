using System.Collections.Generic;
using UnityEngine;

public class UIPanel : UIPopup
{
    public override void Init()
    {
        base.Init();
        Managers.Resource.Instantiate(Managers.UI.path["BG"], go =>
        {
            go.transform.SetParent(transform);
            Util.Log("BG 생성되나요");
        });
    }

    public override void Releases()
    {
        base.Releases();
    }
}
