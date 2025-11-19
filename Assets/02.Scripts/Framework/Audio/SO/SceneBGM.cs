using UnityEngine;
using static Enums;

[System.Serializable]
public class BGMInfo
{
    public BGMName _name;
    public AudioClip _audioClip;
}

[CreateAssetMenu(fileName = "SceneBGM", menuName = "Scriptable Objects/SceneBGM")]
public class SceneBGM : ScriptableObject
{
    public BGMInfo[] audioClips;
}