using UnityEngine;
using static Enums;

[CreateAssetMenu(fileName = "BGMData", menuName = "Scriptable Objects/BGMData")]
public class BGMData : ScriptableObject, ISound
{
    [SerializeField] private BGMName bgmName;
    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;

    AudioSource ISound.AudioSource { get; set; }
    AudioClip ISound.AudioClip => audioClip;

    public void SetVolume(float value)
    {
        audioSource.volume = value;
    }
}