using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioObj : Poolable
{
    public AudioSource audioSource;

#if UNITY_EDITOR
    private void OnValidate()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }
#endif

    private void Start()
    {
        Managers.Audio.SettingData();
    }

    public void Init(AudioClip clip)
    {
        audioSource.clip = clip;
    }

    public void SFXPlay()
    {
        Util.Log("내가 재생을 시켜볼게~");
        var clip = audioSource.clip;
        audioSource.Play();
        Invoke("Remove", clip.length + 1.0f);
    }

    private void Remove()
    {
        Managers.Resource.Destroy(gameObject);
    }
}