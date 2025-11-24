using UnityEngine;

public class PlayerRunState : PlayerStateBase
{
    private float speed = 40.0f;
    public PlayerRunState(StateMachine<PlayerStateBase> stateMachine, int animHashKey, PlayerController controller) : base(stateMachine, animHashKey, controller)
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
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            StateMachine.ChangeState(animData.IdleState);
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

    public override void Update()
    {
        base.Update();
    }
}
