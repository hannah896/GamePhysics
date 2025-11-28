using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static Enums;

public class UIManager
{
    public Canvas StaticUICanvas { get; private set; }
    public Canvas DynamicUICanvas { get; private set; }

    public RectTransform RectUIPermanent { get; private set; }
    public RectTransform RectUIPopup { get; private set; }

    public Dictionary<System.Type, List<GameObject>> UIPermanentDIct { get; private set; } = new();
    public Dictionary<System.Type, Stack<GameObject>> UIPopupDIct { get; private set; } = new();

    //리소스 로드용 경로 딕셔너리
    public Dictionary<System.Type, string> path { get; set; } = new();


    /// <summary>
    /// 그냥 가장 처음에 게임 실행할때 1번만 실행해주면 되는 초기화 함수
    /// </summary>
    public void Init()
    {
        Managers.Resource.Instantiate("Common/StaticUICanvas", go =>
        {
            StaticUICanvas = go.GetComponent<Canvas>();
            RectUIPermanent = go.transform as RectTransform;
        });

        Managers.Resource.Instantiate("Common/DynamicUICanvas", go =>
        {
            DynamicUICanvas = go.GetComponent<Canvas>();
            RectUIPopup = go.transform as RectTransform;
        });
        Managers.Resource.Instantiate("Common/EventSystem");
    }

    /// <summary>
    /// 컴포넌트로 UI 생성 및 캔버스 배치
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void ShowUI<T>(bool isStatic = false, Action<T> onComplete = null) where T: UI_Base
    {
        Util.Log(typeof(T).Name);

        
        if (!path.TryGetValue(typeof(T), out string _path))
        {
            Util.LogError("해당 컴포넌트 경로 미등록");
            return;
        }

        Util.Log(_path);
        Managers.Resource.Instantiate(_path, go =>
        {
            SetCanvas(go, isStatic);
            onComplete?.Invoke(go.GetComponent<T>());
        });
    }

    /// <summary>
    /// 정적 UI 등록 해제
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ui"></param>
    public void CloseStaticUI(System.Type ui, GameObject go)
    {
        if (UIPermanentDIct.TryGetValue(ui, out var list))
        {
            if (list.Count != 0)
            {
                list.Remove(go);
                Managers.Resource.Destroy(go);
            }
            else
                UIPermanentDIct.Remove(ui);
        }
    }

    /// <summary>
    /// 동적 UI 등록 해제 삭제
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ui"></param>
    public void ClosePopupUI(System.Type ui)
    {
        if (UIPopupDIct.TryGetValue(ui, out var stack))
        {
            if (stack.Count != 0)
            {
                Managers.Resource.Destroy(stack.Pop());
            }
            else
                UIPopupDIct.Remove(ui);
        }
    }

    private void SetCanvas(GameObject go, bool isStatic = false)
    {
        if (isStatic)
        {
            go.transform.SetParent(RectUIPermanent, false);
            go.transform.localPosition = Vector3.zero;
        }
        else
        {
            go.transform.SetParent(RectUIPopup, false);
            go.transform.localPosition = Vector3.zero;
        }
    }
}
