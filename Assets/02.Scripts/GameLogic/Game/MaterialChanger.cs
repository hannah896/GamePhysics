using UnityEngine;
using static Enums;

public class MaterialChanger : MonoBehaviour
{
    public Renderer Renderer;
    public ChangeType ChangeType;

    public Material[] Materials;

    private void OnValidate()
    {
        if (Renderer == null)
            Renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        if (ChangeType == ChangeType.Guide)
        {
            if (Managers.Game.Level == Level.None)
                return;
            Renderer.material = Materials[(int)Managers.Game.Level - 1];
        }
        else if (ChangeType == ChangeType.Floor)
        {
            if (Managers.Game.GoalCount ==  0)
                return;
            Renderer.material = Materials[(int)Managers.Game.GoalCount- (int)Managers.Game.CurrentCount -1 ];
        }
    }
}
