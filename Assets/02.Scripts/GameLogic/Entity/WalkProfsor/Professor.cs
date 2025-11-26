using UnityEngine;
using UnityEngine.Splines;

public class Professor : MonoBehaviour
{
    [SerializeField] SplineContainer splineContainer;

    private void Start()
    {
        //transform.position = splineContainer.Spline.Knots[0].Position;
    }
    private void Update()
    {
        float moveSpeed = 2f;
        float step = moveSpeed * Time.deltaTime;
    }
}
