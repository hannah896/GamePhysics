using UnityEngine;

public class SceneManager : StateMachine<SceneBase>
{

    /// <summary>
    /// 씬 전환 메서드
    /// </summary>
    public override void ChangeState(SceneBase Nextstate)
    {
        base.ChangeState(Nextstate);
    }
}