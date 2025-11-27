using UnityEngine;

public class SceneManager : StateMachine<SceneBase>
{
    public override SceneBase CurrentState { get; protected set; }

    #region Scenes
    public StartScene StartScene { get; private set; } = new StartScene();
    public CorrectScene CorrectScene { get; private set; } = new CorrectScene();

    public Trap1Scene Trap1Scene { get; private set; } = new Trap1Scene();
    public Trap2Scene Trap2Scene { get; private set; } = new Trap2Scene();
    public Trap3Scene Trap3Scene { get; private set; } = new Trap3Scene();
    public Trap4Scene Trap4Scene { get; private set; } = new Trap4Scene();
    public Trap5Scene Trap5Scene { get; private set; } = new Trap5Scene();
    public Trap6Scene Trap6Scene { get; private set; } = new Trap6Scene();
    public Trap7Scene Trap7Scene { get; private set; } = new Trap7Scene();
    public Trap8Scene Trap8Scene { get; private set; } = new Trap8Scene();
    public Trap9Scene Trap9Scene { get; private set; } = new Trap9Scene();
    public Trap10Scene Trap10Scene { get; private set; } = new Trap10Scene();
    public Trap11Scene Trap11Scene { get; private set; } = new Trap11Scene();
    public Trap12Scene Trap12Scene { get; private set; } = new Trap12Scene();
    public Trap13Scene Trap13Scene { get; private set; } = new Trap13Scene();
    public Trap14Scene Trap14Scene { get; private set; } = new Trap14Scene();
    public Trap15Scene Trap15Scene { get; private set; } = new Trap15Scene();
    public Trap16Scene Trap16Scene { get; private set; } = new Trap16Scene();
    public Trap17Scene Trap17Scene { get; private set; } = new Trap17Scene();
    public Trap18Scene Trap18Scene { get; private set; } = new Trap18Scene();
    #endregion

    /// <summary>
    /// 씬 매니저 초기화 메서드(게임 아예 처음 시작할때 쓰는 거)
    /// </summary>
    public void Init()
    {
        CurrentState = StartScene;
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