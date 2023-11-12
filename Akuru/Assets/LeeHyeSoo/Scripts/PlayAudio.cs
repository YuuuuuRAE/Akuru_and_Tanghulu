using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    SoundEffect soundEffect;
    AudioSource audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        soundEffect = FindAnyObjectByType<SoundEffect>();
        audioSource = GameObject.Find(name: "SoundEffectPlayer").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayConfirm()
    {
        audioSource.clip = soundEffect.clips[2];
        audioSource.Play();
    }

    public void PlayTapping_Sound_re()
    {
        audioSource.clip = soundEffect.clips[7];
        audioSource.Play();
    }

    
}
