using System.Threading.Tasks;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraManager
{
    private Volume _volume;
    public Volume Volume
    {
        get
        {
            if (_volume == null)
                Init();
            return _volume;
        }

        private set { }
    }

    /// <summary>
    /// 씬 전환시 실행시켜줘야 함.
    /// </summary>
    public void Init()
    {
        try
        {
            var v = Camera.main.GetComponentInChildren<Volume>(true);
            _volume = v;
            _volume.gameObject.SetActive(false);
        }
        catch
        {
            Managers.Resource.Instantiate("Common/GlobalVolume", go =>
            {
                go.transform.SetParent(Camera.main.transform);
                go.transform.localPosition = Vector3.zero;
                go.transform.localRotation = Quaternion.Euler(Vector3.zero);
                go.transform.localScale = Vector3.one;
                
                _volume = go.GetComponent<Volume>();
                go.SetActive(false);
            });
        }
    }
}