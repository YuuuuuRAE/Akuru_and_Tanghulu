using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundPlayer : MonoBehaviour
{
    public AudioManager audioManager;

    public string BGMname;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            PlayBGM(BGMname);
    }

    private void PlayBGM(string _BGMname)
    {
        audioManager.Play(_BGMname);
    }
}
