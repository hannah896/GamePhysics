using UnityEngine;

public class PlayerWalkState : PlayerStateBase
{
    private float speed = 20.0f;

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

    }

    public override void Update()
    {
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
