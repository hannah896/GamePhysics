using UnityEngine;

public class PlayerAnimationData
{
    #region ParameterName
    private string idleParameterName = "Idle";
    private string DeadParameterName = "Dead";
    private string walkParameterName = "Walk";
    private string RunParameterName = "Run";
    private string DanceParameterName = "Dance";
    #endregion

    #region HashProperty
    protected int IdleHash { get; set; }
    protected int DeadHash { get; set; }
    protected int WalkHash { get; set; }
    protected int RunHash { get; set; }
    protected int DanceHash { get; set; }
    #endregion

    #region State
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerDanceState DanceState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    #endregion

    public StateMachine<PlayerStateBase> StateMachine { get; protected set; }

    public void Init(PlayerController controller = null)
    {
        StateMachine = new();

        IdleHash = Animator.StringToHash(idleParameterName);
        WalkHash = Animator.StringToHash(walkParameterName);
        RunHash = Animator.StringToHash(RunParameterName);
        DanceHash = Animator.StringToHash(DanceParameterName);
        DeadHash = Animator.StringToHash(DeadParameterName);

        IdleState = new PlayerIdleState(StateMachine, IdleHash, controller);
        WalkState = new PlayerWalkState(StateMachine, WalkHash, controller);
        RunState = new PlayerRunState(StateMachine, RunHash, controller);
        DanceState = new PlayerDanceState(StateMachine, DanceHash, controller);
        DeadState = new PlayerDeadState(StateMachine, DeadHash, controller);

        StateMachine.Init(IdleState);
    }
}