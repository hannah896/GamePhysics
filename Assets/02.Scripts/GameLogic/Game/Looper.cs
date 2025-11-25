using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Looper : MonoBehaviour
{
    public OXChecker O;
    public OXChecker X;

    public Action Correct => () => { Managers.Game.Check(true); };
    public Action InCorrect => () => { Managers.Game.Check(false); };


    private void Start()
    {
        O.trigger += () =>
        {
            Util.Log("트리거 작동되나요");
            if (Managers.Game.Current.IsCorrect)
                Correct?.Invoke();
            else
                InCorrect?.Invoke();
        };

        X.trigger += () =>
        {
            Util.Log("트리거 작동되나요??");
            if (!Managers.Game.Current.IsCorrect)
                Correct?.Invoke();
            else
                InCorrect?.Invoke();
        };

    }
}