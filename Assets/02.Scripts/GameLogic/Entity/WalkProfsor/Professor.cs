using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Splines;

public class Professor : MonoBehaviour
{
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private Rigidbody rb;

    private List<Vector3> pos = new();
    float speed = 1.0f;

    private Vector3 TargetPosition;


    private void OnValidate()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        foreach (var point in splineContainer.Spline)
            pos.Add(point.Position);

        TargetPosition = transform.TransformPoint(pos[0]);
        StartCoroutine(ChangeTarget());
    }

    private void FixedUpdate()
    {
        Vector3 move = Vector3.MoveTowards(transform.position, TargetPosition, Time.fixedDeltaTime * speed);
        rb.MovePosition(move);
    }

    IEnumerator ChangeTarget()
    {
        int idx = 1;

        while (true)
        {
            if (idx == splineContainer.Spline.Count)
                yield break;
            if (Vector3.Distance(transform.position, TargetPosition) < 0.05f)
            {
                idx++;
                TargetPosition = transform.TransformPoint(pos[idx]);
            }
            yield return null;
        }
    }
}
