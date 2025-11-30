using UnityEngine;
using static Enums;

public class CorrectScene : SceneBase
{
    public CorrectScene()
    {
        num = SceneNumber.Correct;
    }


    /// <summary>
    /// 이거 가내 수공업 부탁해!!!!
    /// </summary>
    public async override void OnEnter()
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


    /// <summary>
    /// 이거도 가내수공업 부탁해!!!
    /// </summary>
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Managers.UI.ShowUI<PauseUI>();
            Cursor.visible = true;
        }
    }
}
