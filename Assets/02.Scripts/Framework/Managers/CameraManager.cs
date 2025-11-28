using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraManager
{
    public Volume GlobalVolume { get; private set; }
    /// <summary>
    /// 씬 전환시 실행시켜줘야 함.
    /// </summary>
    public void Init()
    {
        var cam = Camera.main;
        var v = cam.GetComponentInChildren<Volume>(true);
        if (v == null)
        {
            Managers.Resource.Instantiate("Common/GlobalVolume", go =>
            {
                go.transform.SetParent(cam.transform);
                go.transform.localPosition = Vector3.zero;
                GlobalVolume = go.GetComponent<Volume>();
                go.SetActive(false);
            });

        }
        else
        {
            GlobalVolume = v;
            GlobalVolume.gameObject.SetActive(false);
        }
    }
}