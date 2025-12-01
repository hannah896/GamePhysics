using UnityEngine;

public class UIClose : UI_Button
{
    public override void Init()
    {
        base.Init();
    }

    public override void OnClickButton()
    {
        base.OnClickButton();
        Cursor.visible = false;
        // 일시정지 UI 닫기
        Managers.Cam.Volume.gameObject.SetActive(false);
        Managers.UI.CloseStaticUI(typeof(PauseUI), transform.parent.parent.parent.parent.gameObject);
        Time.timeScale = 1f;
    }
}