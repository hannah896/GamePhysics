using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerAnimationData
{
    #region ParameterName
    private string idleParameterName = "Idle";
    private string DeadParameterName = "Dead";
    private string walkParameterName = "Walk";
    private string RunParameterName = "Run";
    private string InteractParameterName = "Interact";
    #endregion

    #region HashProperty
    protected int IdleHash { get; set; }
    protected int DeadHash { get; set; }
    protected int WalkHash { get; set; }
    protected int RunHash { get; set; }
    protected int InteractHash { get; set; }
    #endregion

    #region State
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerInteractState InteractState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    #endregion

    public StateMachine<PlayerStateBase> StateMachine { get; protected set; }

    public void Init(PlayerController controller = null)
    {
        StateMachine = new();

        IdleHash = Animator.StringToHash(idleParameterName);
        WalkHash = Animator.StringToHash(walkParameterName);
        RunHash = Animator.StringToHash(RunParameterName);
        InteractHash = Animator.StringToHash(InteractParameterName);
        DeadHash = Animator.StringToHash(DeadParameterName);

        IdleState = new PlayerIdleState(StateMachine, IdleHash, controller);
        WalkState = new PlayerWalkState(StateMachine, WalkHash, controller);
        RunState = new PlayerRunState(StateMachine, RunHash, controller);
        InteractState = new PlayerInteractState(StateMachine, InteractHash, controller);
        DeadState = new PlayerDeadState(StateMachine, DeadHash, controller);

        StateMachine.Init(IdleState);
    }
}