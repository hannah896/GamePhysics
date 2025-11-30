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
            int x = Random.Range((int)SFXName.LightNoise1, (int)SFXName.LightNoise3 + 1);

            Managers.Audio.Controller.PlaySFX((SFXName)x);
        }
        mat.SetColor("_EmissionColor", Color.white * flick);
    }
}
