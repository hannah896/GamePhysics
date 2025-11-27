using System.Collections.Generic;
using UnityEngine;
using static Enums;

[System.Serializable]
public class SFXInfo
{
    public SFXName _name;
    public AudioClip _audioClip;
}

[CreateAssetMenu(fileName = "SFXData", menuName = "Scriptable Objects/SFXData")]
public class SFXData : ScriptableObject
{
    public List<SFXInfo> audioClips;
}