using UnityEngine;

public class LocalRotatePlus : MonoBehaviour
{
    private void Update()
    {
        transform.localRotation *= Quaternion.Euler(0, 45 * Time.deltaTime, 0);
    }
}
