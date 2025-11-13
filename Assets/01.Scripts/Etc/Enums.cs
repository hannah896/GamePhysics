using UnityEngine;

public static class Enums
{
    public enum UIType
    {
        Permanent,
        Popup,
    }
    public enum UIEvent
    {
        Click,
        Drag,
        Count,
    }

    public enum CanvasType
    {
        Static, 
        Dynamic,
        Count,
    }

    public enum SoundType
    {
        Master,
        BGM,
        SFX,
        Count,
    }

    public enum KeyState
    {
        Start,
        Progress,
        End,
        Count,
    }

    public enum SFXName
    {
        Count,
    }

    public enum BGMName
    {
        Count,
    }
}
