using UnityEngine;

public class PlayerStateBase : StateBase
{
    protected Transform transform;
    protected Rigidbody rb;
    protected Collider col;

    protected Animator Anim { get; set; }
    protected Rigidbody2D Rigid { get; set; }

    protected StateMachine<PlayerStateBase> StateMachine { get; set; }
    protected PlayerAnimationData animData;
    protected PlayerController Controller { get; set; }

    protected int animHashKey;
    private float sensitivity = 0.2f;

    private float RotSum = 0f;

    public PlayerStateBase(StateMachine<PlayerStateBase> stateMachine, int animHashKey, PlayerController controller)
    {
        StateMachine = stateMachine;
        this.animHashKey = animHashKey;
        Controller = controller;
        transform = controller.transform;
        rb = controller.rb;
        col = controller.col;
        Anim = controller.Anim;
        animData = controller.AnimData;
        StateMachine = stateMachine;
        sensitivity = controller.Sensitivity;
    }

    public override void OnEnter()
    {
        Anim.SetBool(animHashKey, true);
    }

    public override void OnExit()
    {
        Anim.SetBool(animHashKey, false);
    }

    public override void FixedUpdate()
    {
        if (RotSum != 0)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, RotSum, 0f));
            RotSum = 0; // 초기화
        }
    }

    public override void Update()
    {
        Vector2 delta = Input.mousePositionDelta;

        float rotX = delta.x * sensitivity;

        // 누적만 Update에서 하고
        RotSum += rotX;
    }

}
