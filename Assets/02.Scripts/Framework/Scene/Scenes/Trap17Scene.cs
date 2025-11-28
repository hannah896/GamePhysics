using UnityEngine;
using static Enums;

public class Trap17Scene : SceneBase
{
    public Trap17Scene()
    {
        num = SceneNumber.Trap17;
    }


    public override void OnEnter()
    {
        base.OnEnter();
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
        }
    }
}