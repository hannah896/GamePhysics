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

    public void Init(AudioClip clip)
    {
        audioSource.clip = clip;
    }

    public void SFXPlay()
    {
        Util.Log("내가 재생을 시켜볼게~");
        audioSource.PlayOneShot(audioSource.clip);
    }
}