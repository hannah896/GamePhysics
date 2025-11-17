using static Enums;
using UnityEngine;

public interface ISound
{
    public AudioSource AudioSource { get; set; }
    public AudioClip AudioClip { get; }

    public void SetVolume(float value);
}
