using UnityEngine;

public static class Enums
{
    public enum Stage
    {
        Correct,
        Trap1,
        Count,
    }
    public enum SceneNumber
    {
        Start,
        Correct,
        Count,
    }
    public enum Level
    {
        None,
        Easy,
        Normal,
        Hard,
    }

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
        Click,
        Walk,
        LightNoise1,
        LightNoise2,
        LightNoise3,
        Count,
    }

    public enum BGMName
    {
        Start,
        Game,
        Horror,
        Dance,
        Count,
    }

    public enum DoorPivot
    {
        Left = -210,
        Right = 210,
    }

    public enum DoorSide
    {
        Left,
        Right,
    }
}
