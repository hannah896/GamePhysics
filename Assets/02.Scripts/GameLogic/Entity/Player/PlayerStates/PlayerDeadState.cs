using UnityEngine;

public class PlayerDeadState : PlayerStateBase
{
    public PlayerDeadState(StateMachine<PlayerStateBase> stateMachine, int animHashKey, PlayerController controller) : base(stateMachine, animHashKey, controller)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Controller.AnimTrigger += Reload;
    }

    public override void OnExit()
    {
        Controller.AnimTrigger -= Reload;
        base.OnExit();
    }

    public override void FixedUpdate()
    {
    }

    public override void Update()
    {
    }

    private void Reload()
    {
        Managers.Game.Check(false);
    }
}