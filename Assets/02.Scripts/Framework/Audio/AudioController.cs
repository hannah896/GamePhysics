using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class AudioController
{
    private Dictionary<BGMName, BGMData> bgmData = new();
    private Dictionary<SFXName, SFXData> sfxData = new();
}