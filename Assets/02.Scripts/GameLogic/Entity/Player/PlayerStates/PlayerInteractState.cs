using UnityEngine;
using UnityEngine.XR;

public class PlayerInteractState : PlayerStateBase
{
    private float x;
    private float z;
    public PlayerInteractState(StateMachine<PlayerStateBase> stateMachine, int animHashKey, PlayerController controller) : base(stateMachine, animHashKey, controller)
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

        rb.MovePosition(rb.position + move * 10.0f * Time.fixedDeltaTime);
    }

    public override void Update()
    {
        base.Update();

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }
}