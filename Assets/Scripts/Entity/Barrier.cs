using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
*  作   者 ：胡朋
*  github : https://github.com/xiaomoinfo
*  描   述 ：
*/
public class Barrier : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayerAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}