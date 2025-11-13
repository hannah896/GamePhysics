using UnityEngine;

public class WorldRotationPlus : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up, 45f * Time.deltaTime, Space.World);
        Rigidbody rb = GetComponent<Rigidbody>();
    }
}
