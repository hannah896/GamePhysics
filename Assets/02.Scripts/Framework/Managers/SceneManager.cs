using UnityEngine;

public class SceneManager : StateMachine<SceneBase>
{
    public override SceneBase CurrentState { get; protected set; }
    
    public void Init()
    {
        CurrentState = new StartScene
    }
    /// <summary>
    /// 씬 전환 메서드
    /// </summary>
    public override void ChangeState(SceneBase Nextstate)
    {
        base.ChangeState(Nextstate);
        CurrentState = Nextstate;
    }
}