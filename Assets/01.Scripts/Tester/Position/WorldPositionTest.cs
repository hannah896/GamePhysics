using UnityEngine;

public class WorldPositionTest : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.up * 2f * Time.deltaTime;
    }
}
