using UnityEngine;
using static Enums;

public class GameManager
{
    #region GameInfo
    public Level level { get; set; }

    public int GoalCount { get; private set; }

    public int CurrentCount { get; set; }
    #endregion

    #region Stage Info
    public class StageInfo
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

    public void Init(Level level = Level.None)
    {
        this.level = level;
        GoalCount = (int)level * 2;
        CurrentCount = 0;

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
            _isCorrect = false;
            int num = Random.Range(1, (int)Stage.Count);
            //Managers.Scene.ChangeState();
        }
        else
        {
            _isCorrect = true;
            Next = new StageInfo(new CorrectScene(), _isCorrect);
        }
    }
}
