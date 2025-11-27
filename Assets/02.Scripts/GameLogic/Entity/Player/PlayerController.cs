using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    #region PlayerInfo
    public float Speed = 5f;
    public float Sensitivity = 0.2f;
    #endregion

    public PlayerAnimationData AnimData { get; set; } = new();

    public Action AnimTrigger;

    #region Component
    public Animator Anim { get; private set; }
    public Rigidbody rb;
    public Collider col;
    #endregion


    private void OnValidate()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        if (col == null)
        {
            col = GetComponent<Collider>();
        }
        if (Anim == null)
        {
            Anim = GetComponent<Animator>();
        }
    }

    private void Start()
    {
        AnimData.Init(this);
    }

    

    private void Update()
    {
        if (AnimData != null)
        {
            AnimData.StateMachine.CurrentState?.Update();
        }
    }

    private void FixedUpdate()
    {
        if (AnimData != null)
            AnimData.StateMachine.CurrentState?.FixedUpdate();
    }

    public void AnimationTrigger() => AnimTrigger?.Invoke();
}