using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundPlayer : MonoBehaviour
{
    public AudioManager audioManager;

    public string BGMname;

    private void Start()
    {
        StartCoroutine(PlayBGM(BGMname));
    }

    IEnumerator PlayBGM(string _BGMname)
    {
        yield return new WaitForSeconds(2.5f);
        audioManager.Play(_BGMname);
    }
}
