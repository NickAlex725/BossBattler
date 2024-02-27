using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip _loseSXF;
    [SerializeField] private AudioClip _winSXF;
    [SerializeField] private AudioClip _EnemyAttackSFX;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayLoseAudio()
    {
        _audioSource.PlayOneShot(_loseSXF);
    }

    public void PlayWinAudio()
    {
        _audioSource.PlayOneShot(_winSXF);
    }

    public void PlayEnemyAttackAudio()
    {
        _audioSource.PlayOneShot(_EnemyAttackSFX);
    }
}
