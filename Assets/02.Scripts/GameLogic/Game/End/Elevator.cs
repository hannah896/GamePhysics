using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Vector3 halfExtents = Vector3.one;
    public float distance = 3f;
    public LayerMask layerMask;

    public Animator animator;

    private void Update()
    {
        if (Physics.BoxCast(transform.position, halfExtents, transform.forward, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Player"))
                Managers.Scene.ChangeState(Managers.Scene.EndingCreditScene);
        }


        if (Physics.BoxCast(transform.position + transform.forward * distance, halfExtents, transform.forward, out RaycastHit h))
        {
            if (h.collider.CompareTag("Player"))
                animator.enabled = true;
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        Quaternion rot = transform.rotation;

        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(origin, rot, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, halfExtents * 2);

        Vector3 end = origin + direction * distance;
        Gizmos.color = Color.blue;
        Gizmos.matrix = Matrix4x4.TRS(end, rot, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, halfExtents * 2);
    }

}
