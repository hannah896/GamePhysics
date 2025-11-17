using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class UIManager
{
    public Canvas StaticUICanvas { get; private set; }
    public Canvas DynamicUICanvas { get; private set; }

    public RectTransform RectUIPermanent { get; private set; }
    public RectTransform RectUIPopup { get; private set; }

    public Dictionary<UIPermanent, GameObject> UIPermanentDIct { get; private set; } = new();
    public Dictionary<UIPopup, Stack<GameObject>> UIPopupDIct { get; private set; } = new();

    /// <summary>
    /// 그냥 가장 처음에 게임 실행할때 1번만 실행해주면 되는 초기화 함수
    /// </summary>
    public void Init()
    {
        Managers.Resource.Instantiate(nameof(StaticUICanvas), go =>
        {
            StaticUICanvas = go.GetComponent<Canvas>();
            RectUIPermanent = go.transform as RectTransform;
            MonoBehaviour.DontDestroyOnLoad(go);
        });
        Managers.Resource.Instantiate(nameof(DynamicUICanvas), go =>
        {
            DynamicUICanvas = go.GetComponent<Canvas>();
            RectUIPopup = go.transform as RectTransform;
            MonoBehaviour.DontDestroyOnLoad(go);
        });
    }

    /// <summary>
    /// UI 생성 및 캔버스 배치
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void ShowUI<T>(bool isStatic = false) where T: UIBase
    {
        Managers.Resource.Instantiate(typeof(T).ToString(), go =>
        {
            go.GetComponent<T>().Init();
            SetCanvas(go, isStatic);
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ui"></param>
    public void CloseUI<T>(T ui) where T: UIBase 
    {
        ui.Releases();
    }

    /// <summary>
    /// Static, Dynamic Canvas 내 모든 자식 오브젝트 삭제
    /// 씬 전환 시에 사용.
    /// 둘다 지울거면 지정 안 해주면 됨
    /// 특정 캔버스만 지울거면 해당하는 인자만 true로 지정 / 아닌애는 false
    /// </summary>
    /// <param name="_static"></param>
    /// <param name="_dynamic"></param>
    public void ClearCanvas(bool _static = true, bool _dynamic = true)
    {
        if (_static)
        {
            foreach (RectTransform child in StaticUICanvas.transform)
            {
                Managers.Resource.Destroy(child.gameObject);
            }
        }

        if (_dynamic)
        {
            foreach (RectTransform child in DynamicUICanvas.transform)
            {
                Managers.Resource.Destroy(child.gameObject);
            }
        }
    }

    private void SetCanvas(GameObject go, bool isStatic = false)
    {
        if (isStatic)
        {
            go.transform.SetParent(RectUIPermanent);
        }
        else
        {
            go.transform.SetParent(RectUIPopup);
        }
    }
}
