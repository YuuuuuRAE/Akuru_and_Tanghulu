using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    // Singleton Pattern
    public static BGMPlayer instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("ÆÄ±«");
        }
    }

    private void Start()
    {

        audioSource.Play();
    }

}
