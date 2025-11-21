using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using static Enums;

public abstract class UI_Base : MonoBehaviour
{
    /// <summary>
    /// 자기 자신에게 붙은 ui 이벤트를 바인딩함.
    /// UI_EventHandler에서 이벤트를 붙이도록 구현
    /// </summary>
    /// <param name="go"></param>
    /// <param name="action"></param>
    /// <param name="type"></param>
    public static void BindEvent(GameObject go, Action<PointerEventData> action, UIEvent type)
    {
        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

        switch (type)
        {
            case UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case UIEvent.Drag:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;
                break;
        }
    }

    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// UI매니저에 본인을 바인딩 시키는 것 구현해야함!!! 무조건
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// UI매니저에 본인을 딕셔너리에서 제거하는 것 구현해야함!! 무조건
    /// 구현 후 가장 마지막에는 base.Releases(); 해줘야함.
    /// </summary>
    public virtual void Releases()
    {
        Managers.Resource.Destroy(gameObject);
    }

    /// <summary>
    /// UI 이름으로 자동바인딩
    /// </summary>
#if UNITY_EDITOR
    #region Editor
    private void OnValidate()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
            return;
        }

        var fields = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var field in fields)
        {
            if (field.GetCustomAttribute<SerializeField>() == null)
            {
                continue;
            }

            if (field.FieldType.IsSubclassOf(typeof(Component)))
            {
                field.SetValue(this, FindComponent(field.FieldType, field.Name));
                continue;
            }

            if (field.FieldType != typeof(GameObject))
            {
                continue;
            }

            var component = FindComponent(typeof(Transform), field.Name);
            if (component == null)
            {
                continue;
            }

            field.SetValue(this, component.gameObject);
        }
    }

    private Component FindComponent(Type type, string name)
    {
        var components = GetComponentsInChildren(type, true);
        foreach (var component in components)
        {
            if (component.name == name)
            {
                return component;
            }
        }

        return null;
    }
    #endregion
#endif
}
