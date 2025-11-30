using UnityEngine;

public class Resetter : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            col.transform.position = col.GetComponent<PlayerController>().PrePos;
        }
    }
}
