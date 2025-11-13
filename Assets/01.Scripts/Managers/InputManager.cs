using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyState = Enums.KeyState;

// TODO: 업데이트쪽으로 로직 수정 코루틴 X 코루틴은 연출쪽에서 사용하는 것이 좋을듯
/// <summary>
/// 구 인풋 시스템 사용한 인풋 매니저
/// </summary>
public class InputManager
{
    private Dictionary<KeyCode, InputKey> keySetting = new();

    public Dictionary<KeyCode, InputKey> KeySetting { get => keySetting; }

    /// <summary>
    /// 매니저 허브에서 돌릴 생명주기
    /// </summary>
    public void Update()
    {
        KeyChecker();
    }

    /// <summary>
    /// 키 설정 메서드
    /// 등록안할거면 null 넣어주면 됨.
    /// </summary>
    /// <param name="key">키 입력키 코드</param>
    /// <param name="start">키 누르는 순간 등록할 액션</param>
    /// <param name="progress">누르는 동안 등록할 액션</param>
    /// <param name="end">키 뗐을 때 등록할 메서드</param>
    public void SetKey(KeyCode key, Action start = null, Action progress = null, Action end = null)
    {
        if (keySetting.ContainsKey(key))
        {
            if (start != null)
            {
                keySetting[key].Start = start;
            }
            if (progress != null)
            {
                keySetting[key].Progress = progress;
            }
            if (end != null)
            {
                keySetting[key].End = end;
            }
        }
        else
        {
            keySetting.Add(key, new InputKey(key, start, progress, end));
        }
    }

    /// <summary>
    /// 이미 존재하는 키에서 설정을 추가해주려 할 때
    /// </summary>
    /// <param name="key"></param>
    /// <param name=""></param>
    public void AddKeyOption(KeyCode key, KeyState state, Action addOption)
    {
        if (!keySetting.ContainsKey(key))
        {
            Util.LogError($"There is not exist {key} KeySetting.");
            return;
        }

        switch (state)
        {
            case KeyState.Start:
                keySetting[key].Start += addOption;
                break;
            case KeyState.Progress:
                keySetting[key].Progress += addOption;
                break;
            case KeyState.End:
                keySetting[key].End += addOption;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 키 설정 삭제 메서드
    /// </summary>
    /// <param name="key"></param>
    public void RemoveKey(KeyCode key)
    {
        if (!keySetting.ContainsKey(key))
        {
            Util.LogError($"There is not exist {key} KeySetting.");
            return;
        }

        keySetting.Remove(key);
    }
    
    /// <summary>
    /// 키 입력 체크 메서드
    /// </summary>
    /// <returns></returns>
    private void KeyChecker()
    {
        foreach (KeyCode key in keySetting.Keys)
        {
            Check(key);
        }
    }

    /// <summary>
    /// 키 입력 체크 메서드
    /// </summary>
    /// <param name="key"></param>
    private void Check(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            keySetting[key].Start?.Invoke();
        }
        if (Input.GetKey(key))
        {
            keySetting[key].Progress?.Invoke();
        }
        if (Input.GetKeyUp(key))
        {
            keySetting[key].End?.Invoke();
        }
    }
}