using UnityEngine;
using UnityEngine.XR;

public class PlayerDanceState : PlayerStateBase
{
    private float x;
    private float z;
    public PlayerDanceState(StateMachine<PlayerStateBase> stateMachine, int animHashKey, PlayerController controller) : base(stateMachine, animHashKey, controller)
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

        move += x * transform.right;
        move += z * transform.forward;

        rb.MovePosition(rb.position + move * 3.0f * Time.fixedDeltaTime);
    }

    public override void Update()
    {
        base.Update();

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }
}