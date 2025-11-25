using UnityEngine;
using static Enums;

public class GameManager
{
    public Level level { get; set; }

    public int GoalCount { get; private set; }

    public int CurrentCount { get; set; }

    public GameObject NextMap { get; set; }


    public void Init(Level level = Level.None)
    {
        this.level = level;
        GoalCount = (int)level * 4;
        CurrentCount = 0;

        //Managers.Scene.ChangeState((int)SceneNumber);
    }

    public void InCorrect()
    {
        CurrentCount = 0;
    }

    public void Correct()
    {
        CurrentCount++;
    }
}
