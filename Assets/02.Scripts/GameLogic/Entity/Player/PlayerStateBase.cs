using UnityEngine;
using UnityEngine.InputSystem.XR;

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
    protected float speed = 0.0f;


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
        speed = controller.Speed;
    }

    public override void OnEnter()
    {
        Anim.SetBool(animHashKey, true);
    }

    public override void OnExit()
    {
        Anim.SetBool(animHashKey, false);
    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {

    }
}
