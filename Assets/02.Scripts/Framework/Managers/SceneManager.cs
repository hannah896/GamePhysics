using UnityEngine;

public class SceneManager : StateMachine<SceneBase>
{
    public override SceneBase CurrentState { get; protected set; }

    public StartScene StartScene { get; private set; } = new StartScene();
    public CorrectScene CorrectScene { get; private set; } = new CorrectScene();
    
    //public Trap1Scene Trap1Scene { get; private set; } = new Trap1Scene();
    //public Trap2Scene Trap2Scene { get; private set; } = new Trap2Scene();

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