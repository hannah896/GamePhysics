using System;
using UnityEngine;

public class Looper : MonoBehaviour
{
    public OXChecker[] Os;
    public OXChecker[] Xs;

    public Action Correct => () => { Managers.Game.Check(true); };
    public Action InCorrect => () => { Managers.Game.Check(false); };


    private void Start()
    {
        foreach(var O in Os)
        {
            O.trigger += () =>
            {
                Util.Log("트리거 작동되나요");
                if (Managers.Game.Current.IsCorrect)
                    Correct?.Invoke();
                else
                    InCorrect?.Invoke();
            };
        }

        foreach (var X in Xs)
        {
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
}