using DG.Tweening;
using UnityEngine;

public class PosterScaler : MonoBehaviour
{
    public Transform[] Posters;

    private void Start()
    {
        foreach (var poster in Posters)
        {
            poster.transform.DOScaleX(3.0f, 300.0f).SetEase(Ease.InOutSine);
            poster.transform.DOScaleY(3.0f, 300.0f).SetEase(Ease.InOutSine);
        }
    }
}
