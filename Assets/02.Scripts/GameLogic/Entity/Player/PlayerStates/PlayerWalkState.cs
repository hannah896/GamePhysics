using UnityEngine;

public class PlayerWalkState : PlayerStateBase
{
    private float speed = 5.0f;
    private float x;
    private float z;

    public PlayerWalkState(StateMachine<PlayerStateBase> stateMachine, int animHashKey, PlayerController controller) : base(stateMachine, animHashKey, controller)
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

        Vector3 move = Vector3.zero;

        // 입력은 Update에서 받아왔다고 가정(h, v)
        move += x * transform.right;
        move += z * transform.forward;

        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }


    public override void Update()
    {
        base.Update();
        // 가만히 있으면 대기 상태
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            StateMachine.ChangeState(animData.IdleState);
            return;
        }

        // 시프트 누르면 달리기 상태
        if ((Input.GetKeyDown(KeyCode.LeftShift) && Input.GetAxis("Horizontal") != 0)
            || (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetAxis("Vertical") != 0))
        {
            StateMachine.ChangeState(animData.RunState);
            return;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

}
