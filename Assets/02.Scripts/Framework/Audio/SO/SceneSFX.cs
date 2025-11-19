using System.Collections.Generic;
using UnityEngine;
using static Enums;

[System.Serializable]
public class SFXInfo
{
    public SFXName _name;
    public AudioClip _audioClip;
}

[CreateAssetMenu(fileName = "SceneSFX", menuName = "Scriptable Objects/SceneSFX")]
public class SceneSFX : ScriptableObject
{
    public List<SFXInfo> audioClips;
}