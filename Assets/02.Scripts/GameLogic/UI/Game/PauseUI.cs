using UnityEngine;

public class PauseUI : UIPermanent
{
    public override void Init()
    {
        base.Init();
        Managers.Cam.Volume.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public override void Releases()
    {
        base.Releases();
    }
}
