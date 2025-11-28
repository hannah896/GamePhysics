using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using static Enums;

public class CorrectScene : SceneBase
{
    public CorrectScene()
    {
        num = SceneNumber.Correct;
    }

    public async override void OnEnter()
    {

        base.OnEnter();
        // esc UI 로드
        _ = Managers.Resource.LoadAsync<GameObject>("GameScene/PauseUI", go =>
        {
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
