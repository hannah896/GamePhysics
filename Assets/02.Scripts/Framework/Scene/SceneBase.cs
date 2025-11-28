using UnityEngine;
using static Enums;

public abstract class SceneBase : StateBase
{
    public SceneNumber num;

    /// <summary>
    /// 씬 로드 시에 실행되어야 하는 메서드
    /// </summary>
    public override void OnEnter()
    {
        Time.timeScale = 1f;
        Managers.UI.Init();
    }

    /// <summary>
    /// 씬 종료 시에 실행되어야 하는 메서드
    /// </summary>
    public override void OnExit()
    {

    }
}