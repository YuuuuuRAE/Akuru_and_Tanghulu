using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] clips;



    public void ButtonClick(string _clipName)
    {
        if(GameManager.instance.isSound == true)
        {

            for (int i = 0; i < clips.Length; i++)
            {
                if (clips[i].name == _clipName)
                {
                    audioSource.clip = clips[i];
                    audioSource.Play();
                }
            }

        }
    }
}
