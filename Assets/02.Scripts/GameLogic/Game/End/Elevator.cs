using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Elevator : MonoBehaviour
{
    public Vector3 halfExtents = Vector3.one;
    public float distance = 3f;
    public LayerMask layerMask = LayerMask.GetMask("Player");

    public Animator animator;

    private void Update()
    {
        if (Physics.BoxCast(transform.position + Vector3.one, halfExtents, transform.forward, out RaycastHit hit, transform.rotation, distance, layerMask))
        {
            Managers.Scene.ChangeState(Managers.Scene.EndingCreditScene);
        }


        if (Physics.BoxCast(transform.position + transform.forward * distance, halfExtents, transform.forward, out RaycastHit h, transform.rotation, distance, layerMask))
        {
            if (h.collider.CompareTag("Player"))
                animator.enabled = true;
        }
    }
}
