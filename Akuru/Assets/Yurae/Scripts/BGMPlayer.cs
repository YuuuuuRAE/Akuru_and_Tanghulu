using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMPlayer : MonoBehaviour
{
    public AudioManager audioManager;

    private void Start()
    {
        audioManager.Play(GameManager.instance.BGMname);
    }

}
