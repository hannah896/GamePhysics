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

    //리소스 로드용 경로 딕셔너리
    public Dictionary<string, string> path { get; set; } = new();


    /// <summary>
    /// 그냥 가장 처음에 게임 실행할때 1번만 실행해주면 되는 초기화 함수
    /// </summary>
    public void Init()
    {
        Managers.Resource.Instantiate("StaticUICanvas", go =>
        {
            StaticUICanvas = go.GetComponent<Canvas>();
            RectUIPermanent = go.transform as RectTransform;
        });

        Managers.Resource.Instantiate("DynamicUICanvas", go =>
        {
            DynamicUICanvas = go.GetComponent<Canvas>();
            RectUIPopup = go.transform as RectTransform;
        });
        Managers.Resource.Instantiate("EventSystem");
    }

    /// <summary>
    /// 컴포넌트로 UI 생성 및 캔버스 배치
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void ShowUI<T>(bool isStatic = false) where T: UIBase
    {
        Util.Log(typeof(T).Name);

        if (!path.TryGetValue(path[typeof(T).Name], out string _path))
        {
            Util.LogError("해당 컴포넌트 경로 미등록");
            return;
        }

        Util.Log(_path);
        Managers.Resource.Instantiate(_path, go =>
        {
            SetCanvas(go, isStatic);
        });
    }

    /// <summary>
    /// UI 생성 및 캔버스 배치
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void ShowUI(string _name,bool isStatic = true)
    {
        Util.Log(_name);
        Util.Log("맞장뜨자");
        if (!path.TryGetValue(_name, out string _path))
        {
            Util.LogError("해당 컴포넌트 경로 미등록");
            return;
        }

        Util.Log(_path);
        Managers.Resource.Instantiate(_path, go =>
        {
            SetCanvas(go, isStatic);
        });
    }

    /// <summary>
    /// 정적 UI 등록 해제
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ui"></param>
    public void CloseStaticUI<T>(T ui) where T: UIPermanent
    {
        ui.gameObject.SetActive(false);
        UIPermanentDIct.Remove(ui);
    }

    /// <summary>
    /// 동적 UI 등록 해제 삭제
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ui"></param>
    public void ClosePopupUI<T>(T ui) where T : UIPopup
    {
        if (UIPopupDIct[ui].Count == 0)
            UIPopupDIct.Remove(ui);
        UIPopupDIct[ui].Pop();
    }

    private void SetCanvas(GameObject go, bool isStatic = false)
    {
        if (isStatic)
        {
            go.transform.SetParent(RectUIPermanent);
            go.transform.localPosition = Vector3.zero;
        }
        else
        {
            go.transform.SetParent(RectUIPopup);
            go.transform.localPosition = Vector3.zero;
        }
    }
}
