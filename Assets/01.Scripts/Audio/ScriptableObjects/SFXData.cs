using UnityEngine;
using static Enums;

[CreateAssetMenu(fileName = "SFXData", menuName = "Scriptable Objects/SFXData")]
public class SFXData : ScriptableObject, ISound
{
    [SerializeField] private SFXName sfxName;
    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;

    AudioSource ISound.AudioSource { get; set; }
    AudioClip ISound.AudioClip => audioClip;

    public void SetVolume(float value)
    {
        audioSource.volume = value;
    }
}
