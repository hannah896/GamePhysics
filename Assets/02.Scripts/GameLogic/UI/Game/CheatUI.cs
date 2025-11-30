using TMPro;
using UnityEngine;
using static Enums;

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
                    break;
                case 1:
                    Managers.Scene.ChangeState(Managers.Scene.CorrectScene);
                    break;
                case 2:
                    Managers.Scene.ChangeState(Managers.Scene.Trap1Scene);
                    break;
                case 3:
                    Managers.Scene.ChangeState(Managers.Scene.Trap2Scene);
                    break;
                case 4:
                    Managers.Scene.ChangeState(Managers.Scene.Trap3Scene);
                    break;
                case 5:
                    Managers.Scene.ChangeState(Managers.Scene.Trap4Scene);
                    break;
                case 6:
                    Managers.Scene.ChangeState(Managers.Scene.Trap5Scene);
                    break;
                case 7:
                    Managers.Scene.ChangeState(Managers.Scene.Trap6Scene);
                    break;
                case 8:
                    Managers.Scene.ChangeState(Managers.Scene.Trap7Scene);
                    break;
                case 9:
                    Managers.Scene.ChangeState(Managers.Scene.Trap8Scene);
                    break;
                case 10:
                    Managers.Scene.ChangeState(Managers.Scene.Trap9Scene);
                    break;
                case 11:
                    Managers.Scene.ChangeState(Managers.Scene.Trap10Scene);
                    break;
                case 12:
                    Managers.Scene.ChangeState(Managers.Scene.Trap11Scene);
                    break;
                case 13:
                    Managers.Scene.ChangeState(Managers.Scene.Trap12Scene);
                    break;
                case 14:
                    Managers.Scene.ChangeState(Managers.Scene.Trap13Scene);
                    break;
                case 15:
                    Managers.Scene.ChangeState(Managers.Scene.Trap14Scene);
                    break;
                case 16:
                    Managers.Scene.ChangeState(Managers.Scene.Trap15Scene);
                    break;
                case 17:
                    Managers.Scene.ChangeState(Managers.Scene.Trap16Scene);
                    break;
                case 18:
                    Managers.Scene.ChangeState(Managers.Scene.Trap17Scene);
                    break;
                case 19:
                    Managers.Scene.ChangeState(Managers.Scene.Trap18Scene);
                    break;
                case 20:
                    Managers.Scene.ChangeState(Managers.Scene.EndingScene);
                    break;
                case 21:
                    Managers.Scene.ChangeState(Managers.Scene.EndingCreditScene);
                    break;
                default:
                    Debug.Log("Invalid scene number.");
                    break;
            }
        }
        else
        {
            Debug.Log("Please enter a valid number.");
        }
    }
}
