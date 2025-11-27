using DG.Tweening;
using UnityEngine;
using static Enums;

public class Door : MonoBehaviour
{
    [SerializeField] private DoorPivot pivot;
    [SerializeField] private DoorSide side;
    [SerializeField] private Rigidbody rb;

    private void OnValidate()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>(); 
    }
    private void Awake()
    {
        rb.isKinematic = true;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Util.Log("내가 문열어줄게!!!!!!!");
            if (side == DoorSide.Left)
            {
                // 플레이어가 복도에 있을때
                if (collision.transform.position.x > transform.position.x)
                {
                    transform.DOLocalRotate((int)pivot * Vector3.up, 5f).SetEase(Ease.OutElastic);
                    Util.Log("복도에 있네????");
                }
                // 플레이어가 방에 있을때 
                else
                {
                    transform.DOLocalRotate((int)pivot * Vector3.down, 3.5f).SetEase(Ease.OutElastic);
                    Util.Log("방에 있네????");
                }
            }
            else
            {
                int angle = (int)pivot;

                if (collision.transform.position.x < transform.position.x)
                {
                    // 복도쪽 → pivot 각도 그대로
                    transform.DOLocalRotate((int)pivot/2 * Vector3.up, 5f).SetEase(Ease.OutElastic);
                }
                else
                {
                    // 방 쪽 → pivot 각도 반대 방향
                    transform.DOLocalRotate((int)pivot/2* Vector3.down, 5f).SetEase(Ease.OutElastic);
                }
            }
        }
    }
}
