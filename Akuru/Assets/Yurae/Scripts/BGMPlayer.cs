using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip BGM;

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
            Debug.Log("파괴");
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (GameManager.instance.isBGM == false)
        {
            audioSource.Stop(); //음악 중지
        }
        else if (GameManager.instance.isBGM == true && audioSource.isPlaying == false)
        {
            audioSource.Play(); //게임매니저 내 isbgm이 t이고 음악이 실행중이 아니라면 음악 재생
        }
    }


}
