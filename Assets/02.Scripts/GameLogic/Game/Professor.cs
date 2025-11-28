using System.Collections;
using UnityEngine;

public class Professor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public GameObject Head;
    public Transform LookTarget;

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

        StartCoroutine(Trap13());
    }

    IEnumerator Trap13()
    {
        if (Head != null && LookTarget != null)
        {
            Vector3 dir = LookTarget.position - Head.transform.position;
            Head.transform.rotation = Quaternion.LookRotation(dir);
        }
        yield return null;
    }
}
