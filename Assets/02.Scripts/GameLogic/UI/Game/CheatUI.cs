using TMPro;
using UnityEngine;
using static Enums;
using static GameManager;

public class CheatUI : UI_Button
{
    [SerializeField] private TMP_InputField Input;

    public override void Init()
    {
        base.Init();

        UI_Base.BindEvent(gameObject, evt =>
        {
            OnClickButton(Input);
        }, UIEvent.Click);
    }

    public override void OnClickButton(TMP_InputField value)
    {
        base.OnClickButton(value);
        if (int.TryParse(value.text, out int num))
        {
            switch (num)
            {
                case 0:
                    Managers.Scene.ChangeState(Managers.Scene.StartScene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.StartScene, false);
                    break;

                case 1:
                    Managers.Scene.ChangeState(Managers.Scene.CorrectScene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.CorrectScene, false);
                    break;

                case 2:
                    Managers.Scene.ChangeState(Managers.Scene.Trap1Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap1Scene, false);
                    break;

                case 3:
                    Managers.Scene.ChangeState(Managers.Scene.Trap2Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap2Scene, false);
                    break;

                case 4:
                    Managers.Scene.ChangeState(Managers.Scene.Trap3Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap3Scene, false);
                    break;

                case 5:
                    Managers.Scene.ChangeState(Managers.Scene.Trap4Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap4Scene, false);
                    break;

                case 6:
                    Managers.Scene.ChangeState(Managers.Scene.Trap5Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap5Scene, false);
                    break;

                case 7:
                    Managers.Scene.ChangeState(Managers.Scene.Trap6Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap6Scene, false);
                    break;

                case 8:
                    Managers.Scene.ChangeState(Managers.Scene.Trap7Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap7Scene, false);
                    break;

                case 9:
                    Managers.Scene.ChangeState(Managers.Scene.Trap8Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap8Scene, false);
                    break;

                case 10:
                    Managers.Scene.ChangeState(Managers.Scene.Trap9Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap9Scene, false);
                    break;

                case 11:
                    Managers.Scene.ChangeState(Managers.Scene.Trap10Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap10Scene, false);
                    break;

                case 12:
                    Managers.Scene.ChangeState(Managers.Scene.Trap11Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap11Scene, false);
                    break;

                case 13:
                    Managers.Scene.ChangeState(Managers.Scene.Trap12Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap12Scene, false);
                    break;

                case 14:
                    Managers.Scene.ChangeState(Managers.Scene.Trap13Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap13Scene, false);
                    break;

                case 15:
                    Managers.Scene.ChangeState(Managers.Scene.Trap14Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap14Scene, false);
                    break;

                case 16:
                    Managers.Scene.ChangeState(Managers.Scene.Trap15Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap15Scene, false);
                    break;

                case 17:
                    Managers.Scene.ChangeState(Managers.Scene.Trap16Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap16Scene, false);
                    break;

                case 18:
                    Managers.Scene.ChangeState(Managers.Scene.Trap17Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap17Scene, false);
                    break;

                case 19:
                    Managers.Scene.ChangeState(Managers.Scene.Trap18Scene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.Trap18Scene, false);
                    break;

                case 20:
                    Managers.Scene.ChangeState(Managers.Scene.EndingScene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.EndingScene, false);
                    break;

                case 21:
                    Managers.Scene.ChangeState(Managers.Scene.EndingCreditScene);
                    Managers.Game.Current = new StageInfo(Managers.Scene.EndingCreditScene, false);
                    break;

                default:
                    Debug.Log("Invalid scene number.");
                    break;
            }
        }
    }
}
