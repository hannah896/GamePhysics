using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Enums;

public class BlickLight : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] Renderer renderer; 
    [SerializeField] Material mat;

    public static float speed = 7f;
    public static float minIntensity = 0f;
    public static float maxIntensity = 7.3f;

    private void OnValidate()
    {
        light = GetComponentInChildren<Light>();
        renderer = GetComponent<Renderer>();

    }

    private void Start()
    {
        mat = renderer.material;
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * speed, 0f);
        float flick = Mathf.Lerp(minIntensity, maxIntensity, noise);

        light.intensity = flick;
        if (noise > 0.9f)
        {
            int x = Random.Range(1, 4);

            if (x == 1)
                Managers.Audio.Controller.PlaySFX(SFXName.LightNoise1);
            else if (x == 2)
                Managers.Audio.Controller.PlaySFX(SFXName.LightNoise2);
            else
                Managers.Audio.Controller.PlaySFX(SFXName.LightNoise3);
        }
        mat.SetColor("_EmissionColor", Color.white * flick);
    }
}
