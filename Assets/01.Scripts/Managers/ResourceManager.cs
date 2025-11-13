using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using Object = UnityEngine.Object;


// TODO : resources 폴더로 만드는 것도 한번 시도해보기, 의존성 낮추는 연습하기, 유니테스크 사용연습
// 어드레서블을 사용한 리소스 매니저로 어드레서블에 등록할 시 반드시 이름을 프리펩 이름과 똑같이 맞춰줄 것
public class ResourceManager
{
    /// <summary>
    /// key값으로 작업물 로드 및 콜백 실행(실제 생성은 X)
    /// </summary>
    /// <param name="key"></param>
    /// <param name="onComplete"></param>
    public void Instantiate(string key, Action<GameObject> onComplete = null)
    {
        Resources.LoadAsync<GameObject>(key).Completed += (handle) =>
        {
            onComplete?.Invoke(Instantiate(handle.Result));
        };
    }

    /// <summary>
    /// 프레임워크 일부분으로 절대 이걸로 오브젝트 생성하면 안됨!!! 
    /// 오브젝트를 실제로 생성하는 생성부 메서드. 
    /// 게임 컨텐츠 제작시에는 void Instantiate(string key, Action<GameObject> onComplete = null) 사용할것
    /// </summary>
    /// <param name="original"></param>
    /// <returns></returns>
    public GameObject Instantiate(GameObject original)
    {
        if (original == null) return null;
        GameObject obj = Object.Instantiate(original);
        obj.name = original.name;
        return obj;
    }

    /// <summary>
    /// 오브젝트 파괴 메서드 (풀링된 오브젝트는 풀로 반환, 일반 오브젝트는 파괴)
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="tryForcePool"></param>
    public void Destroy(GameObject obj, bool tryForcePool = false)
    {
        if (obj.TryGetComponent<Poolable>(out var poolable))
        {
            Managers.Pool.Release(poolable);
            return;
        }

        Object.Destroy(obj);
    }

    /// <summary>
    /// 라벨명이 붙은 그룹 단위로 작업물 로드 (씬에 필요한 모든 리소스들 미리로드용)
    /// </summary>
    /// <param name="assetLabel"></param>
    /// <param name="onComplete"></param>
    public void LoadResourceLocationAsync(string assetLabel, Action onComplete = null)
    {
        if (operations.TryGetValue(assetLabel, out var operation))
        {
            onComplete?.Invoke();
            return;
        }

        Addressables.LoadResourceLocationsAsync(assetLabel).Completed += (handle) =>
        {
            CreateGenericGroupOperation(handle, onComplete);
        };
    }
}