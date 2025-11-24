using UnityEngine;

public class PlayerRunState : PlayerStateBase
{
    private float speed = 40.0f;
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

    }

    public override void Update()
    {
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

        Vector3 move = Vector3.zero;

        if (Input.GetAxis("Horizontal") != 0)
        {
            move += Input.GetAxis("Horizontal") * Vector3.right;
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            move += Input.GetAxis("Vertical") * Vector3.forward;
        }

        rb.MovePosition(transform.position + move * Time.deltaTime * speed);
    }
}