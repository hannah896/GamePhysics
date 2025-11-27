using UnityEngine;
using static Enums;

public class MusicZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().IsDance = true;
            //Managers.Audio.Controller.PlayBGM(BGMName.Dance);
        }
    }
}
