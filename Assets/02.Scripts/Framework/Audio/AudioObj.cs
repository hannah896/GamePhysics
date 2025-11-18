using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioObj : Poolable
{
    private AudioSource audioSource;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }
#endif

    /// <summary>
    /// 오디오 초기화 메서드
    /// </summary>
    /// <typeparam name="T">SFXData OR BGMData</typeparam>
    /// <param name="clip">SFXData OR BGMData</param>
    /// <param name="isBGM">오디오를 루프시킬지 여부</param>
    public void Init<T>(T clip, bool isBGM = false) where T : ISound
    {
        gameObject.SetActive(false);
        clip.AudioSource = audioSource;
        audioSource.clip = clip.AudioClip;

        if (isBGM)
            audioSource.loop = true;
        
        gameObject.SetActive(true);
        // TODO : 오디오 끝나면 풀로 반환하는 기능 추가해야 됨!!!
    }
}