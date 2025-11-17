using UnityEngine;

public abstract class SceneBase : StateBase
{

    /// <summary>
    /// 씬 로드 시에 실행되어야 하는 메서드
    /// </summary>
    public override void OnEnter()
    {
        // TODO: 오디오 및 기타 씬 진입할때 필요한 리소스 로드, 초기화 작업 수행
    }

    /// <summary>
    /// 씬 종료 시에 실행되어야 하는 메서드
    /// </summary>
    public override void OnExit()
    {
        Managers.Audio.ChangeScene.Invoke();
    }
}