using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : Singleton<Managers>
{
    public static readonly AudioManager Audio = new();
    //public static readonly CameraManager Camera = new();
    public static readonly GameManager Game = new();
    public static readonly PoolManager Pool = new();
    public static readonly ResourceManager Resource = new();
    public static readonly SceneManager Scene = new();
    public static readonly UIManager UI = new();
    public static readonly EffectManager Effect = new();

    protected override void Awake()
    {
        base.Awake();
        Pool.Init();
        Scene.Init();

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        Scene.FixedUpdate?.Invoke();
    }

    private void Update()
    {
        Scene.Update?.Invoke();
    }
}