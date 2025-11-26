using UnityEngine;

public class SceneManager : StateMachine<SceneBase>
{
    public override SceneBase CurrentState { get; protected set; }

    /// <summary>
    /// 씬 매니저 초기화 메서드(게임 아예 처음 시작할때 쓰는 거)
    /// </summary>
    public void Init()
    {
        CurrentState = new StartScene();
        CurrentState.OnEnter();
    }

    /// <summary>
    /// 씬 전환 메서드
    /// </summary>
    public override void ChangeState(SceneBase Nextstate)
    {
        CurrentState.OnExit();

        base.ChangeState(Nextstate);
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Nextstate.num);
    }
}