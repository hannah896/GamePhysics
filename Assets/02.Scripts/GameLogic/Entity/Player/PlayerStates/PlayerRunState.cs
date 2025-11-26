using UnityEngine;

public class PlayerRunState : PlayerStateBase
{
    private float speed = 10.0f;

    private float x;
    private float z;

    public PlayerRunState(StateMachine<PlayerStateBase> stateMachine, int animHashKey, PlayerController controller) : base(stateMachine, animHashKey, controller)
    {
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
        // 가만히 있으면 idle상태로 변경
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            StateMachine.ChangeState(animData.IdleState);
            return;
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            StateMachine.ChangeState(animData.WalkState);
            return;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }
}