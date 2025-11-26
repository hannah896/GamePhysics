using System;
using UnityEngine;


public class OXChecker : MonoBehaviour
{
    public Collider Check;

    public Action trigger;

    private void OnCollisionEnter(Collision collision)
    {
        trigger?.Invoke();
    }
}
