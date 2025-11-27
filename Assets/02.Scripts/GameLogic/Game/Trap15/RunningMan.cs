using UnityEngine;
using UnityEngine.AI;

public class RunningMan : MonoBehaviour
{
    public float FieldOfView = 120f;
    public float Speed = 5f;
    public float Dist = 25.0f;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject target;

    [SerializeField] private Animator anim;

    private int runHash = Animator.StringToHash("Run");
    private int idleHash = Animator.StringToHash("Idle");



    private void OnValidate()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        if (agent != null)
        {
            agent.speed = Speed;
        }
    }

    private void Update()
    {
        if (IsClose())
        {
            agent.isStopped = false;
            agent.SetDestination(target.transform.position);
            anim.Play(runHash);
        }
        else
        {
            agent.isStopped = true;
            anim.Play(idleHash);
        }
    }

    private bool IsClose()
    {
        if (target.GetComponent<PlayerController>().IsDead == true)
            return false;
        float distance = Vector3.Distance(target.transform.position, transform.position);
        return distance < Dist && IsFoV();
    }

    private bool IsFoV()
    {
        Vector3 dirToTarget = target.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, dirToTarget);
        return angle < FieldOfView * 0.5f;
    }
}
