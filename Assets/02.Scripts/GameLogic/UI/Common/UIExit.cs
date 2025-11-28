using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIExit : UI_Button
{
    [SerializeField] private Button Exit;

    public override void Init()
    {
        base.Init();
        button = Exit;
    }

    public override void OnClickButton()
    {
        base.OnClickButton();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
