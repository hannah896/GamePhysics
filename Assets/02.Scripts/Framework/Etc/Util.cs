using DG.Tweening;
using UnityEngine;

/// <summary>
/// 유틸리티 클래스 
/// </summary>
public class Util
{
    /// <summary>
    /// 컴포넌트 갖고오기 
    /// 없을 시 추가 후 컴포넌트를 가져옴
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <returns></returns>
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }

    /// <summary>
    /// 자식 오브젝트를 이름으로 찾기
    /// </summary>
    /// <param name="go">부모오브젝트</param>
    /// <param name="name">오브젝트명</param>
    /// <param name="recursive">자식의 자식까지 탐색할 것 인지 여부</param>
    /// <returns></returns>
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
            return null;

        return transform.gameObject;
    }

    /// <summary>
    /// 자식 오브젝트를 이름과 타입으로 찾기
    /// </summary>
    /// <typeparam name="T">컴포넌트 명</typeparam>
    /// <param name="go">부모오브젝트</param>
    /// <param name="name">오브젝트명</param>
    /// <param name="recursive">자식의 자식까지 탐색할 것 인지 여부</param>
    /// <returns></returns>
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>(true))
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }

    /// <summary>
    /// 자식 오브젝트 뒤져서 컴포넌트 찾기
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static T FindComponent<T>(GameObject gameObject, string name) where T : Component
    {
        var components = gameObject.GetComponentsInChildren<T>(true);
        foreach (var component in components)
        {
            if (component.name.Equals(name))
            {
                return component;
            }
        }
        Debug.LogWarning($"Failed to FindComponent<{typeof(T).Name}>({gameObject.name}, {name})");
        return null;
    }



    /// <summary>
    /// 두투윈 시퀀스 재활용
    /// </summary>
    /// <returns></returns>
    public static DG.Tweening.Sequence RecyclableSequence()
    {
        return DOTween.Sequence().Pause().SetAutoKill(false);
    }

    /// <summary>
    /// X값만 변경 시 사용
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="x"></param>
    public static void SetPositionX(Transform transform, float x)
    {
        Vector3 position = transform.position;
        position.x = x;
        transform.position = position;
    }

    /// <summary>
    /// Y값만 변경 시 사용
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="y"></param>
    public static void SetPositionY(Transform transform, float y)
    {
        Vector3 position = transform.position;
        position.y = y;
        transform.position = position;
    }

    /// <summary>
    /// Z값만 변경 시 사용
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="z"></param>
    public static void SetPositionZ(Transform transform, float z)
    {
        Vector3 position = transform.position;
        position.z = z;
        transform.position = position;
    }



    /// <summary>
    /// 스크린 좌표를 월드 좌표로 변환 (Z값 0으로 고정)
    /// </summary>
    /// <param name="screenPoint"></param>
    /// <returns></returns>
    public static Vector3 ScreenToWorldPointWithoutZ(Vector2 screenPoint)
    {
        Vector3 res = Camera.main.ScreenToWorldPoint(screenPoint);
        res.z = 0;
        return res;
    }

    /// <summary>
    /// string 형태의 벡터3을 Vector3Int로 변환
    /// </summary>
    /// <param name="str"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryStringToVector3Int(string str, out Vector3Int result)
    {
        result = Vector3Int.zero;

        if (string.IsNullOrWhiteSpace(str))
            return false;

        string[] trimmed = str.Trim('(', ')').Split(',');

        if (trimmed.Length != 3)
            return false;

        bool successX = int.TryParse(trimmed[0].Trim(), out int x);
        bool successY = int.TryParse(trimmed[1].Trim(), out int y);
        bool successZ = int.TryParse(trimmed[2].Trim(), out int z);

        if (successX && successY && successZ)
        {
            result = new Vector3Int(x, y, z);
            return true;
        }

        return false;
    }

    // 디버그를 위한 유틸리티
    public static void Log(string message)
    {
#if UNITY_EDITOR
        Debug.Log(message);
#endif
    }

    public static void LogWarning(string message)
    {
#if UNITY_EDITOR
        Debug.LogWarning(message);
#endif
    }

    public static void LogError(string message)
    {
#if UNITY_EDITOR
        Debug.LogError(message);
#endif
    }
}