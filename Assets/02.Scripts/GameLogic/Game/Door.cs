using DG.Tweening;
using UnityEngine;
using static Enums;

public class Door : MonoBehaviour
{
    [SerializeField] private DoorPivot pivot;
    [SerializeField] private Rigidbody rb;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Util.Log("내가 문열어줄게!!!!!!!");
            // 플레이어가 복도에 있을때
            if (collision.transform.position.x > transform.position.x)
            {
                rb.DORotate((int)pivot * Vector3.up, 5f).SetEase(Ease.OutElastic);
                Util.Log("복도에 있네????");
            }
            // 플레이어가 방에 있을때 
            else
            {
                rb.DORotate((int)pivot * Vector3.up, 3.5f).SetEase(Ease.OutElastic);
                Util.Log("방에 있네????");
            }   
        }
    }
}
