using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip audioClip;             // 효과 사운드 파일.
    public AudioClip audioBGMClip;          // 배경 사운드 파일.
    private AudioSource audioSource;        // 효과 사운드 재생
    private AudioSource audioSourceBGM;     // 배경 사운드 재생

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSourceBGM = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayBGMSound()
    {
        audioSourceBGM.clip = audioBGMClip;
        audioSourceBGM.loop = true;
        audioSourceBGM.Play();
    }

    public void OnOffBGM(bool isOn)
    {
        if (isOn)
        {
            audioSourceBGM.volume = 1f;
        }
        else
        {
            audioSourceBGM.volume = 0f;
        }
    }

    public void OnOffSFX(bool isOn)
    {
        if (isOn)
        {
            audioSource.volume = 1f;
        }
        else
        {
            audioSource.volume = 0f;
        }
    }

    public void ChangeBGMVolume(float volume)
    {
        audioSourceBGM.volume = volume;
    }

    public void ChangeSFXVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
