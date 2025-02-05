
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("AudioClips")]
    public AudioClip audioClipForBg,audioClipforShoot,audioClipForJump,audioClipForDash,audioClipForEnemyAttack;
    [Header("AudioSource")]
    public AudioSource audioSource;
    public UnityEngine.UI.Slider VolumeSlider;
    public static AudioController instance;
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        PlayBgClip();
        VolumeSlider.onValueChanged.AddListener(VolumeControl);
    }

    public void PlayBgClip()
    {
        audioSource.clip = audioClipForBg;
        audioSource.Play();
    }

    public void YakAttackClip(AudioClip yakAttackClip)
    {
        audioSource.clip = yakAttackClip;
        audioSource.Play();

    }

    public void VolumeControl(float volume)
    {
        Debug.Log("Slider Value: " + volume);
        audioSource.volume = volume;
    }

    public void PlayShootAudio()
    {

        audioSource.PlayOneShot(audioClipforShoot);
    } 
    
    public void PlayJumpAudio()
    {

        audioSource.PlayOneShot(audioClipForJump);

    }
    public void PlayDashAudio()
    {
        audioSource.PlayOneShot(audioClipForDash);

    }

    public void PlayerEnemyAttackAudio(AudioClip enemyAudioSound)
    {
        audioSource.PlayOneShot(enemyAudioSound);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
