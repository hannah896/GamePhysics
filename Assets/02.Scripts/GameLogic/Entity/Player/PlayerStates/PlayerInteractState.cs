using UnityEngine;
using UnityEngine.XR;

public class PlayerInteractState : PlayerStateBase
{
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

    }

    public override void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 5.0f))
            {
                if (hitInfo.collider.CompareTag("Interactable"))
                {
                    Debug.Log("Interacted with " + hitInfo.collider.name);
                    StateMachine.ChangeState(animData.IdleState);
                }
            }
        }
    }
}
