using UnityEngine;
using static Enums;

[System.Serializable]
public class BGMInfo
{
    public BGMName _name;
    public AudioClip _audioClip;
}

[CreateAssetMenu(fileName = "BGMData", menuName = "Scriptable Objects/BGMData")]
public class BGMData : ScriptableObject
{
    public BGMInfo[] audioClips;
}