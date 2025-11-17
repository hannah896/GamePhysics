using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : Singleton<Managers>
{
    public static readonly NewAudioManager Audio = new();
    //public static readonly CameraManager Camera = new();
    public static readonly GameManager Game = new();
    //public static readonly InputManager Input = new();
    public static readonly PoolManager Pool = new();
    public static readonly ResourceManager Resource = new();
    public static readonly SceneManager Scene = new();
    public static readonly UIManager UI = new();
    public static readonly DataManager Data = new();
    public static readonly EffectManager Effect = new();

    protected override void Awake()
    {
        base.Awake();
        Pool.Init();
        Audio.Init();
        Scene.Init();
    }

    private void FixedUpdate()
    {
        Scene.FixedUpdate.Invoke();
    }

    private void Update()
    {
        Scene.Update.Invoke();
    }
}