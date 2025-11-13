using UnityEngine;

public class TranslateTest : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector3.up * 2.0f * Time.deltaTime);
    }
}
