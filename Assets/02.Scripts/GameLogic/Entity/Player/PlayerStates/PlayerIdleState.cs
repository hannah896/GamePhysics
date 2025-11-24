using UnityEngine;

public class PlayerIdleState : PlayerStateBase
{

    public PlayerIdleState(StateMachine<PlayerStateBase> stateMachine, int animHashKey, PlayerController controller) : base(stateMachine, animHashKey, controller)
    {
        controller.Speed = speed;
    }



    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        // 시프트 누르면 달리기 상태
        if ((Input.GetKeyDown(KeyCode.LeftShift) && Input.GetAxis("Horizontal") != 0)
            || (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetAxis("Vertical") != 0))
        {
            StateMachine.ChangeState(animData.RunState);
            return;
        }

        // 가만히 있으면 대기 상태
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            StateMachine.ChangeState(animData.WalkState);
            return;
        }
    }

}
