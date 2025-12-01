using System.Collections;
using UnityEngine;

public class Professor : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnValidate()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (Managers.Game.Current.scene == Managers.Scene.Trap8Scene)
            animator.SetBool("isTrap8", true);
        else
        {
            animator.SetBool("isTrap8", false);
        }
    }
}
