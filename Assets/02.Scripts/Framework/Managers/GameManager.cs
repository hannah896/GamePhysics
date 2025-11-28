using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class GameManager
{
    #region GameInfo
    public Level Level { get; set; }

    public int GoalCount { get; private set; }

    public int CurrentCount { get; set; }

    #endregion

    #region Stage Info
    public struct StageInfo
    {
        public SceneBase scene;
        public bool IsCorrect;

        public StageInfo(SceneBase map, bool iscorrect)
        {
            this.scene = map;
            this.IsCorrect = iscorrect; 
        }
    }

    public StageInfo Current { get; set; }
    public StageInfo Next { get; set; }

    #endregion

    private List<StageInfo> traps = new();


    /// <summary>
    /// 시작화면에서 실행시켜주는 메서드 최초 1회만 실행됨.
    /// </summary>
    /// <param name="level"></param>
    public void Init(Level level = Level.None)
    {
        this.Level = level;
        GoalCount = (int)level * 5;
        CurrentCount = 0;

        traps.Clear();

        ResetTraps();

        Next = new StageInfo(new CorrectScene(), true);
        Current = Next;
        Managers.Scene.ChangeState(Current.scene);

        CalculateNextMap();
    }

    public void Check(bool isCorrect)
    {
        if (isCorrect)
            CurrentCount++;
        else
        {
            CurrentCount = 0;
            Next = new StageInfo(new CorrectScene(), true);
        }

        Managers.Scene.ChangeState(Next.scene);
        Current = Next;
        CalculateNextMap();
    }

    public void CalculateNextMap()
    {
        bool _isCorrect;
        
        //70%확률로 트랩맵 당첨
        if (Random.Range(0, 100) > 30)
        {
            if (traps.Count == 0)
                ResetTraps();

            Next = traps[Random.Range(0, traps.Count)];
            traps.Remove(Next);
        }
        else
        {
            _isCorrect = true;
            Next = new StageInfo(Managers.Scene.CorrectScene, _isCorrect);
        }
    }

    private void ResetTraps()
    {
        traps.Add(new StageInfo(new Trap1Scene(), false));
        traps.Add(new StageInfo(new Trap2Scene(), false));
        traps.Add(new StageInfo(new Trap3Scene(), false));
        traps.Add(new StageInfo(new Trap4Scene(), false));
        traps.Add(new StageInfo(new Trap5Scene(), false));
        traps.Add(new StageInfo(new Trap6Scene(), false));
        traps.Add(new StageInfo(new Trap7Scene(), false));
        traps.Add(new StageInfo(new Trap8Scene(), false));
        traps.Add(new StageInfo(new Trap9Scene(), false));
        traps.Add(new StageInfo(new Trap10Scene(), false));
        traps.Add(new StageInfo(new Trap11Scene(), false));
        traps.Add(new StageInfo(new Trap12Scene(), false));
        traps.Add(new StageInfo(new Trap13Scene(), false));
        traps.Add(new StageInfo(new Trap14Scene(), false));
        traps.Add(new StageInfo(new Trap15Scene(), false));
        traps.Add(new StageInfo(new Trap16Scene(), false));
        traps.Add(new StageInfo(new Trap17Scene(), false));
        traps.Add(new StageInfo(new Trap18Scene(), false));
    }
}
