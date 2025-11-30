using UnityEngine;
using static Enums;

public class Trap5Scene : SceneBase
{
    public Trap5Scene()
    {
        num = SceneNumber.Trap5;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        Cursor.visible = false;
        // esc UI 로드
        _ = Managers.Resource.LoadAsync<GameObject>("GameScene/PauseUI", go =>
        {
            if (!Managers.UI.path.ContainsKey(typeof(PauseUI)))
                Managers.UI.path.Add(typeof(PauseUI), "GameScene/PauseUI");
        });

        // esc Blur 로드
        Managers.Cam.Init();

        // BGM 재생.
        Managers.Audio.Controller.PlayBGM(BGMName.Game);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
    public override void FixedUpdate()
    {

    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Managers.UI.ShowUI<PauseUI>();
            Cursor.visible = true;
        }
    }
}