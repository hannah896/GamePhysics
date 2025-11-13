using UnityEngine;

public class LocalPositionTest : MonoBehaviour
{
    private void Update()
    {
        transform.localPosition += Vector3.up * 2f * Time.deltaTime;
    }
}
