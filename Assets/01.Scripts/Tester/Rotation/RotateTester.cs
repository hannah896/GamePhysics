using UnityEngine;

public class RotateTester : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up, 45f * Time.deltaTime);
    }
}
