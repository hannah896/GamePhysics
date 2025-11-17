using System;
using UnityEngine;

public class InputKey
{
    private Action start;
    private Action progress;
    private Action end;

    public Action Start { get => start; set => start = value; }
    public Action Progress { get => start; set => start = value; }
    public Action End { get => start; set => start = value; }

    public KeyCode Key { get; private set; }

    public InputKey(KeyCode Key, Action start = null, Action progress = null, Action end = null)
    {
        this.Key = Key;

        this.start += start;
        this.progress += start;
        this.end += start;
    }
}
