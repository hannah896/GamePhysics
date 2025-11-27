using UnityEngine;
using static Enums;

public class MusicZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Managers.Audio.Controller.PlayBGM(BGMName.Dance);
        }
    }
}
